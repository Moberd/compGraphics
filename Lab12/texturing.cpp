#include <iostream>
#include <fstream>
#include <sstream>
#include <string>
#include "obj_parsing.h"


// ���������� � ����������������� ID
// ID ��������� ���������
GLuint Program;

// ID VBO ������
GLuint VBO;

// ID VAO ������
GLuint VAO;

// ID �������� �������
GLint unifTexture1;
GLint unifTexture2;
// ID �������
GLint textureHandle1;
GLint textureHandle2;
// SFML �������
sf::Texture ourTexture1;
sf::Texture ourTexture2;

// ������������� �������
GLint Unif_reg;

// �������
struct Vertex
{
    GLfloat x;
    GLfloat y;
    GLfloat z;
};

// �������� ��� ���������� �������
const char* VertexShaderSource = R"(
    #version 330 core
    // ���������� �������. �������, ���������������� ����� �����.
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

        // ����������� ������� ��������� ���������� gl_Position
        gl_Position = vec4(position.x, position.y, (position.z * 0.1) + 0.5, 1.0);
    }
)";

// �������� ��� ������������ �������
const char* FragShaderSource = R"(
    #version 330 core

    in vec2 vTextureCoordinate;
    in vec3 vColor;

    // ����, ������� ����� ������������
    out vec4 color;

    uniform sampler2D ourTexture1;
    uniform sampler2D ourTexture2;
    uniform float reg;
    void main() {
       // ������� 2
       //color = mix(texture(ourTexture1, vTextureCoordinate), vec4(vColor, 1.0), reg);
       // ������� 3
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
// ������������� �������
void changeText(float regg) {
    if (reg + regg > 1 || reg + regg < 0)
        return;
    reg += regg;

}

int task_main(std::string objFilename) {
    sf::Window window(sf::VideoMode(700, 700), "My OpenGL window", sf::Style::Default, sf::ContextSettings(24));
    window.setVerticalSyncEnabled(true);

    window.setActive(true);

    // ������������� glew
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


// �������� ������ OpenGL, ���� ���� �� ����� � ������� ��� ������
void checkOpenGLerror(int place) {
    GLenum errCode;
    // ���� ������ ����� �������� ���
    // https://www.khronos.org/opengl/wiki/OpenGL_Error
    if ((errCode = glGetError()) != GL_NO_ERROR)
        std::cout << "OpenGl error in " << place << "!: " << errCode << std::endl;
}

// ������� ������ ���� �������
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

    //����������� VAO
    glBindVertexArray(VAO);

    auto i0 = glGetAttribLocation(Program, "vertexPosition");
    auto i1 = glGetAttribLocation(Program, "vertexNormale");
    auto i2 = glGetAttribLocation(Program, "vertexTextureCoords");

    glEnableVertexAttribArray(i0);
    glEnableVertexAttribArray(i1);
    glEnableVertexAttribArray(i2);

    glBindBuffer(GL_ARRAY_BUFFER, VBO);
    glBufferData(GL_ARRAY_BUFFER, vertices.size() * sizeof(GLfloat), &vertices[0], GL_STATIC_DRAW);

    // 3. ������������� ��������� �� ��������� ��������
    // ������� � ������������
    glVertexAttribPointer(i0, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)0);
    // ������� � ������
    glVertexAttribPointer(i1, 3, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(3 * sizeof(GLfloat)));
    // ������� � ���������
    glVertexAttribPointer(i2, 2, GL_FLOAT, GL_FALSE, 8 * sizeof(GLfloat), (GLvoid*)(6 * sizeof(GLfloat)));

    std::cout << i0 << " " << i1 << " " << i2 << std::endl;
    std::cout << vertices.size() << std::endl;

    //���������� VAO
    glBindVertexArray(0);
    glDisableVertexAttribArray(i0);
    glDisableVertexAttribArray(i1);
    glDisableVertexAttribArray(i2);
    checkOpenGLerror(1);
}

void InitShader() {
    // ������� ��������� ������
    GLuint vShader = glCreateShader(GL_VERTEX_SHADER);
    // �������� �������� ���
    glShaderSource(vShader, 1, &VertexShaderSource, NULL);
    // ����������� ������
    glCompileShader(vShader);
    std::cout << "vertex shader \n";
    ShaderLog(vShader);

    // ������� ����������� ������
    GLuint fShader = glCreateShader(GL_FRAGMENT_SHADER);
    // �������� �������� ���
    glShaderSource(fShader, 1, &FragShaderSource, NULL);
    // ����������� ������
    glCompileShader(fShader);
    std::cout << "fragment shader \n";
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
    // ��������� �������� �� �����
    if (!ourTexture1.loadFromFile(filename))
    {
        // �� ����� ��������� ��������
        return;
    }
    // ������ �������� openGL ���������� ��������
    textureHandle1 = ourTexture1.getNativeHandle();
    
    filename = "texture2.png";
    if (!ourTexture2.loadFromFile(filename))
    {
        // �� ����� ��������� ��������
        return;
    }
    // ������ �������� openGL ���������� ��������
    textureHandle2 = ourTexture2.getNativeHandle();
    
}

void Init() {
    InitShader();
    InitBuffers();
    InitTextures();
    // �������� �������� �������
    glEnable(GL_DEPTH_TEST);
}


void Draw() {

    // ������������� ��������� ��������� �������
    glUseProgram(Program);

    glUniform1f(Unif_reg, reg);

    // ���������� ���������� ���� 0, ������ ����� �� �����������, �� ���������
    // � ��� ����������� GL_TEXTURE0, ��� ����� ��� ������������� ���������� �������
    glActiveTexture(GL_TEXTURE0);
    // ������ SFML �� opengl �������� glBindTexture
    sf::Texture::bind(&ourTexture1);
    // � uniform ������� ���������� ������ ����������� ����� (��� GL_TEXTURE0 - 0, ��� GL_TEXTURE1 - 1 � ��)
    glUniform1i(unifTexture1, 0);

    
    glActiveTexture(GL_TEXTURE1);
    // ������ SFML �� opengl �������� glBindTexture
    sf::Texture::bind(&ourTexture2);
    // � uniform ������� ���������� ������ ����������� ����� (��� GL_TEXTURE0 - 0, ��� GL_TEXTURE1 - 1 � ��)
    glUniform1i(unifTexture2, 1); //�������� 2
    

    // ����������� ���
    glBindVertexArray(VAO);
    // �������� ������ �� ����������(������)
    glDrawArrays(GL_TRIANGLES, 0, vertices.size());
    glBindVertexArray(0);
    // ��������� ��������� ���������
    glUseProgram(0);
    checkOpenGLerror(3);
}


// ������������ ��������
void ReleaseShader() {
    // ��������� ����, �� ��������� �������� ���������
    glUseProgram(0);
    // ������� ��������� ���������
    glDeleteProgram(Program);
}

// ������������ ������
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
