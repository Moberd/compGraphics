#pragma once

#include "headers.h"
#include "Shader.h"
#include "stb_image.h"

struct Material {

	GLuint texture;
	glm::vec4 emission{ 0.1f, 0.1f, 0.1f, 1.f };
	glm::vec4 ambient{ 0.1f, 0.1f, 0.1f, 1.f };
	glm::vec4 diffuse{ 0.7f, 0.7f, 0.7f, 1.f };
	glm::vec4 specular{ 0.6f, 0.6f, 0.6f, 1.f };
	float shininess = 10.f;

	Material() {}

	Material(const std::string& texturePath) {
		InitTexture(texturePath);
	}

	void InitTexture(const std::string& texturePath) {
		glGenTextures(1, &texture);
		glBindTexture(GL_TEXTURE_2D, texture);
		// set the texture wrapping parameters
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_S, GL_REPEAT);	// set texture wrapping to GL_REPEAT (default wrapping method)
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_WRAP_T, GL_REPEAT);
		// set texture filtering parameters
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MIN_FILTER, GL_LINEAR);
		glTexParameteri(GL_TEXTURE_2D, GL_TEXTURE_MAG_FILTER, GL_LINEAR);
		// load image, create texture and generate mipmaps
		int width, height, nrChannels;
		stbi_set_flip_vertically_on_load(true); // tell stb_image.h to flip loaded texture's on the y-axis.
		unsigned char* data = stbi_load(texturePath.c_str(), &width, &height, &nrChannels, 0);
		if (data)
		{
			glTexImage2D(GL_TEXTURE_2D, 0, nrChannels == 3 ? GL_RGB : GL_RGBA, width, height, 0, nrChannels == 3 ? GL_RGB : GL_RGBA, GL_UNSIGNED_BYTE, data);
			//glTexImage2D(GL_TEXTURE_2D, 0, GL_RGB, width, height, 0, GL_RGB, GL_UNSIGNED_BYTE, data);
			glGenerateMipmap(GL_TEXTURE_2D);
		}
		else {
			std::cout << "Failed to load texture" << std::endl;
		}

		stbi_image_free(data);
	}

	void SetUniforms(const Shader* s) {
		s->SetInt("material.texture", 0);
		glActiveTexture(GL_TEXTURE0);
		glBindTexture(GL_TEXTURE_2D, texture);

		s->SetVec4("material.emission", emission);
		s->SetVec4("material.ambient", ambient);
		s->SetVec4("material.diffuse", diffuse);
		s->SetVec4("material.specular", specular);
		s->SetFloat("material.shininess", shininess);
	}
};