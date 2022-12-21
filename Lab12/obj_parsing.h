#pragma once
#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

int task_main(std::string objFilename);

void checkOpenGLerror(int place = 0);

void ShaderLog(unsigned int shader);

void InitPositionBuffers();

void InitBuffers();

void Init();

void Draw();

void ReleaseShader();

void ReleaseVBO();

void Release();

void parseFile(std::string fileName);