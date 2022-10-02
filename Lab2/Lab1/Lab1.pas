uses Graphabc;

var
  ftype, a, b: integer;

procedure Dialogue(); //Спрашиваем вопросики
begin
  Writeln('Выберите функцию:');
  Writeln('1.sin(x)');
  Writeln('2.x^2');
  Writeln('3.x^3');
  Read(ftype);
  ClearWindow();
  
  
  Writeln('Задайте диапазон значений:');
  Read(a, b);
  ClearWindow();
end;

function ChoiseFunc(f: integer; x: real): real; // Выбираем функцию
begin
  if (f = 1) then
    ChoiseFunc := Sin(x)
  else
  if(f = 2) then
    ChoiseFunc := x * x
    else
  if(f = 3) then
    ChoiseFunc := x * x * x
  else 
    exit;
end;

function MinNum(a, b, ftype: integer): integer; //Cчитаем минимум функции
var
  min: real;
begin
  min := MaxInt;
  for var i := a to b do
    if ChoiseFunc(ftype, i) < min then min := ChoiseFunc(ftype, i);
  MinNum := Round(min);
end;

function MaxNum(a, b, ftype: integer): integer; //Cчитаем максимум функции
var
  max: real;
begin
  max := -MaxInt;
  for var i := a to b do
    if ChoiseFunc(ftype, i) > max then max := ChoiseFunc(ftype, i);
  MaxNum := Round(max);
end;

procedure DrawGraph(a, b, ftype: integer); //Рисуем функцию
begin
  SetWindowWidth(500); 
  SetWindowHeight(500);
  
  var h := (WindowHeight()) / (Abs(a) + Abs(b)); //Множитель приближения по горизонтали
  var centx := (a + b) div 2; // Центр отрисованного отрезка фунцкии по горизонтали
  var w := (WindowWidth()) / ((Abs(MinNum(a, b, ftype)) + Abs(MaxNum(a, b, ftype)))); //Множитель приближения по вертикали
  
  SetCoordinateOrigin((WindowWidth() div 2) - (centx * Round(h)), Round((MaxNum(a, b, ftype)) * w));
  Line(0, -WindowWidth(), 0, WindowWidth); // вертикальная линия
  Line(-WindowHeight(), 0, WindowHeight(), 0);// горизонтальная линия
  
  var hn := (Abs(a) + Abs(b)) / 500;//
  var xn := a + hn;
  var xn2 := a / 1;
  
  for var i := Round(a * h) + 1 to Round(b * h) do
  begin
    Line(i - 1, Round(-ChoiseFunc(ftype, xn2) * w), i, -Round(ChoiseFunc(ftype, xn) * w));
    xn += hn;
    xn2 += hn;
  end;
end;

begin
  Dialogue();
  DrawGraph(a, b, ftype);
end.