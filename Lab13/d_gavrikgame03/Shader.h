#pragma once
#include <fstream>
#include <sstream>

#include "headers.h"

class Shader
{
	void checkCompileErrors(GLuint shader, std::string type)
	{
		GLint success;
		GLchar infoLog[1024];
		if (type != "PROGRAM")
		{
			glGetShaderiv(shader, GL_COMPILE_STATUS, &success);
			if (!success)
			{
				glGetShaderInfoLog(shader, 1024, NULL, infoLog);
				std::cout << "ERROR::SHADER_COMPILATION_ERROR of type: " << type << "\n" << infoLog << "\n -- --------------------------------------------------- -- " << std::endl;
			}
		}
		else
		{
			glGetProgramiv(shader, GL_LINK_STATUS, &success);
			if (!success)
			{
				glGetProgramInfoLog(shader, 1024, NULL, infoLog);
				std::cout << "ERROR::PROGRAM_LINKING_ERROR of type: " << type << "\n" << infoLog << "\n -- --------------------------------------------------- -- " << std::endl;
			}
		}
	}

	void getUniformLocation(const std::string& name, GLint& pos) const {
		auto _pos = glGetUniformLocation(ID, name.c_str());
		if (_pos == -1)
		{
			std::cout << "could not bind uniform " << name << std::endl;
			return;
		}
		pos = _pos;
	}

public:

	unsigned int ID;

	void Release() {
		// ????????? ????, ?? ????????? ???????? ?????????
		glUseProgram(0);
		// ??????? ????????? ?????????
		glDeleteProgram(ID);
	}

	Shader(const char* vertexPath, const char* fragmentPath, const char* geometryPath = nullptr)
	{
		// 1. retrieve the vertex/fragment source code from filePath
		std::string vertexCode;
		std::string fragmentCode;
		std::string geometryCode;
		std::ifstream vShaderFile;
		std::ifstream fShaderFile;
		std::ifstream gShaderFile;
		// ensure ifstream objects can throw exceptions:
		vShaderFile.exceptions(std::ifstream::failbit | std::ifstream::badbit);
		fShaderFile.exceptions(std::ifstream::failbit | std::ifstream::badbit);
		gShaderFile.exceptions(std::ifstream::failbit | std::ifstream::badbit);
		try
		{
			// open files
			vShaderFile.open(vertexPath);
			fShaderFile.open(fragmentPath);
			std::stringstream vShaderStream, fShaderStream;
			// read file's buffer contents into streams
			vShaderStream << vShaderFile.rdbuf();
			fShaderStream << fShaderFile.rdbuf();
			// close file handlers
			vShaderFile.close();
			fShaderFile.close();
			// convert stream into string
			vertexCode = vShaderStream.str();
			fragmentCode = fShaderStream.str();
			// if geometry shader path is present, also load a geometry shader
			if (geometryPath != nullptr)
			{
				gShaderFile.open(geometryPath);
				std::stringstream gShaderStream;
				gShaderStream << gShaderFile.rdbuf();
				gShaderFile.close();
				geometryCode = gShaderStream.str();
			}
		}
		catch (std::ifstream::failure& e)
		{
			std::cout << "ERROR::SHADER::FILE_NOT_SUCCESFULLY_READ: " << e.what() << std::endl;
		}
		const char* vShaderCode = vertexCode.c_str();
		const char* fShaderCode = fragmentCode.c_str();
		// 2. compile shaders
		unsigned int vertex, fragment;
		// vertex shader
		vertex = glCreateShader(GL_VERTEX_SHADER);
		glShaderSource(vertex, 1, &vShaderCode, NULL);
		glCompileShader(vertex);
		checkCompileErrors(vertex, "VERTEX");
		// fragment Shader
		fragment = glCreateShader(GL_FRAGMENT_SHADER);
		glShaderSource(fragment, 1, &fShaderCode, NULL);
		glCompileShader(fragment);
		checkCompileErrors(fragment, "FRAGMENT");
		// if geometry shader is given, compile geometry shader
		unsigned int geometry;
		if (geometryPath != nullptr)
		{
			const char* gShaderCode = geometryCode.c_str();
			geometry = glCreateShader(GL_GEOMETRY_SHADER);
			glShaderSource(geometry, 1, &gShaderCode, NULL);
			glCompileShader(geometry);
			checkCompileErrors(geometry, "GEOMETRY");
		}
		// shader Program
		ID = glCreateProgram();
		glAttachShader(ID, vertex);
		glAttachShader(ID, fragment);
		if (geometryPath != nullptr)
			glAttachShader(ID, geometry);
		glLinkProgram(ID);
		checkCompileErrors(ID, "PROGRAM");
		// delete the shaders as they're linked into our program now and no longer necessery
		glDeleteShader(vertex);
		glDeleteShader(fragment);
		if (geometryPath != nullptr)
			glDeleteShader(geometry);

	}

	inline void use() const
	{
		glUseProgram(ID);
	}

	void SetBool(const std::string& name, bool value) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniform1i(pos, (int)value);
	}

	void SetInt(const std::string& name, int value) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniform1i(pos, value);
	}

	void SetFloat(const std::string& name, float value) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniform1f(pos, value);
	}

	// ------------------------------------------------------------------------

	void SetVec2(const std::string& name, const glm::vec2& value) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniform2fv(pos, 1, &value[0]);
	}

	void SetVec3(const std::string& name, const glm::vec3& value) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniform3fv(pos, 1, &value[0]);
	}

	void SetVec4(const std::string& name, const glm::vec4& value) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniform4fv(pos, 1, &value[0]);
	}

	// ------------------------------------------------------------------------

	void SetMat3(const std::string& name, const glm::mat3& mat) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniformMatrix3fv(pos, 1, GL_FALSE, &mat[0][0]);
	}

	void SetMat4(const std::string& name, const glm::mat4& mat) const
	{
		GLint pos;
		getUniformLocation(name, pos);
		glUniformMatrix4fv(pos, 1, GL_FALSE, &mat[0][0]);
	}

};