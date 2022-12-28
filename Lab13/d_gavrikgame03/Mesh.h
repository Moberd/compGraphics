#pragma once
#include "headers.h"
#include "misc.h"
#include "Shader.h"
#include "Materials.h"
#include "stb_image.h"
#include <array>
#include <vector>
#include <string>
#include <fstream>
#include <sstream>
#include <string>

static std::vector<std::string> split(const std::string& s, char delim) {
	std::stringstream ss(s);
	std::string item;
	std::vector<std::string> elems;
	while (std::getline(ss, item, delim)) {
		if (item.empty()) continue;
		elems.push_back(item);
		// elems.push_back(std::move(item)); // if C++11 (based on comment from @mchiasson)
	}
	return elems;
}

class Mesh
{
	std::vector<GLfloat> vertices;

	GLuint VBO;
	GLuint VAO;

	void parseFile(const std::string& filePath) {
		try {
			std::ifstream obj(filePath);

			if (!obj.is_open()) {
				throw std::exception("File cannot be opened");
			}

			std::vector<std::vector<float>> v;
			std::vector<std::vector<float>> vt;
			std::vector<std::vector<float>> vn;

			std::vector <std::string> indexAccordance{};
			std::string line;
			while (std::getline(obj, line))
			{
				std::istringstream iss(line);
				std::string type;
				iss >> type;
				if (type == "v") {
					auto vertex = split(line, ' ');
					std::vector<float> cv{};
					for (size_t j = 1; j < vertex.size(); j++)
					{
						cv.push_back(std::stof(vertex[j]));
					}
					v.push_back(cv);
				}
				else if (type == "vn") {
					auto normale = split(line, ' ');
					std::vector<float> cvn{};
					for (size_t j = 1; j < normale.size(); j++)
					{
						cvn.push_back(std::stof(normale[j]));
					}
					vn.push_back(cvn);
				}
				else if (type == "vt") {
					auto texture = split(line, ' ');
					std::vector<float> cvt{};
					for (size_t j = 1; j < texture.size(); j++)
					{
						cvt.push_back(std::stof(texture[j]));
					}
					vt.push_back(cvt);
				}
				else if (type == "f") {
					auto splitted = split(line, ' ');
					if (splitted.size() < 5) {
						for (size_t i = 1; i < splitted.size(); i++)
						{
							auto triplet = split(splitted[i], '/');
							int positionIndex = std::stoi(triplet[0]) - 1;
							for (int j = 0; j < 3; j++) {
								vertices.push_back(v[positionIndex][j]);
							}
							int normaleIndex = std::stoi(triplet[2]) - 1;
							for (int j = 0; j < 3; j++) {
								vertices.push_back(vn[normaleIndex][j]);
							}
							int textureIndex = std::stoi(triplet[1]) - 1;
							for (int j = 0; j < 2; j++) {
								vertices.push_back(vt[textureIndex][j]);
							}
						}
					}
					else {
						std::array<std::vector<std::string>, 4> verts = {
							split(splitted[1], '/'),
							split(splitted[2], '/'),
							split(splitted[3], '/'),
							split(splitted[4], '/'),
						};

						std::array<std::vector<std::string>, 3> triang0 = {
							verts[0], verts[1], verts[2]
						};
						for (auto& triplet : triang0) {
							int positionIndex = std::stoi(triplet[0]) - 1;
							for (int j = 0; j < 3; j++) {
								vertices.push_back(v[positionIndex][j]);
							}
							int normaleIndex = std::stoi(triplet[2]) - 1;
							for (int j = 0; j < 3; j++) {
								vertices.push_back(vn[normaleIndex][j]);
							}
							int textureIndex = std::stoi(triplet[1]) - 1;
							for (int j = 0; j < 2; j++) {
								vertices.push_back(vt[textureIndex][j]);
							}

						}

						std::array<std::vector<std::string>, 3> triang1 = {
							verts[0], verts[2], verts[3]
						};
						for (auto& triplet : triang1) {
							int positionIndex = std::stoi(triplet[0]) - 1;
							for (int j = 0; j < 3; j++) {
								vertices.push_back(v[positionIndex][j]);
							}
							int normaleIndex = std::stoi(triplet[2]) - 1;
							for (int j = 0; j < 3; j++) {
								vertices.push_back(vn[normaleIndex][j]);
							}
							int textureIndex = std::stoi(triplet[1]) - 1;
							for (int j = 0; j < 2; j++) {
								vertices.push_back(vt[textureIndex][j]);
							}
						}
					}

				}
				else {
					continue;
				}
			}
			return;

		}
		catch (const std::exception& e)
		{
			std::cout << e.what() << std::endl;
		}
		std::cout << "Vertices loaded: " << vertices.size() << std::endl;
	}

	void InitPositionBuffers()
	{
		glGenVertexArrays(1, &VAO);
		glGenBuffers(1, &VBO);

		glBindVertexArray(VAO);

		/*auto i0 = glGetAttribLocation(Program, "vPosition");
		auto i1 = glGetAttribLocation(Program, "vNormal");
		auto i2 = glGetAttribLocation(Program, "vTexCoords");*/
		auto i0 = 0;
		auto i1 = 1;
		auto i2 = 2;

		glBindBuffer(GL_ARRAY_BUFFER, VBO);
		glBufferData(GL_ARRAY_BUFFER, vertices.size() * sizeof(GLfloat), &vertices[0], GL_STATIC_DRAW);

		// 3. Устанавливаем указатели на вершинные атрибуты
		// Атрибут с координатами
		glVertexAttribPointer(i0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
		glEnableVertexAttribArray(i0);
		// Атрибут с нормалями
		glVertexAttribPointer(i1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
		glEnableVertexAttribArray(i1);
		// Атрибут с текстурными координатами
		glVertexAttribPointer(i2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));
		glEnableVertexAttribArray(i2);

		//std::cout << i0 << " " << i1 << " " << i2 << std::endl;

		//Отвязываем VAO
		glBindVertexArray(0);
		glDisableVertexAttribArray(i0);
		glDisableVertexAttribArray(i1);
		glDisableVertexAttribArray(i2);
		//checkOpenGLerror(1);
	}

public:

	Material* material;

	Mesh(const std::string& objPath) {
		parseFile(objPath);
		InitPositionBuffers();
		//InitTextures(texturePath);
	}

	~Mesh() {

	}

	void Draw(const Shader* s) {

		if (material) material->SetUniforms(s);

		glBindVertexArray(VAO);
		glDrawArrays(GL_TRIANGLES, 0, vertices.size());
		glBindVertexArray(0);
	}

	void ReleaseVBO()
	{
		glBindBuffer(GL_ARRAY_BUFFER, 0);
		glDeleteBuffers(1, &VBO);
		glDeleteVertexArrays(1, &VAO);
	}
};
