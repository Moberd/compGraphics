#include <iostream>
#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#define _USE_MATH_DEFINES // for C++
#include <cmath>
#include <math.h>

// ID ��������� ���������
GLuint Program;
// ID ��������
GLint Attrib_vertex;
// ID Vertex Buffer Object
GLuint VBO;
// ID uniform
GLint gScaleLocation;

struct Vertex {
	GLfloat x;
	GLfloat y;
};

// �������� ��� ���������� �������
const char* VertexShaderSource = R"(
	#version 330 core
	in vec2 coord;
	void main() {
		gl_Position = vec4(coord, 0.0, 1.0);
	}
)";

// �������� ��� ������������ �������
const char* FragShaderSource = R"(
	#version 330 core
	uniform vec4 color; //out vec4 color;
	void main() {
		gl_FragColor = color; //color = vec4(0.5, 0.5, 1, 1);
	}
)";


//void SetIcon(sf::Window& wnd);
void Init();
void Draw();

// ������������ ������
void ReleaseVBO() {
	glBindBuffer(GL_ARRAY_BUFFER, 0);
	glDeleteBuffers(1, &VBO);
}

// ������������ ��������
void ReleaseShader() {
	// ��������� ����, �� ��������� ��������� ���������
	glUseProgram(0);
	// ������� ��������� ���������
	glDeleteProgram(Program);
}

void Release() {
	// �������
	ReleaseShader();
	// ��������� �����
	ReleaseVBO();
}

int main() {
	sf::Window window(sf::VideoMode(600, 600), "My OpenGL window",
		sf::Style::Default, sf::ContextSettings(24));
	window.setVerticalSyncEnabled(true);
	window.setActive(true);
	glewInit();
	Init();
	while (window.isOpen()) {
		sf::Event event;
		while (window.pollEvent(event)) {
			if (event.type == sf::Event::Closed) { window.close(); }
			else if (event.type == sf::Event::Resized) {
				glViewport(0, 0, event.size.width,
					event.size.height);
			}
		}
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
		Draw();
		window.display();
	}
	Release();

	return 0;
}

void checkOpenGLerror()
{
	GLenum err;
	while ((err = glGetError()) != GL_NO_ERROR)
	{
		// Process/log the error.
		std::cout << err << std::endl;
	}
}
void ShaderLog(unsigned int shader)
{
	int infologLen = 0;
	glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
	if (infologLen > 1)
	{
		int charsWritten = 0;
		std::vector<char> infoLog(infologLen);
		glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog.data());
		std::cout << "InfoLog: " << infoLog.data() << std::endl;
	}
}

void InitShader() {
	// ������� ��������� ������
	GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
	// �������� �������� ���
	glShaderSource(vShader, 1, &VertexShaderSource, NULL);
	// ����������� ������
	glCompileShader(vShader);
	std::cout << "vertex shader \n";
	// ������� ������ ���� �������
	ShaderLog(vShader);

	// ������� ����������� ������
	GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
	// �������� �������� ���
	glShaderSource(fShader, 1, &FragShaderSource, NULL);
	// ����������� ������
	glCompileShader(fShader);
	std::cout << "fragment shader \n";
	// ������� ������ ���� �������
	ShaderLog(fShader);

	// ������� ��������� � ����������� ������� � ���
	Program = glCreateProgram();
	glAttachShader(Program, vShader);
	glAttachShader(Program, fShader);
	// ������� ��������� ���������
	glLinkProgram(Program);
	// ��������� ������ ������
	int link_ok;
	glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
	if (!link_ok) {
		std::cout << "error attach shaders \n";
		return;
	}
	// ���������� ID �������� �� ��������� ���������
	const char* attr_name = "coord"; //��� � �������
	Attrib_vertex = glGetAttribLocation(Program, attr_name);
	if (Attrib_vertex == -1) {
		std::cout << "could not bind attrib " << attr_name << std::endl;
		return;
	}

	checkOpenGLerror();
}

void InitVBO() {
	glGenBuffers(1, &VBO);
	// ������� ���������������
	Vertex quad[4] = {
	{ -0.5f, -0.5f },
	{ -0.5f, 0.5f },
	{ 0.5f, 0.5f },
	{ 0.5f, -0.5f }
	};
	// ������� ����������� �������������
	float R = 1.0;
	float pi = 3.14159265358979323846;
	float phi = pi * 2 / 5;
	Vertex pentagon[5] = {
		{R * cos(phi + 2.0f * pi * 1.0f / 5.0f), R * sin(phi + 2.0f * pi * 1.0f / 5.0f)},
		{R * cos(phi + 2.0f * pi * 2.0f / 5.0f), R * sin(phi + 2.0f * pi * 2.0f / 5.0f)},
		{R * cos(phi + 2.0f * pi * 3.0f / 5.0f), R * sin(phi + 2.0f * pi * 3.0f / 5.0f)},
		{R * cos(phi + 2.0f * pi * 4.0f / 5.0f), R * sin(phi + 2.0f * pi * 4.0f / 5.0f)},
		{R * cos(phi + 2.0f * pi * 5.0f / 5.0f), R * sin(phi + 2.0f * pi * 5.0f / 5.0f)}
	};
	// ������� �����
	phi = pi * 2 / 27;
	Vertex fan[9] = {
		//{0.0f, 0.0f},
		{R * cos(phi + 2.0f * pi * 19.5f / 27.0f),	R * sin(phi + 2.0f * pi * 19.5f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 26.0f / 27.0f),	R * sin(phi + 2.0f * pi * 26.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 1.0f / 27.0f),	R * sin(phi + 2.0f * pi * 1.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 3.0f / 27.0f),	R * sin(phi + 2.0f * pi * 3.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 5.0f / 27.0f),	R * sin(phi + 2.0f * pi * 5.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 7.0f / 27.0f),	R * sin(phi + 2.0f * pi * 7.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 9.0f / 27.0f),	R * sin(phi + 2.0f * pi * 9.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 11.0f / 27.0f),	R * sin(phi + 2.0f * pi * 11.0f / 27.0f)},
		{R * cos(phi + 2.0f * pi * 13.0f / 27.0f),	R * sin(phi + 2.0f * pi * 13.0f / 27.0f)},
	};

	// �������� ������� � �����
	glBindBuffer(GL_ARRAY_BUFFER, VBO);

	//glBufferData(GL_ARRAY_BUFFER, sizeof(quad), quad, GL_STATIC_DRAW); // ��������������
	glBufferData(GL_ARRAY_BUFFER, sizeof(pentagon), pentagon, GL_STATIC_DRAW); // ���������� ������������
	//glBufferData(GL_ARRAY_BUFFER, sizeof(fan), fan, GL_STATIC_DRAW); // ����

	checkOpenGLerror(); // �������� ������ OpenGL, ���� ���� �� ����� � ������� ��� ������
}

void Draw() {
	glUseProgram(Program); // ������������� ��������� ��������� �������
	glEnableVertexAttribArray(Attrib_vertex); // �������� ������ ���������
	glBindBuffer(GL_ARRAY_BUFFER, VBO); // ���������� VBO
	glVertexAttribPointer(Attrib_vertex, 2, GL_FLOAT, GL_FALSE, 0, 0); // �������� pointer 0 ��� ������������ ������, �� ��������� ��� ������ � VBO
	glBindBuffer(GL_ARRAY_BUFFER, 0); // ��������� VBO
									  
	float Color[4] = { 0.5f, 0.10f, 0.1f, 0.5f };
	gScaleLocation = glGetUniformLocation(Program, "color");
	glUniform4f(gScaleLocation, Color[0], Color[1], Color[2], Color[3]);

	//glDrawArrays(GL_QUADS, 0, 4); // ��������������
	glDrawArrays(GL_POLYGON, 0, 5); // ���������� ������������
	//glDrawArrays(GL_TRIANGLE_FAN, 0, 9); // ����
	glDisableVertexAttribArray(Attrib_vertex); // ��������� ������ ���������
	glUseProgram(0); // ��������� ��������� ���������
	checkOpenGLerror();
}

// � ������ ������������� ������� ���������� �������� �������, ������� � ������ �����
void Init() {
	// �������
	InitShader();
	//��������� �����
	InitVBO();
}