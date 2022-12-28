#version 330 core

#define VERT_POSITION 0
#define VERT_NORMAL 1
#define VERT_TEXCOORD 2

layout (location = VERT_POSITION) in vec3 position;
layout (location = VERT_NORMAL) in vec3 normal;
layout (location = VERT_TEXCOORD) in vec2 texcoord;

uniform struct Transform {
	mat4 model;
	mat4 viewProjection;
	mat3 normal;
	vec3 viewPosition;
} transform;

//uniform struct DirLight {
//	vec3 direction;
//	vec4 ambient;
//	vec4 diffuse;
//	vec4 specular;
//} dirLight;

out Vertex {
	vec2 texcoord ;
	vec3 normal ;
	//vec3 lightDir ;
	vec3 viewDir ;
	// float distance ;
} Vert ;

void main() {
	//переведём координаты вершины в мировую систему координат
	vec4 vertex = transform.model * vec4(position, 1.0);

	//переводим координаты вершины в однородные
	gl_Position = transform.viewProjection * vertex;

	Vert.texcoord = texcoord;
	Vert.normal = transform.normal * normal;
	//Vert.lightDir = light.direction;
	Vert.viewDir = transform.viewPosition - vec3(vertex);
}