#pragma once

#include "headers.h"

// Default camera values
const glm::vec3 POSITION = glm::vec3(0.0f, 0.0f, 0.0f);
const glm::vec3 WORLD_UP = glm::vec3(0.0f, 1.0f, 0.0f);
const float YAW = -90.0f;
const float PITCH = 0.0f;
const float SPEED = 3.0f;
const float SENSITIVITY = 0.1f;
const float ZOOM = 45.0f;

class Camera
{
	// calculates the front vector from the Camera's (updated) Euler Angles
	void updateVectors()
	{
		// new Front vector
		glm::vec3 front;
		front.x = cos(glm::radians(Yaw)) * cos(glm::radians(Pitch));
		front.y = sin(glm::radians(Pitch));
		front.z = sin(glm::radians(Yaw)) * cos(glm::radians(Pitch));
		Front = glm::normalize(front);
		// Right and Up vector
		Right = glm::normalize(glm::cross(Front, WorldUp));  // normalize the vectors, because their length gets closer to 0 the more you look up or down which results in slower movement.
		Up = glm::normalize(glm::cross(Right, Front));
	}

	glm::vec3 Position;
	glm::vec3 Front;
	glm::vec3 Up;
	glm::vec3 Right;
	glm::vec3 WorldUp;

	float Yaw;
	float Pitch;

	float MovementSpeed = SPEED;
	float MouseSensitivity = SENSITIVITY;
	float Zoom = ZOOM;

public:

	enum Camera_Movement {
		FORWARD,
		LEFT,
		BACKWARD,
		RIGHT
	};

	Camera(glm::vec3 position = POSITION, glm::vec3 worldUp = WORLD_UP, float yaw = YAW, float pitch = PITCH) {
		Position = position;
		WorldUp = worldUp;
		Yaw = yaw;
		Pitch = pitch;
		updateVectors();
	}

	// returns the view matrix calculated using Euler Angles and the LookAt Matrix
	inline glm::mat4 GetViewMatrix() const
	{
		return glm::lookAt(Position, Position + Front, Up);
	}

	inline glm::mat4 GetProjectionMatrix() const
	{
		return glm::perspective(glm::radians(Zoom), (float)SCREEN_WIDTH / (float)SCREEN_HEIGHT, 0.1f, 1000.0f);
	}

	void UpdateUniforms(const Shader* s) const {
		s->use();

		s->SetMat4("transform.viewProjection", GetProjectionMatrix() * GetViewMatrix());
		s->SetVec3("transform.viewPosition", Position);

		glUseProgram(0);
	}

	void ProcessMouse(glm::vec2 offset, GLboolean constrainPitch = true)
	{
		offset *= MouseSensitivity;

		Yaw += offset.x;
		Pitch -= offset.y;

		// make sure that when pitch is out of bounds, screen doesn't get flipped
		if (constrainPitch)
		{
			if (Pitch > 89.0f) Pitch = 89.0f;
			if (Pitch < -89.0f) Pitch = -89.0f;
		}

		updateVectors();
	}

	void ProcessKeyboard(Camera_Movement direction, float deltaTime)
	{
		float velocity = MovementSpeed * deltaTime;
		switch (direction)
		{
		case Camera::FORWARD:
			Position += Front * velocity;
			break;
		case Camera::LEFT:
			Position -= Right * velocity;
			break;
		case Camera::BACKWARD:
			Position -= Front * velocity;
			break;
		case Camera::RIGHT:
			Position += Right * velocity;
			break;
		default:
			break;
		}
	}

	void ProcessMouseScroll(float yoffset)
	{
		Zoom -= (float)yoffset;
		if (Zoom < 1.0f) Zoom = 1.0f;
		if (Zoom > 90.0f) Zoom = 90.0f;
	}

};