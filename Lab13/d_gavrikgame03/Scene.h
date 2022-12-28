#pragma once
#include <vector>

#include "Shader.h"
#include "Mesh.h"
#include "Entity.h"
#include "Lights.h"
#include "Camera.h"

class Scene
{
protected:

	float deltaTime;
	sf::Clock cl;
	sf::Clock globalCl;

public:

	inline const float GetDeltaTime() { return deltaTime; }

	inline void ResetClock() {
		deltaTime = cl.getElapsedTime().asSeconds();
		cl.restart();
	}

	std::vector<Shader> shaders;
	std::vector<Material> materials;
	std::vector<Mesh> meshes; // graphical representation
	std::vector<Entity> entities; // actual models
	std::vector<DirLight> lights;
	Camera camera;

	Scene() {}

	Scene(const std::vector<std::pair<const char*, const char*>> shader_paths,
		const std::vector<const char*> texture_paths,
		const std::vector<const char*> mesh_paths) {

		camera = Camera(glm::vec3(0.f, 0.f, 0.f));
		for (auto& vert_frag : shader_paths) {
			shaders.push_back(Shader(vert_frag.first, vert_frag.second));
		}

		for (auto& tex_path : texture_paths) {
			materials.push_back(Material(tex_path));
		}

		for (auto& obj_path : mesh_paths) {
			meshes.push_back(Mesh(obj_path));
		}

		lights.push_back(DirLight());
		for (auto& s : shaders) {
			lights[0].SetUniforms(&s);
		}
	}

	~Scene() {
		for (auto& s : shaders) {
			s.Release();
		}
		for (auto& m : meshes) {
			m.ReleaseVBO();
		}
	}

	virtual void Draw() {
		for (auto& s : shaders) {
			camera.UpdateUniforms(&s);
		}

		for (auto& ent : entities) {
			ent.Draw();
		}
	}

};
