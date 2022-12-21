#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include "obj_parsing.h"


// Переменные с индентификаторами ID
// ID шейдерной программы
GLuint Program;

// ID VBO вершин
GLuint VBO;

// ID VAO вершин
GLuint VAO;

// ID юниформа текстур
GLint unifTexture1;
GLint unifTexture2;
// ID текстур
GLint textureHandle1;
GLint textureHandle2;
// SFML текстур
sf::Texture ourTexture1;
sf::Texture ourTexture2;

// регулирование текстур
GLint Unif_reg;

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
    in vec3 vertexNormale;
    in vec2 vertexTextureCoords;
    
    out vec2 vTextureCoordinate;
    out vec3 vColor; 
    void main() {
        float x_angle = -0.5;
        float y_angle = 0.5;
        vec3 position = vertexPosition * mat3(
            1, 0, 0,
            0, cos(x_angle), -sin(x_angle),
            0, sin(x_angle), cos(x_angle)
        ) * mat3(
            cos(y_angle), 0, sin(y_angle),
            0, 1, 0,
            -sin(y_angle), 0, cos(y_angle)
        );

        vTextureCoordinate = vertexTextureCoords;
        vColor = (vertexNormale + vec3(1.0, 1.0, 1.0)) * 0.5;

        // Присваиваем вершину волшебной переменной gl_Position
        gl_Position = vec4(position.x, position.y, (position.z * 0.1) + 0.5, 1.0);
    }
)";

// Исходный код фрагментного шейдера
const char* FragShaderSource = R"(
    #version 330 core

    in vec2 vTextureCoordinate;
    in vec3 vColor;

    // Цвет, который будем отрисовывать
    out vec4 color;

    uniform sampler2D ourTexture1;
    uniform sampler2D ourTexture2;
    uniform float reg;
    void main() {
       // Задание 2
       //color = mix(texture(ourTexture1, vTextureCoordinate), vec4(vColor, 1.0), reg);
       // Задание 3
       color = mix(texture(ourTexture1, vTextureCoordinate), texture(ourTexture2, vTextureCoordinate), reg);
    }
)";

std::vector<GLfloat> vertices{};

std::vector<GLuint>  indices{};

std::vector<std::string> split(const std::string& s, char delim) {
    std::stringstream ss(s);
    std::string item;
    std::vector<std::string> elems;
    while (std::getline(ss, item, delim)) {
        elems.push_back(item);
    }
    return elems;
}

void parseFile(std::string fileName) {

    std::ifstream obj(fileName);

    if (!obj.is_open()) {
        throw std::exception("File cannot be opened");
    }

    std::vector<std::vector<float>> v{};
    std::vector<std::vector<float>> vt{};
    std::vector<std::vector<float>> vn{};

    std::vector <std::string> indexAccordance{};
    std::string line;
    while (std::getline(obj, line))
    {
        std::istringstream iss(line);
        std::string type;
        iss >> type;
        if (type == "v") {
            auto vertex = split(line, ' ');
            std::vector<float> cv{};
            for (size_t j = 1; j < vertex.size(); j++)
            {
                cv.push_back(std::stof(vertex[j]));
            }
            v.push_back(cv);
        }
        else if (type == "vn") {
            auto normale = split(line, ' ');
            std::vector<float> cvn{};
            for (size_t j = 1; j < normale.size(); j++)
            {
                cvn.push_back(std::stof(normale[j]));
            }
            vn.push_back(cvn);
        }
        else if (type == "vt") {
            auto texture = split(line, ' ');
            std::vector<float> cvt{};
            for (size_t j = 1; j < texture.size(); j++)
            {
                cvt.push_back(std::stof(texture[j]));
            }
            vt.push_back(cvt);
        }
        else if (type == "f") {
            auto splitted = split(line, ' ');
            for (size_t i = 1; i < splitted.size(); i++)
            {
                auto triplet = split(splitted[i], '/');
                int positionIndex = std::stoi(triplet[0]) - 1;
                for (int j = 0; j < 3; j++) {
                    vertices.push_back(v[positionIndex][j]);
                }
                int normaleIndex = std::stoi(triplet[2]) - 1;
                for (int j = 0; j < 3; j++) {
                    vertices.push_back(vn[normaleIndex][j]);
                }
                int textureIndex = std::stoi(triplet[1]) - 1;
                for (int j = 0; j < 2; j++) {
                    vertices.push_back(vt[textureIndex][j]);
                }
            }
        }
        else {
            continue;
        }
    }
    return;
}

float reg = 0.05;
// регулирование текстур
void changeText(float regg) {
    if (reg + regg > 1 || reg + regg < 0)
        return;
    reg += regg;

}

int task_main(std::string objFilename) {
    sf::Window window(sf::VideoMode(700, 700), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // Инициализация glew
    glewInit();
    parseFile(objFilename);
    Init();

    while (window.isOpen()) {
        sf::Event event;
        while (window.pollEvent(event)) {
            if (event.type == sf::Event::Closed) {
                window.close();
            }
            else if (event.type == sf::Event::Resized) {
                //glViewport(0, 0, event.size.width, event.size.height);
            }
            else if (event.type == sf::Event::KeyPressed) {
                switch (event.key.code) {
                case (sf::Keyboard::A): changeText(-0.05); break;
                case (sf::Keyboard::D): changeText(0.05); break;
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
void checkOpenGLerror(int place) {
    GLenum errCode;
    // Коды ошибок можно смотреть тут
    // https://www.khronos.org/opengl/wiki/OpenGL_Error
    if ((errCode = glGetError()) != GL_NO_ERROR)
        std::cout << "OpenGl error in " << place << "!: " << errCode << std::endl;
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

void InitBuffers() {
    InitPositionBuffers();
}

void InitPositionBuffers()
{
    glGenVertexArrays(1, &VAO);

    glGenBuffers(1, &VBO);

    //Привязываем VAO
    glBindVertexArray(VAO);

    auto i0 = glGetAttribLocation(Program, "vertexPosition");
    auto i1 = glGetAttribLocation(Program, "vertexNormale");
    auto i2 = glGetAttribLocation(Program, "vertexTextureCoords");

    glEnableVertexAttribArray(i0);
    glEnableVertexAttribArray(i1);
    glEnableVertexAttribArray(i2);

    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, vertices.size() * sizeof(GLfloat), &vertices[0], GL_STATIC_DRAW);

    // 3. Устанавливаем указатели на вершинные атрибуты
    // Атрибут с координатами
    glVertexAttribPointer(i0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
    // Атрибут с цветом
    glVertexAttribPointer(i1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
    // Атрибут с текстурой
    glVertexAttribPointer(i2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));

    std::cout << i0 << " " << i1 << " " << i2 << std::endl;
    std::cout << vertices.size() << std::endl;

    //Отвязываем VAO
    glBindVertexArray(0);
    glDisableVertexAttribArray(i0);
    glDisableVertexAttribArray(i1);
    glDisableVertexAttribArray(i2);
    checkOpenGLerror(1);
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

    unifTexture1 = glGetUniformLocation(Program, "ourTexture1");
    if (unifTexture1 == -1)
    {
        std::cout << "could not bind uniform ourTexture1" << std::endl;
        return;
    }
    
    unifTexture2 = glGetUniformLocation(Program, "ourTexture2");
    if (unifTexture2 == -1)
    {
        std::cout << "could not bind uniform ourTexture2" << std::endl;
        return;
    }

    Unif_reg = glGetUniformLocation(Program, "reg");
    if (Unif_reg < 0 || Unif_reg > 1)
    {
        std::cout << "could not bind uniform reg"<< std::endl;
        return;
    }

    checkOpenGLerror(2);
}

void InitTextures()
{
    const char* filename = "texture1.png";
    // Загружаем текстуру из файла
    if (!ourTexture1.loadFromFile(filename))
    {
        // Не вышло загрузить картинку
        return;
    }
    // Теперь получаем openGL дескриптор текстуры
    textureHandle1 = ourTexture1.getNativeHandle();
    
    filename = "texture2.png";
    if (!ourTexture2.loadFromFile(filename))
    {
        // Не вышло загрузить картинку
        return;
    }
    // Теперь получаем openGL дескриптор текстуры
    textureHandle2 = ourTexture2.getNativeHandle();
    
}

void Init() {
    InitShader();
    InitBuffers();
    InitTextures();
    // Включаем проверку глубины
    glEnable(GL_DEPTH_TEST);
}


void Draw() {

    // Устанавливаем шейдерную программу текущей
    glUseProgram(Program);

    glUniform1f(Unif_reg, reg);

    // Активируем текстурный блок 0, делать этого не обязательно, по умолчанию
    // и так активирован GL_TEXTURE0, это нужно для использования нескольких текстур
    glActiveTexture(GL_TEXTURE0);
    // Обёртка SFML на opengl функцией glBindTexture
    sf::Texture::bind(&ourTexture1);
    // В uniform кладётся текстурный индекс текстурного блока (для GL_TEXTURE0 - 0, для GL_TEXTURE1 - 1 и тд)
    glUniform1i(unifTexture1, 0);

    
    glActiveTexture(GL_TEXTURE1);
    // Обёртка SFML на opengl функцией glBindTexture
    sf::Texture::bind(&ourTexture2);
    // В uniform кладётся текстурный индекс текстурного блока (для GL_TEXTURE0 - 0, для GL_TEXTURE1 - 1 и тд)
    glUniform1i(unifTexture2, 1); //ТЕКСТУРА 2
    

    // Привязываем вао
    glBindVertexArray(VAO);
    // Передаем данные на видеокарту(рисуем)
    glDrawArrays(GL_TRIANGLES, 0, vertices.size());
    glBindVertexArray(0);
    // Отключаем шейдерную программу
    glUseProgram(0);
    checkOpenGLerror(3);
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
    glDeleteBuffers(1, &VBO);
    glDeleteVertexArrays(1, &VAO);
}

void Release() {
    ReleaseShader();
    ReleaseVBO();
}
