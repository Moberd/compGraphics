#pragma once

#include "headers.h"
#include "Shader.h"

struct DirLight {
	glm::vec3 direction{ 0.f, -1.f, -1.f };
	glm::vec4 ambient{ 0.2f, 0.2f, 0.2f, 1.f };
	glm::vec4 diffuse{ 0.8f, 0.8f, 0.8f, 1.f };
	glm::vec4 specular{ 1.0f, 1.0f, 1.0f, 1.f };

	void SetUniforms(const Shader* s) {
		s->use();

		s->SetVec3("dirLight.direction", direction);
		s->SetVec4("dirLight.ambient", ambient);
		s->SetVec4("dirLight.diffuse", diffuse);
		s->SetVec4("dirLight.specular", specular);

		glUseProgram(0);
	}
};