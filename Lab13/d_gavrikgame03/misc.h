#pragma once
#include "headers.h"

static char const* gl_error_string(GLenum const err) noexcept
{
	switch (err)
	{
		// opengl 2 errors (8)
	case GL_NO_ERROR:
		return "GL_NO_ERROR";

	case GL_INVALID_ENUM:
		return "GL_INVALID_ENUM";

	case GL_INVALID_VALUE:
		return "GL_INVALID_VALUE";

	case GL_INVALID_OPERATION:
		return "GL_INVALID_OPERATION";

	case GL_STACK_OVERFLOW:
		return "GL_STACK_OVERFLOW";

	case GL_STACK_UNDERFLOW:
		return "GL_STACK_UNDERFLOW";

	case GL_OUT_OF_MEMORY:
		return "GL_OUT_OF_MEMORY";

	case GL_TABLE_TOO_LARGE:
		return "GL_TABLE_TOO_LARGE";

		// opengl 3 errors (1)
	case GL_INVALID_FRAMEBUFFER_OPERATION:
		return "GL_INVALID_FRAMEBUFFER_OPERATION";

		// gles 2, 3 and gl 4 error are handled by the switch above
	default:
		assert(!"unknown error");
		return nullptr;
	}
}

static void checkOpenGLerror(int place) {
	GLenum errCode;
	while ((errCode = glGetError()) != GL_NO_ERROR)
	{
		// ???? ?????? ????? ???????? ???
		// https://www.khronos.org/opengl/wiki/OpenGL_Error
		std::cout << "OpenGl error in place " << place << ": " << gl_error_string(errCode) << std::endl;
	}
}