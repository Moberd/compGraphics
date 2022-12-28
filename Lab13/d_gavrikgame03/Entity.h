#pragma once
#include "headers.h"
#include "Mesh.h"
#include "Shader.h"
#include "Camera.h"

class Entity
{
	void UpdateUniforms() {
		auto model_matrix = glm::translate(glm::mat4(1.f), position)
			* glm::rotate(glm::mat4(1.f), rotation.y, glm::vec3(0.f, 1.f, 0.f))
			* glm::scale(glm::mat4(1.f), scale);
		auto normal = glm::transpose(glm::inverse(glm::mat3(model_matrix)));

		_shader->SetMat4("transform.model", model_matrix);
		_shader->SetMat3("transform.normal", normal);
	}

public:

	Mesh* _mesh = nullptr;
	Shader* _shader = nullptr;

	glm::vec3 position{ 0.f, 0.f, 0.f };
	glm::vec3 rotation{ 0.f, 0.f, 0.f };
	glm::vec3 scale{ 1.f, 1.f, 1.f };

	Entity() {}

	Entity(const Mesh* m, const Shader* s) {
		this->_mesh = const_cast<Mesh*>(m);
		this->_shader = const_cast<Shader*>(s);
	}

	~Entity() {

	}

	void Draw() {
		if (!_shader || !_mesh) return;
		_shader->use();

		UpdateUniforms();
		_mesh->Draw(_shader);

		glUseProgram(0);

	}

private:

};
