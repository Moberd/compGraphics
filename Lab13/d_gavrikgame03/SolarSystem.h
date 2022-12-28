#pragma once
#include "Scene.h"

class SolarSystem : public Scene
{
public:
	SolarSystem(const std::vector<std::pair<const char*, const char*>> shader_paths,
		const std::vector<const char*> texture_paths,
		const std::vector<const char*> mesh_paths) : Scene(shader_paths, texture_paths, mesh_paths) {}
	~SolarSystem() {}

	virtual void Draw() override {
		if (entities.size() < 3) return;

		for (auto& s : shaders) {
			camera.UpdateUniforms(&s);
		}

		// rotating about own axis
		for (auto& ent : entities) {
			ent.rotation.y = globalCl.getElapsedTime().asSeconds();
		}
		// drawing sun
		entities[0].Draw();

		// planets rotating
		const float offset = 1.5f;
		const size_t copies = 5;
		std::array<float, 2> angle = { glm::radians(360.f / copies), 0.f };
		angle[1] = angle[0] * 1.5;

		for (size_t i = 1; i < entities.size(); i++) {
			if (!entities[i]._shader || !entities[i]._mesh) return;

			entities[i]._shader->use();

			for (size_t j = 1; j < copies + 1; j++) {
				auto _angle = globalCl.getElapsedTime().asSeconds() + angle[i - 1] * j;
				auto r = (j + i - 1 + offset);
				auto model_matrix = glm::translate(glm::mat4(1.f), glm::vec3(sin(_angle) * r, 0.f, cos(_angle) * r))
					* glm::rotate(glm::mat4(1.f), entities[i].rotation.y, glm::vec3(0.f, 1.f, 0.f))
					* glm::scale(glm::mat4(1.f), entities[i].scale);
				auto normal = glm::transpose(glm::inverse(glm::mat3(model_matrix)));

				entities[i]._shader->SetMat4("transform.model", model_matrix);
				entities[i]._shader->SetMat3("transform.normal", normal);

				entities[i]._mesh->Draw(entities[i]._shader);
			}

			glUseProgram(0);
		}

	}

private:

};