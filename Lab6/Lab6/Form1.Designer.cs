
namespace Lab6
{
    partial class Form1
    {
         /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.rbPerspective = new System.Windows.Forms.RadioButton();
            this.buttonShape = new System.Windows.Forms.Button();
            this.selectShape = new System.Windows.Forms.ComboBox();
            this.buttonShift = new System.Windows.Forms.Button();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonScale = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textShiftZ = new System.Windows.Forms.TextBox();
            this.textShiftY = new System.Windows.Forms.TextBox();
            this.textShiftX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textScaleZ = new System.Windows.Forms.TextBox();
            this.textScaleY = new System.Windows.Forms.TextBox();
            this.textScaleX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.selectAxis = new System.Windows.Forms.ComboBox();
            this.btnShowAxis = new System.Windows.Forms.Button();
            this.rbIsometric = new System.Windows.Forms.RadioButton();
            this.buttonMirror = new System.Windows.Forms.Button();
            this.selectMirrorAxis = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCenter = new System.Windows.Forms.RadioButton();
            this.rbWorldCenter = new System.Windows.Forms.RadioButton();
            this.buttonRoll = new System.Windows.Forms.Button();
            this.selectRollAxis = new System.Windows.Forms.ComboBox();
            this.textX1 = new System.Windows.Forms.TextBox();
            this.textY1 = new System.Windows.Forms.TextBox();
            this.textZ1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textX2 = new System.Windows.Forms.TextBox();
            this.textY2 = new System.Windows.Forms.TextBox();
            this.textZ2 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textAngleForLineRotation = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.buttonRotateAroundLine = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.textBoxAngleRotCenter = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize) (this.canvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.canvas.Location = new System.Drawing.Point(176, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(839, 512);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // rbPerspective
            // 
            this.rbPerspective.AutoSize = true;
            this.rbPerspective.BackColor = System.Drawing.Color.White;
            this.rbPerspective.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbPerspective.Location = new System.Drawing.Point(835, 6);
            this.rbPerspective.Margin = new System.Windows.Forms.Padding(2);
            this.rbPerspective.Name = "rbPerspective";
            this.rbPerspective.Size = new System.Drawing.Size(155, 17);
            this.rbPerspective.TabIndex = 17;
            this.rbPerspective.Text = "Перспективная проекция";
            this.rbPerspective.UseVisualStyleBackColor = false;
            this.rbPerspective.CheckedChanged += new System.EventHandler(this.rbPerspective_CheckedChanged);
            // 
            // buttonShape
            // 
            this.buttonShape.Location = new System.Drawing.Point(7, 27);
            this.buttonShape.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShape.Name = "buttonShape";
            this.buttonShape.Size = new System.Drawing.Size(165, 23);
            this.buttonShape.TabIndex = 1;
            this.buttonShape.Text = "Нарисовать";
            this.buttonShape.UseVisualStyleBackColor = true;
            this.buttonShape.Click += new System.EventHandler(this.buttonShape_Click);
            // 
            // selectShape
            // 
            this.selectShape.FormattingEnabled = true;
            this.selectShape.Items.AddRange(new object[] {"Тетраэдр", "Гексаэдр", "Октаэдр"});
            this.selectShape.Location = new System.Drawing.Point(7, 6);
            this.selectShape.Margin = new System.Windows.Forms.Padding(2);
            this.selectShape.Name = "selectShape";
            this.selectShape.Size = new System.Drawing.Size(167, 21);
            this.selectShape.TabIndex = 2;
            this.selectShape.SelectedIndexChanged += new System.EventHandler(this.comboBoxShape_SelectedIndexChanged);
            // 
            // buttonShift
            // 
            this.buttonShift.Enabled = false;
            this.buttonShift.Location = new System.Drawing.Point(7, 81);
            this.buttonShift.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(165, 23);
            this.buttonShift.TabIndex = 1;
            this.buttonShift.Text = "Сместить";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Enabled = false;
            this.buttonRotate.Location = new System.Drawing.Point(7, 140);
            this.buttonRotate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(165, 23);
            this.buttonRotate.TabIndex = 1;
            this.buttonRotate.Text = "Повернуть";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // textAngle
            // 
            this.textAngle.Enabled = false;
            this.textAngle.Location = new System.Drawing.Point(43, 120);
            this.textAngle.Margin = new System.Windows.Forms.Padding(2);
            this.textAngle.MaxLength = 5;
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(42, 20);
            this.textAngle.TabIndex = 3;
            this.textAngle.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 121);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Угол:";
            // 
            // buttonScale
            // 
            this.buttonScale.Enabled = false;
            this.buttonScale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonScale.Location = new System.Drawing.Point(7, 252);
            this.buttonScale.Margin = new System.Windows.Forms.Padding(2);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(165, 23);
            this.buttonScale.TabIndex = 1;
            this.buttonScale.Text = "Отмасштабировать";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(123, 62);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Х:";
            // 
            // textShiftZ
            // 
            this.textShiftZ.Enabled = false;
            this.textShiftZ.Location = new System.Drawing.Point(142, 61);
            this.textShiftZ.Margin = new System.Windows.Forms.Padding(2);
            this.textShiftZ.MaxLength = 5;
            this.textShiftZ.Name = "textShiftZ";
            this.textShiftZ.Size = new System.Drawing.Size(31, 20);
            this.textShiftZ.TabIndex = 5;
            this.textShiftZ.Text = "0";
            this.textShiftZ.TextChanged += new System.EventHandler(this.textShiftZ_TextChanged);
            // 
            // textShiftY
            // 
            this.textShiftY.Enabled = false;
            this.textShiftY.Location = new System.Drawing.Point(85, 61);
            this.textShiftY.Margin = new System.Windows.Forms.Padding(2);
            this.textShiftY.MaxLength = 5;
            this.textShiftY.Name = "textShiftY";
            this.textShiftY.Size = new System.Drawing.Size(31, 20);
            this.textShiftY.TabIndex = 6;
            this.textShiftY.Text = "0";
            this.textShiftY.TextChanged += new System.EventHandler(this.textShiftY_TextChanged);
            // 
            // textShiftX
            // 
            this.textShiftX.Enabled = false;
            this.textShiftX.Location = new System.Drawing.Point(27, 61);
            this.textShiftX.Margin = new System.Windows.Forms.Padding(2);
            this.textShiftX.MaxLength = 5;
            this.textShiftX.Name = "textShiftX";
            this.textShiftX.Size = new System.Drawing.Size(31, 20);
            this.textShiftX.TabIndex = 7;
            this.textShiftX.Text = "0";
            this.textShiftX.TextChanged += new System.EventHandler(this.textShiftX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(118, 182);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "cZ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 181);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "cY:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 182);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "cХ:";
            // 
            // textScaleZ
            // 
            this.textScaleZ.Enabled = false;
            this.textScaleZ.Location = new System.Drawing.Point(142, 180);
            this.textScaleZ.Margin = new System.Windows.Forms.Padding(2);
            this.textScaleZ.MaxLength = 5;
            this.textScaleZ.Name = "textScaleZ";
            this.textScaleZ.Size = new System.Drawing.Size(31, 20);
            this.textScaleZ.TabIndex = 11;
            this.textScaleZ.Text = "1";
            this.textScaleZ.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // textScaleY
            // 
            this.textScaleY.Enabled = false;
            this.textScaleY.Location = new System.Drawing.Point(85, 180);
            this.textScaleY.Margin = new System.Windows.Forms.Padding(2);
            this.textScaleY.MaxLength = 5;
            this.textScaleY.Name = "textScaleY";
            this.textScaleY.Size = new System.Drawing.Size(31, 20);
            this.textScaleY.TabIndex = 12;
            this.textScaleY.Text = "1";
            this.textScaleY.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textScaleX
            // 
            this.textScaleX.Enabled = false;
            this.textScaleX.Location = new System.Drawing.Point(27, 180);
            this.textScaleX.Margin = new System.Windows.Forms.Padding(2);
            this.textScaleX.MaxLength = 5;
            this.textScaleX.Name = "textScaleX";
            this.textScaleX.Size = new System.Drawing.Size(31, 20);
            this.textScaleX.TabIndex = 13;
            this.textScaleX.Text = "1";
            this.textScaleX.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(111, 121);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ось:";
            // 
            // selectAxis
            // 
            this.selectAxis.Enabled = false;
            this.selectAxis.FormattingEnabled = true;
            this.selectAxis.Items.AddRange(new object[] {"X", "Y", "Z"});
            this.selectAxis.Location = new System.Drawing.Point(142, 119);
            this.selectAxis.Margin = new System.Windows.Forms.Padding(2);
            this.selectAxis.Name = "selectAxis";
            this.selectAxis.Size = new System.Drawing.Size(31, 21);
            this.selectAxis.TabIndex = 2;
            this.selectAxis.SelectedIndexChanged += new System.EventHandler(this.selectAxis_SelectedIndexChanged);
            // 
            // btnShowAxis
            // 
            this.btnShowAxis.Location = new System.Drawing.Point(828, 48);
            this.btnShowAxis.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowAxis.Name = "btnShowAxis";
            this.btnShowAxis.Size = new System.Drawing.Size(172, 27);
            this.btnShowAxis.TabIndex = 18;
            this.btnShowAxis.Text = "Показать точки и оси";
            this.btnShowAxis.UseVisualStyleBackColor = true;
            this.btnShowAxis.Click += new System.EventHandler(this.btnShowAxis_Click);
            // 
            // rbIsometric
            // 
            this.rbIsometric.AutoSize = true;
            this.rbIsometric.BackColor = System.Drawing.Color.White;
            this.rbIsometric.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbIsometric.Location = new System.Drawing.Point(835, 27);
            this.rbIsometric.Margin = new System.Windows.Forms.Padding(2);
            this.rbIsometric.Name = "rbIsometric";
            this.rbIsometric.Size = new System.Drawing.Size(162, 17);
            this.rbIsometric.TabIndex = 17;
            this.rbIsometric.Text = "Изометрическая проекция";
            this.rbIsometric.UseVisualStyleBackColor = false;
            this.rbIsometric.CheckedChanged += new System.EventHandler(this.rbIsometric_CheckedChanged);
            // 
            // buttonMirror
            // 
            this.buttonMirror.Enabled = false;
            this.buttonMirror.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonMirror.Location = new System.Drawing.Point(5, 291);
            this.buttonMirror.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(131, 23);
            this.buttonMirror.TabIndex = 1;
            this.buttonMirror.Text = "Отразить относительно:";
            this.buttonMirror.UseVisualStyleBackColor = true;
            // 
            // selectMirrorAxis
            // 
            this.selectMirrorAxis.Enabled = false;
            this.selectMirrorAxis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectMirrorAxis.FormattingEnabled = true;
            this.selectMirrorAxis.Items.AddRange(new object[] {"XY", "XZ", "YZ"});
            this.selectMirrorAxis.Location = new System.Drawing.Point(141, 292);
            this.selectMirrorAxis.Margin = new System.Windows.Forms.Padding(2);
            this.selectMirrorAxis.Name = "selectMirrorAxis";
            this.selectMirrorAxis.Size = new System.Drawing.Size(31, 23);
            this.selectMirrorAxis.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(7, 199);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Относительно:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCenter);
            this.panel1.Controls.Add(this.rbWorldCenter);
            this.panel1.Location = new System.Drawing.Point(7, 214);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(165, 36);
            this.panel1.TabIndex = 19;
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Location = new System.Drawing.Point(8, 20);
            this.rbCenter.Margin = new System.Windows.Forms.Padding(2);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(97, 17);
            this.rbCenter.TabIndex = 0;
            this.rbCenter.Text = "Центр фигуры";
            this.rbCenter.UseVisualStyleBackColor = true;
            // 
            // rbWorldCenter
            // 
            this.rbWorldCenter.AutoSize = true;
            this.rbWorldCenter.Checked = true;
            this.rbWorldCenter.Location = new System.Drawing.Point(8, 3);
            this.rbWorldCenter.Margin = new System.Windows.Forms.Padding(2);
            this.rbWorldCenter.Name = "rbWorldCenter";
            this.rbWorldCenter.Size = new System.Drawing.Size(55, 17);
            this.rbWorldCenter.TabIndex = 0;
            this.rbWorldCenter.TabStop = true;
            this.rbWorldCenter.Text = "(0,0,0)";
            this.rbWorldCenter.UseVisualStyleBackColor = true;
            // 
            // buttonRoll
            // 
            this.buttonRoll.Enabled = false;
            this.buttonRoll.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonRoll.Location = new System.Drawing.Point(6, 358);
            this.buttonRoll.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(166, 23);
            this.buttonRoll.TabIndex = 1;
            this.buttonRoll.Text = "Вращать вокруг центра";
            this.buttonRoll.UseVisualStyleBackColor = true;
            // 
            // selectRollAxis
            // 
            this.selectRollAxis.Enabled = false;
            this.selectRollAxis.FormattingEnabled = true;
            this.selectRollAxis.Items.AddRange(new object[] {"X", "Y", "Z"});
            this.selectRollAxis.Location = new System.Drawing.Point(141, 335);
            this.selectRollAxis.Margin = new System.Windows.Forms.Padding(2);
            this.selectRollAxis.Name = "selectRollAxis";
            this.selectRollAxis.Size = new System.Drawing.Size(31, 21);
            this.selectRollAxis.TabIndex = 2;
            this.selectRollAxis.SelectedIndexChanged += new System.EventHandler(this.selectRollAxis_SelectedIndexChanged);
            // 
            // textX1
            // 
            this.textX1.Enabled = false;
            this.textX1.Location = new System.Drawing.Point(27, 416);
            this.textX1.Margin = new System.Windows.Forms.Padding(2);
            this.textX1.MaxLength = 5;
            this.textX1.Name = "textX1";
            this.textX1.Size = new System.Drawing.Size(31, 20);
            this.textX1.TabIndex = 13;
            this.textX1.Text = "0";
            this.textX1.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // textY1
            // 
            this.textY1.Enabled = false;
            this.textY1.Location = new System.Drawing.Point(85, 417);
            this.textY1.Margin = new System.Windows.Forms.Padding(2);
            this.textY1.MaxLength = 5;
            this.textY1.Name = "textY1";
            this.textY1.Size = new System.Drawing.Size(31, 20);
            this.textY1.TabIndex = 12;
            this.textY1.Text = "0";
            this.textY1.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textZ1
            // 
            this.textZ1.Enabled = false;
            this.textZ1.Location = new System.Drawing.Point(141, 417);
            this.textZ1.Margin = new System.Windows.Forms.Padding(2);
            this.textZ1.MaxLength = 5;
            this.textZ1.Name = "textZ1";
            this.textZ1.Size = new System.Drawing.Size(31, 20);
            this.textZ1.TabIndex = 11;
            this.textZ1.Text = "0";
            this.textZ1.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 419);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "x1:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 418);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 13);
            this.label11.TabIndex = 15;
            this.label11.Text = "y1:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(117, 419);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 13);
            this.label12.TabIndex = 14;
            this.label12.Text = "z1:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 400);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(113, 13);
            this.label13.TabIndex = 16;
            this.label13.Text = "Координаты прямой:";
            // 
            // textX2
            // 
            this.textX2.Enabled = false;
            this.textX2.Location = new System.Drawing.Point(27, 437);
            this.textX2.Margin = new System.Windows.Forms.Padding(2);
            this.textX2.MaxLength = 5;
            this.textX2.Name = "textX2";
            this.textX2.Size = new System.Drawing.Size(31, 20);
            this.textX2.TabIndex = 13;
            this.textX2.Text = "0";
            this.textX2.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // textY2
            // 
            this.textY2.Enabled = false;
            this.textY2.Location = new System.Drawing.Point(85, 437);
            this.textY2.Margin = new System.Windows.Forms.Padding(2);
            this.textY2.MaxLength = 5;
            this.textY2.Name = "textY2";
            this.textY2.Size = new System.Drawing.Size(31, 20);
            this.textY2.TabIndex = 12;
            this.textY2.Text = "0";
            this.textY2.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textZ2
            // 
            this.textZ2.Enabled = false;
            this.textZ2.Location = new System.Drawing.Point(141, 437);
            this.textZ2.Margin = new System.Windows.Forms.Padding(2);
            this.textZ2.MaxLength = 5;
            this.textZ2.Name = "textZ2";
            this.textZ2.Size = new System.Drawing.Size(31, 20);
            this.textZ2.TabIndex = 11;
            this.textZ2.Text = "0";
            this.textZ2.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 439);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "x2:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(61, 439);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(21, 13);
            this.label15.TabIndex = 15;
            this.label15.Text = "y2:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(117, 439);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 13);
            this.label16.TabIndex = 14;
            this.label16.Text = "z2:";
            // 
            // textAngleForLineRotation
            // 
            this.textAngleForLineRotation.Enabled = false;
            this.textAngleForLineRotation.Location = new System.Drawing.Point(78, 461);
            this.textAngleForLineRotation.Margin = new System.Windows.Forms.Padding(2);
            this.textAngleForLineRotation.MaxLength = 5;
            this.textAngleForLineRotation.Name = "textAngleForLineRotation";
            this.textAngleForLineRotation.Size = new System.Drawing.Size(42, 20);
            this.textAngleForLineRotation.TabIndex = 3;
            this.textAngleForLineRotation.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(43, 463);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 4;
            this.label17.Text = "Угол:";
            // 
            // buttonRotateAroundLine
            // 
            this.buttonRotateAroundLine.Enabled = false;
            this.buttonRotateAroundLine.Location = new System.Drawing.Point(5, 480);
            this.buttonRotateAroundLine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRotateAroundLine.Name = "buttonRotateAroundLine";
            this.buttonRotateAroundLine.Size = new System.Drawing.Size(165, 23);
            this.buttonRotateAroundLine.TabIndex = 1;
            this.buttonRotateAroundLine.Text = "Повернуть вокруг прямой";
            this.buttonRotateAroundLine.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(111, 337);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(30, 13);
            this.label18.TabIndex = 20;
            this.label18.Text = "Ось:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 337);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(35, 13);
            this.label19.TabIndex = 21;
            this.label19.Text = "Угол:";
            // 
            // textBoxAngleRotCenter
            // 
            this.textBoxAngleRotCenter.Enabled = false;
            this.textBoxAngleRotCenter.Location = new System.Drawing.Point(44, 335);
            this.textBoxAngleRotCenter.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxAngleRotCenter.MaxLength = 5;
            this.textBoxAngleRotCenter.Name = "textBoxAngleRotCenter";
            this.textBoxAngleRotCenter.Size = new System.Drawing.Size(42, 20);
            this.textBoxAngleRotCenter.TabIndex = 22;
            this.textBoxAngleRotCenter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1015, 512);
            this.Controls.Add(this.textBoxAngleRotCenter);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShowAxis);
            this.Controls.Add(this.rbPerspective);
            this.Controls.Add(this.rbIsometric);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.textZ2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textZ1);
            this.Controls.Add(this.textY2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textY1);
            this.Controls.Add(this.textX2);
            this.Controls.Add(this.textScaleZ);
            this.Controls.Add(this.textX1);
            this.Controls.Add(this.textScaleY);
            this.Controls.Add(this.textScaleX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textShiftZ);
            this.Controls.Add(this.textShiftY);
            this.Controls.Add(this.textShiftX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.textAngleForLineRotation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textAngle);
            this.Controls.Add(this.selectRollAxis);
            this.Controls.Add(this.selectMirrorAxis);
            this.Controls.Add(this.selectAxis);
            this.Controls.Add(this.selectShape);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.buttonRoll);
            this.Controls.Add(this.buttonMirror);
            this.Controls.Add(this.buttonRotateAroundLine);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.buttonShift);
            this.Controls.Add(this.buttonShape);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Алгем (на максималках)";
            ((System.ComponentModel.ISupportInitialize) (this.canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button buttonShape;
        private System.Windows.Forms.ComboBox selectShape;
        private System.Windows.Forms.Button buttonShift;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.TextBox textAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textShiftZ;
        private System.Windows.Forms.TextBox textShiftY;
        private System.Windows.Forms.TextBox textShiftX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textScaleZ;
        private System.Windows.Forms.TextBox textScaleY;
        private System.Windows.Forms.TextBox textScaleX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox selectAxis;
        private System.Windows.Forms.RadioButton rbPerspective;
        private System.Windows.Forms.Button btnShowAxis;
        private System.Windows.Forms.RadioButton rbIsometric;
        private System.Windows.Forms.Button buttonMirror;
        private System.Windows.Forms.ComboBox selectMirrorAxis;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbWorldCenter;
        private System.Windows.Forms.Button buttonRoll;
        private System.Windows.Forms.ComboBox selectRollAxis;
        private System.Windows.Forms.TextBox textX1;
        private System.Windows.Forms.TextBox textY1;
        private System.Windows.Forms.TextBox textZ1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textX2;
        private System.Windows.Forms.TextBox textY2;
        private System.Windows.Forms.TextBox textZ2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox textAngleForLineRotation;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button buttonRotateAroundLine;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox textBoxAngleRotCenter;
    }
}


