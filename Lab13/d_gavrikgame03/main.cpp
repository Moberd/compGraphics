#include "headers.h"
#include "misc.h"
#include "SolarSystem.h"
#include <array>

void SetIcon(sf::Window& wnd);

bool isCamActive = false;
bool isCamTouched = false;
glm::vec2 mousePos;
glm::vec2 mouseDelta;
// w a s d
std::array<bool, 4> handles = { false, false, false, false };


// filling scene with different entities
// here we can set meshes, materials, initial positions, etc
static void MakeScene(Scene* s) {
	s->meshes[0].material = &s->materials[0];
	s->meshes[1].material = &s->materials[1];
	s->meshes[2].material = &s->materials[2];

	auto teapot = Entity(&s->meshes[0], &s->shaders[0]);
	s->entities.push_back(teapot);

	auto cup1 = Entity(&s->meshes[1], &s->shaders[0]);
	cup1.position += glm::vec3(2.5f, 0.f, 0.0f);
	cup1.scale = glm::vec3(0.14f, 0.14f, 0.14f);
	s->entities.push_back(cup1);

	auto cup2 = Entity(&s->meshes[2], &s->shaders[0]);
	cup2.position += glm::vec3(-2.5f, 0.f, 0.0f);
	cup2.scale = glm::vec3(0.02f, 0.02f, 0.02f);
	s->entities.push_back(cup2);
}

int main() {
	sf::Window window(sf::VideoMode(SCREEN_WIDTH, SCREEN_HEIGHT), "Gavriki tea set", sf::Style::Default, sf::ContextSettings(24));
	SetIcon(window);
	window.setVerticalSyncEnabled(true);
	window.setActive(true);
	GLenum errorcode = glewInit();
	if (errorcode != GLEW_OK) {
		throw std::runtime_error(std::string(reinterpret_cast<const char*>(glewGetErrorString(errorcode))));
	}
	glEnable(GL_DEPTH_TEST);
	glHint(GL_PERSPECTIVE_CORRECTION_HINT, GL_NICEST);
	checkOpenGLerror(1);
	Scene* s = new SolarSystem(
		{
			std::make_pair("triang.vert", "triang.frag"),
		},
		{
			"meshes/tinkoff.jpg",
			"meshes/Cup02.jpg",
			"meshes/tea_cup.png",
		},
		{
			"meshes/teapot.obj",
			"meshes/Cup02.obj",
			"meshes/tea_cup.obj",
		});
	MakeScene(s);

	while (window.isOpen()) {
		sf::Event event;
		mouseDelta = glm::vec2(0.f);
		while (window.pollEvent(event)) {
			if (event.type == sf::Event::Closed) { window.close(); } // poll events
			else if (event.type == sf::Event::Resized) {
				glViewport(0, 0, event.size.width,
					event.size.height);
			}
			else if (event.type == sf::Event::KeyPressed) {
				switch (event.key.code)
				{
				case sf::Keyboard::W:
					handles[0] = true;
					break;

				case sf::Keyboard::A:
					handles[1] = true;
					break;

				case sf::Keyboard::S:
					handles[2] = true;
					break;

				case sf::Keyboard::D:
					handles[3] = true;
					break;

				default:
					break;
				}
			}
			else if (event.type == sf::Event::MouseButtonPressed) {

				switch (event.mouseButton.button)
				{
				case sf::Mouse::Right:
					isCamActive = true;
					break;
				default:
					break;
				}
			}
			else if (event.type == sf::Event::KeyReleased) {
				switch (event.key.code)
				{
				case sf::Keyboard::W:
					handles[0] = false;
					break;

				case sf::Keyboard::A:
					handles[1] = false;
					break;

				case sf::Keyboard::S:
					handles[2] = false;
					break;

				case sf::Keyboard::D:
					handles[3] = false;
					break;

				default:
					break;
				}
			}
			else if (event.type == sf::Event::MouseButtonReleased) {
				switch (event.mouseButton.button)
				{
				case sf::Mouse::Right:
					isCamActive = false;
					break;
				default:
					break;
				}
			}
			else if (event.type == sf::Event::MouseWheelMoved)
			{
				s->camera.ProcessMouseScroll(event.mouseWheel.delta);
			}
			else if (event.type == sf::Event::MouseMoved)
			{
				if (!isCamTouched) {
					mousePos = glm::vec2(event.mouseMove.x, event.mouseMove.y);
					isCamTouched = true;
				}
				auto newMousePos = glm::vec2(event.mouseMove.x, event.mouseMove.y);
				mouseDelta = newMousePos - mousePos;
				mousePos = newMousePos;
			}
		}
		if (isCamActive) s->camera.ProcessMouse(mouseDelta);
		for (size_t i = 0; i < 4; i++) {
			if (handles[i]) s->camera.ProcessKeyboard((Camera::Camera_Movement)i, s->GetDeltaTime());
		}
		s->ResetClock();

		glClearColor(0.1f, 0.1f, 0.15f, 1.0f);
		glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

		s->Draw();

		window.display();
	}

	return 0;
}

void SetIcon(sf::Window& wnd)
{
	sf::Image image;

	// Вместо рисования пикселей, можно загрузить иконку из файла (image.loadFromFile("icon.png"))
	image.create(16, 16);
	for (int i = 0; i < 16; ++i)
		for (int j = 0; j < 16; ++j)
			image.setPixel(i, j, {
				(sf::Uint8)(i * 16), (sf::Uint8)(j * 16), 0 });

	wnd.setIcon(image.getSize().x, image.getSize().y, image.getPixelsPtr());
}