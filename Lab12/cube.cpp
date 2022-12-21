#include <gl/glew.h>
#include <SFML/OpenGL.hpp>
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>

#define deg2rad M_PI /180.0

#define _USE_MATH_DEFINES
#include "math.h"

#include <iostream>
#include <array>
#include <initializer_list>




// Переменные с индентификаторами ID
// ID шейдерной программы
GLuint Program;
// ID атрибута
GLint Attrib_vertex;
GLint Attrib_color;
// ID Vertex Buffer Object
// ID VBO вершин
GLuint VBO_position;
// ID VBO цвета
GLuint VBO_color;
// ID юниформ переменной цвета
GLint Unif_xangle;

GLint Unif_yangle;
GLint Unif_zangle;
// Вершина
struct Vertex
{
    GLfloat x;
    GLfloat y;
    GLfloat z;
};

// Исходный код вершинного шейдера
const char* VertexShaderSource = R"(
    #version 330 core
    // Координаты вершины. Атрибут, инициализируется через буфер.
    in vec3 vertexPosition;
    in vec4 color;
    // Выходной параметр с координатами вершины, интерполируется и передётся во фрагментный шейдер 
    out vec3 vPosition;
    out vec4 vert_color;
    uniform float x_angle;
    uniform float y_angle;
    uniform float z_angle;
    void main() {
        // Передаём непреобразованную координату во фрагментный шейдер
        vPosition = vertexPosition;
        
        // Поворачиваем вершину
        vec3 position = vertexPosition * mat3(
           1, 0, 0,
            0, cos(x_angle), -sin(x_angle),
            0, sin(x_angle), cos(x_angle)
        ) * mat3(
            cos(y_angle), 0, sin(y_angle),
            0, 1, 0,
            -sin(y_angle), 0, cos(y_angle)
        )  * mat3(
            cos(z_angle), sin(z_angle),0,
            -sin(z_angle),cos(z_angle) , 0,
            0, 0, 1
        );
        // Присваиваем вершину волшебной переменной gl_Position
        gl_Position = vec4(position, 1.0);
        vert_color=color;
    }
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core
    // Интерполированные координаты вершины, передаются из вершинного шейдера
    in vec4 vert_color;
    // Цвет, который будем отрисовывать
    out vec4 color;
    void main() {
         color=vert_color;
    }
)";


void Init();
void Draw();
void Release();

float x_angle= 1.0;
float y_angle = -1.0;
float z_angle = 1.0;
//изменение угла поворота по осям
void changeangle(float angleX, float  angleY, float  angleZ) {
    x_angle += angleX;
    y_angle += angleY;
    z_angle += angleZ;
}
int main() {
    sf::Window window(sf::VideoMode(700, 700), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // Инициализация glew
    glewInit();

    Init();

    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) {
                window.close();
            }
            else if (event.type == sf::Event::Resized) {
                glViewport(0, 0, event.size.width, event.size.height);
            }
            else if (event.type == sf::Event::KeyPressed) {
                switch (event.key.code) {
                case (sf::Keyboard::W): changeangle(1* deg2rad, 0,0); break;
                case (sf::Keyboard::S): changeangle(0, -1*deg2rad, 0); break;
                case (sf::Keyboard::A):changeangle(0, 1* deg2rad, 0); break;
                case (sf::Keyboard::D): changeangle(0,-1* deg2rad, 0); break;
                case (sf::Keyboard::E): changeangle(0, 0, 1* deg2rad); break;
                case (sf::Keyboard::Q): changeangle(0, 0, -1* deg2rad); break;
                default: break;
                }
            }
        }

        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);

        Draw();

        window.display();
    }

    Release();
    return 0;
}


// Проверка ошибок OpenGL, если есть то вывод в консоль тип ошибки
void checkOpenGLerror() {
    GLenum errCode;
    // Коды ошибок можно смотреть тут
    // https://www.khronos.org/opengl/wiki/OpenGL_Error
    if ((errCode = glGetError()) != GL_NO_ERROR)
        std::cout << "OpenGl error!: " << errCode << std::endl;
}

// Функция печати лога шейдера
void ShaderLog(unsigned int shader)
{
    int infologLen = 0;
    int charsWritten = 0;
    char* infoLog;
    glGetShaderiv(shader, GL_INFO_LOG_LENGTH, &infologLen);
    if (infologLen > 1)
    {
        infoLog = new char[infologLen];
        if (infoLog == NULL)
        {
            std::cout << "ERROR: Could not allocate InfoLog buffer" << std::endl;
            exit(1);
        }
        glGetShaderInfoLog(shader, infologLen, &charsWritten, infoLog);
        std::cout << "InfoLog: " << infoLog << "\n\n\n";
        delete[] infoLog;
    }
}



void InitVBO()
{
    glGenBuffers(1, &VBO_position);
    glGenBuffers(1, &VBO_color);
    // Вершины кубика
    Vertex triangle[] = {
        { -0.5, -0.5, +0.5 }, { -0.5, +0.5, +0.5 }, { +0.5, +0.5, +0.5 },
        { +0.5, +0.5, +0.5 }, { +0.5, -0.5, +0.5 }, { -0.5, -0.5, +0.5 },
        { -0.5, -0.5, -0.5 }, { +0.5, +0.5, -0.5 }, { -0.5, +0.5, -0.5 },
        { +0.5, +0.5, -0.5 }, { -0.5, -0.5, -0.5 }, { +0.5, -0.5, -0.5 },

        { -0.5, +0.5, -0.5 }, { -0.5, +0.5, +0.5 }, { +0.5, +0.5, +0.5 },
        { +0.5, +0.5, +0.5 }, { +0.5, +0.5, -0.5 }, { -0.5, +0.5, -0.5 },
        { -0.5, -0.5, -0.5 }, { +0.5, -0.5, +0.5 }, { -0.5, -0.5, +0.5 },
        { +0.5, -0.5, +0.5 }, { -0.5, -0.5, -0.5 }, { +0.5, -0.5, -0.5 },

        { +0.5, -0.5, -0.5 }, { +0.5, -0.5, +0.5 }, { +0.5, +0.5, +0.5 },
        { +0.5, +0.5, +0.5 }, { +0.5, +0.5, -0.5 }, { +0.5, -0.5, -0.5 },
        { -0.5, -0.5, -0.5 }, { -0.5, +0.5, +0.5 }, { -0.5, -0.5, +0.5 },
        { -0.5, +0.5, +0.5 }, { -0.5, -0.5, -0.5 }, { -0.5, +0.5, -0.5 },
    };
 //colors-массив цветов для соответствующих вершин
    std::array<std::array<float, 4>, 36> colors = {};
    float r;
    float g;
    float b;
    for (int i = 0; i < 36; i++)
    {
        if (triangle[i].x == -0.5)
            r = 0.0;
        else 
            r = 1.0;
        if (triangle[i].y == -0.5)
            g = 0.0;
        else  
            g = 1.0;
        if (triangle[i].z == -0.5)
            b = 0.0;
        else  
            b = 1.0;
        colors[i] = { r,g,b,1.0 };
    } 
   /* //это очень плохой способ- прописывать цвета ручками{
        { 1.0, 0.0, 1.0, 1.0 },{ 1.0, 0.0, 0.0, 1.0 },{ 1.0, 1.0, 0.0, 1.0 },
        { 1.0, 1.0, 0.0, 1.0 },{ 1.0, 1.0, 1.0, 1.0 },{ 1.0, 0.0, 1.0, 1.0 },//невидимый

        { 1.0, 1.0, 1.0, 1.0 },{ 0.0, 1.0, 0.0, 1.0 },{ 1.0, 1.0, 0.0, 1.0 },
        { 0.0, 1.0, 0.0, 1.0 },{ 1.0, 1.0, 1.0, 1.0 },{ 0.0, 1.0, 1.0, 1.0 },

        { 1.0, 1.0, 0.0, 1.0 },{ 1.0, 0.0, 0.0, 1.0 },{ 1.0, 0.0, 0.0, 1.0 },//невидимый одна непонятная цвет
        { 0.0, 0.0, 0.0, 1.0 },{ 0.0, 1.0, 0.0, 1.0 },{ 1.0, 1.0, 0.0, 1.0 },

        { 1.0, 1.0, 1.0, 1.0 },{ 0.0, 0.0, 1.0, 1.0 },{ 1.0, 0.0, 1.0, 1.0 },
        { 0.0, 0.0, 1.0, 1.0 },{ 1.0, 1.0, 1.0, 1.0 },{ 0.0, 1.0, 1.0, 1.0 },

        { 0.0, 1.0, 1.0, 1.0 },{ 0.0, 0.0, 1.0, 1.0 },{ 0.0, 0.0, 0.0, 1.0 },//невидимый одна непонятная цветовая грань
        { 0.0, 0.0, 0.0, 1.0 },{ 0.0, 1.0, 0.0, 1.0 },{ 0.0, 1.0, 1.0, 1.0 },

        { 1.0, 1.0, 1.0, 1.0 },{ 1.0, 0.0, 0.0, 1.0 },{ 1.0, 0.0, 1.0, 1.0 },
        { 1.0, 0.0, 0.0, 1.0 },{ 1.0, 1.0, 1.0, 1.0 },{ 1.0, 1.0, 0.0, 1.0 },




    };*/
    // Передаем вершины в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    glBufferData(GL_ARRAY_BUFFER, sizeof(triangle), triangle, GL_STATIC_DRAW);
    // Передаем цвета вершин в буфер
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glBufferData(GL_ARRAY_BUFFER, sizeof(colors), colors.data(), GL_STATIC_DRAW);
    checkOpenGLerror();
}


void InitShader() {
    // Создаем вершинный шейдер
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    // Передаем исходный код
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    ShaderLog(vShader);

    // Создаем фрагментный шейдер
    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    // Передаем исходный код
    glShaderSource(fShader, 1, &FragShaderSource, NULL);
    // Компилируем шейдер
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
    ShaderLog(fShader);

    // Создаем программу и прикрепляем шейдеры к ней
    Program = glCreateProgram();
    glAttachShader(Program, vShader);
    glAttachShader(Program, fShader);

    // Линкуем шейдерную программу
    glLinkProgram(Program);
    // Проверяем статус сборки
    int link_ok;
    glGetProgramiv(Program, GL_LINK_STATUS, &link_ok);
    if (!link_ok)
    {
        std::cout << "error attach shaders \n";
        return;
    }

    // Вытягиваем ID атрибута из собранной программы
    const char* attr_name = "vertexPosition";
    Attrib_vertex = glGetAttribLocation(Program, attr_name);
    if (Attrib_vertex == -1)
    {
        std::cout << "could not bind attrib " << attr_name << std::endl;
        return;
    }
    // Вытягиваем ID атрибута цвета
    Attrib_color = glGetAttribLocation(Program, "color");
    if (Attrib_color == -1)
    {
        std::cout << "could not bind attrib color" << std::endl;
        return;
    }
    // Вытягиваем ID юниформ угла поворота по ox
    const char* unif_name = "x_angle";
    Unif_xangle = glGetUniformLocation(Program, unif_name);
    if (Unif_xangle<-360)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }
    // Вытягиваем ID юниформ угла поворота по oy
    unif_name = "y_angle";
    Unif_yangle = glGetUniformLocation(Program, unif_name);
    if (Unif_yangle < -360)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }
    // Вытягиваем ID юниформ угла поворота по oz
    unif_name = "z_angle";
    Unif_zangle = glGetUniformLocation(Program, unif_name);
    if (Unif_zangle < -360)
    {
        std::cout << "could not bind uniform " << unif_name << std::endl;
        return;
    }
   

    checkOpenGLerror();
}

void Init() {
    InitShader();
    InitVBO();
    // Включаем проверку глубины
    glEnable(GL_DEPTH_TEST);
}


void Draw() {
    // Устанавливаем шейдерную программу текущей
    glUseProgram(Program);
    //повороты вершин
    glUniform1f(Unif_xangle, x_angle);
    glUniform1f(Unif_yangle, y_angle);
    glUniform1f(Unif_zangle, z_angle);

    // Включаем массив атрибутов
    glEnableVertexAttribArray(Attrib_vertex);
    glEnableVertexAttribArray(Attrib_color);
    // Подключаем VBO_position
    glBindBuffer(GL_ARRAY_BUFFER, VBO_position);
    // Указывая pointer 0 при подключенном буфере, мы указываем что данные в VBO
    glVertexAttribPointer(Attrib_vertex, 3, GL_FLOAT, GL_FALSE, 0, 0);
    // // Подключаем VBO_color
    glBindBuffer(GL_ARRAY_BUFFER, VBO_color);
    glVertexAttribPointer(Attrib_color, 4, GL_FLOAT, GL_FALSE, 0, 0);
    // Отключаем VBO
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    // Передаем данные на видеокарту(рисуем)
    glDrawArrays(GL_TRIANGLES, 0, 36);
    // Отключаем массив атрибутов
    glDisableVertexAttribArray(Attrib_vertex);
    glDisableVertexAttribArray(Attrib_color);
    // Отключаем шейдерную программу
    glUseProgram(0);
    checkOpenGLerror();
}


// Освобождение шейдеров
void ReleaseShader() {
    // Передавая ноль, мы отключаем шейдрную программу
    glUseProgram(0);
    // Удаляем шейдерную программу
    glDeleteProgram(Program);
}

// Освобождение буфера
void ReleaseVBO()
{
    glBindBuffer(GL_ARRAY_BUFFER, 0);
    glDeleteBuffers(1, &VBO_position);
    glDeleteBuffers(1, &VBO_color);
}

void Release() {
    ReleaseShader();
    ReleaseVBO();
}