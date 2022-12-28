#version 330 core

#define FRAG_OUTPUT0 0
layout (location = FRAG_OUTPUT0) out vec4 color;

uniform struct DirLight {
	vec3 direction;
	vec4 ambient;
	vec4 diffuse;
	vec4 specular;
} dirLight;

uniform struct Material {
	sampler2D texture;
	vec4 ambient;
	vec4 diffuse;
	vec4 specular;
	vec4 emission;
	float shininess;
} material;

in Vertex {
	vec2 texcoord ;
	vec3 normal ;
	//vec3 lightDir ;
	vec3 viewDir ;
	// float distance ;
} Vert ;

void main() {
	vec3 normal = normalize(Vert.normal);
	vec3 lightDir = normalize(-dirLight.direction);
	vec3 viewDir = normalize(Vert.viewDir);

	color = material.emission;

	color += material.ambient * dirLight.ambient;

	float Ndot = max(0.0, dot(normal, lightDir));
	color += material.diffuse * dirLight.diffuse * Ndot;

	float RdotPow = max(0.0, 
		pow(dot(reflect(-lightDir, normal), viewDir), material.shininess));
	color += material.specular * dirLight.specular * RdotPow;
	color *= texture(material.texture, Vert.texcoord);
}