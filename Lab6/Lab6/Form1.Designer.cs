
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
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.canvas.Location = new System.Drawing.Point(368, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(1662, 985);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // rbPerspective
            // 
            this.rbPerspective.AutoSize = true;
            this.rbPerspective.BackColor = System.Drawing.Color.White;
            this.rbPerspective.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbPerspective.Location = new System.Drawing.Point(1670, 12);
            this.rbPerspective.Name = "rbPerspective";
            this.rbPerspective.Size = new System.Drawing.Size(296, 29);
            this.rbPerspective.TabIndex = 17;
            this.rbPerspective.Text = "Перспективная проекция";
            this.rbPerspective.UseVisualStyleBackColor = false;
            this.rbPerspective.CheckedChanged += new System.EventHandler(this.rbPerspective_CheckedChanged);
            // 
            // buttonShape
            // 
            this.buttonShape.Location = new System.Drawing.Point(14, 52);
            this.buttonShape.Name = "buttonShape";
            this.buttonShape.Size = new System.Drawing.Size(329, 43);
            this.buttonShape.TabIndex = 1;
            this.buttonShape.Text = "Нарисовать";
            this.buttonShape.UseVisualStyleBackColor = true;
            this.buttonShape.Click += new System.EventHandler(this.buttonShape_Click);
            // 
            // selectShape
            // 
            this.selectShape.FormattingEnabled = true;
            this.selectShape.Items.AddRange(new object[] { "Тетраэдр", "Гексаэдр", "Октаэдр" });
            this.selectShape.Location = new System.Drawing.Point(14, 12);
            this.selectShape.Name = "selectShape";
            this.selectShape.Size = new System.Drawing.Size(330, 33);
            this.selectShape.TabIndex = 2;
            this.selectShape.SelectedIndexChanged += new System.EventHandler(this.comboBoxShape_SelectedIndexChanged);
            // 
            // buttonShift
            // 
            this.buttonShift.Enabled = false;
            this.buttonShift.Location = new System.Drawing.Point(14, 155);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(329, 43);
            this.buttonShift.TabIndex = 1;
            this.buttonShift.Text = "Сместить";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Enabled = false;
            this.buttonRotate.Location = new System.Drawing.Point(14, 268);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(329, 43);
            this.buttonRotate.TabIndex = 1;
            this.buttonRotate.Text = "Повернуть";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // textAngle
            // 
            this.textAngle.Enabled = false;
            this.textAngle.Location = new System.Drawing.Point(86, 230);
            this.textAngle.MaxLength = 5;
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(79, 31);
            this.textAngle.TabIndex = 3;
            this.textAngle.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Угол:";
            // 
            // buttonScale
            // 
            this.buttonScale.Enabled = false;
            this.buttonScale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonScale.Location = new System.Drawing.Point(14, 485);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(329, 43);
            this.buttonScale.TabIndex = 1;
            this.buttonScale.Text = "Отмасштабировать";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(247, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(130, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Х:";
            // 
            // textShiftZ
            // 
            this.textShiftZ.Enabled = false;
            this.textShiftZ.Location = new System.Drawing.Point(285, 117);
            this.textShiftZ.MaxLength = 5;
            this.textShiftZ.Name = "textShiftZ";
            this.textShiftZ.Size = new System.Drawing.Size(59, 31);
            this.textShiftZ.TabIndex = 5;
            this.textShiftZ.Text = "0";
            this.textShiftZ.TextChanged += new System.EventHandler(this.textShiftZ_TextChanged);
            // 
            // textShiftY
            // 
            this.textShiftY.Enabled = false;
            this.textShiftY.Location = new System.Drawing.Point(170, 117);
            this.textShiftY.MaxLength = 5;
            this.textShiftY.Name = "textShiftY";
            this.textShiftY.Size = new System.Drawing.Size(59, 31);
            this.textShiftY.TabIndex = 6;
            this.textShiftY.Text = "0";
            this.textShiftY.TextChanged += new System.EventHandler(this.textShiftY_TextChanged);
            // 
            // textShiftX
            // 
            this.textShiftX.Enabled = false;
            this.textShiftX.Location = new System.Drawing.Point(55, 117);
            this.textShiftX.MaxLength = 5;
            this.textShiftX.Name = "textShiftX";
            this.textShiftX.Size = new System.Drawing.Size(59, 31);
            this.textShiftX.TabIndex = 7;
            this.textShiftX.Text = "0";
            this.textShiftX.TextChanged += new System.EventHandler(this.textShiftX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(237, 350);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "cZ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(122, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "cY:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 350);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = "cХ:";
            // 
            // textScaleZ
            // 
            this.textScaleZ.Enabled = false;
            this.textScaleZ.Location = new System.Drawing.Point(285, 347);
            this.textScaleZ.MaxLength = 5;
            this.textScaleZ.Name = "textScaleZ";
            this.textScaleZ.Size = new System.Drawing.Size(59, 31);
            this.textScaleZ.TabIndex = 11;
            this.textScaleZ.Text = "1";
            this.textScaleZ.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // textScaleY
            // 
            this.textScaleY.Enabled = false;
            this.textScaleY.Location = new System.Drawing.Point(170, 347);
            this.textScaleY.MaxLength = 5;
            this.textScaleY.Name = "textScaleY";
            this.textScaleY.Size = new System.Drawing.Size(59, 31);
            this.textScaleY.TabIndex = 12;
            this.textScaleY.Text = "1";
            this.textScaleY.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textScaleX
            // 
            this.textScaleX.Enabled = false;
            this.textScaleX.Location = new System.Drawing.Point(55, 347);
            this.textScaleX.MaxLength = 5;
            this.textScaleX.Name = "textScaleX";
            this.textScaleX.Size = new System.Drawing.Size(59, 31);
            this.textScaleX.TabIndex = 13;
            this.textScaleX.Text = "1";
            this.textScaleX.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(221, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 25);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ось:";
            // 
            // selectAxis
            // 
            this.selectAxis.Enabled = false;
            this.selectAxis.FormattingEnabled = true;
            this.selectAxis.Items.AddRange(new object[] { "X", "Y", "Z" });
            this.selectAxis.Location = new System.Drawing.Point(285, 228);
            this.selectAxis.Name = "selectAxis";
            this.selectAxis.Size = new System.Drawing.Size(59, 33);
            this.selectAxis.TabIndex = 2;
            this.selectAxis.SelectedIndexChanged += new System.EventHandler(this.selectAxis_SelectedIndexChanged);
            // 
            // btnShowAxis
            // 
            this.btnShowAxis.Location = new System.Drawing.Point(1670, 93);
            this.btnShowAxis.Name = "btnShowAxis";
            this.btnShowAxis.Size = new System.Drawing.Size(345, 52);
            this.btnShowAxis.TabIndex = 18;
            this.btnShowAxis.Text = "Показать оси";
            this.btnShowAxis.UseVisualStyleBackColor = true;
            this.btnShowAxis.Click += new System.EventHandler(this.btnShowAxis_Click);
            // 
            // rbIsometric
            // 
            this.rbIsometric.AutoSize = true;
            this.rbIsometric.BackColor = System.Drawing.Color.White;
            this.rbIsometric.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbIsometric.Location = new System.Drawing.Point(1670, 47);
            this.rbIsometric.Name = "rbIsometric";
            this.rbIsometric.Size = new System.Drawing.Size(310, 29);
            this.rbIsometric.TabIndex = 17;
            this.rbIsometric.Text = "Изометрическая проекция";
            this.rbIsometric.UseVisualStyleBackColor = false;
            this.rbIsometric.CheckedChanged += new System.EventHandler(this.rbIsometric_CheckedChanged);
            // 
            // buttonMirror
            // 
            this.buttonMirror.Enabled = false;
            this.buttonMirror.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonMirror.Location = new System.Drawing.Point(10, 560);
            this.buttonMirror.Name = "buttonMirror";
            this.buttonMirror.Size = new System.Drawing.Size(262, 43);
            this.buttonMirror.TabIndex = 1;
            this.buttonMirror.Text = "Отразить относительно:";
            this.buttonMirror.UseVisualStyleBackColor = true;
            this.buttonMirror.Click += new System.EventHandler(this.buttonMirror_Click);
            // 
            // selectMirrorAxis
            // 
            this.selectMirrorAxis.Enabled = false;
            this.selectMirrorAxis.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.selectMirrorAxis.FormattingEnabled = true;
            this.selectMirrorAxis.Items.AddRange(new object[] { "XY", "XZ", "YZ" });
            this.selectMirrorAxis.Location = new System.Drawing.Point(281, 562);
            this.selectMirrorAxis.Name = "selectMirrorAxis";
            this.selectMirrorAxis.Size = new System.Drawing.Size(59, 40);
            this.selectMirrorAxis.TabIndex = 2;
            this.selectMirrorAxis.SelectedIndexChanged += new System.EventHandler(this.selectMirrorAxis_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 383);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(160, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Относительно:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCenter);
            this.panel1.Controls.Add(this.rbWorldCenter);
            this.panel1.Location = new System.Drawing.Point(14, 412);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(329, 68);
            this.panel1.TabIndex = 19;
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Location = new System.Drawing.Point(15, 38);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(186, 29);
            this.rbCenter.TabIndex = 0;
            this.rbCenter.Text = "Центр фигуры";
            this.rbCenter.UseVisualStyleBackColor = true;
            // 
            // rbWorldCenter
            // 
            this.rbWorldCenter.AutoSize = true;
            this.rbWorldCenter.Checked = true;
            this.rbWorldCenter.Location = new System.Drawing.Point(15, 5);
            this.rbWorldCenter.Name = "rbWorldCenter";
            this.rbWorldCenter.Size = new System.Drawing.Size(105, 29);
            this.rbWorldCenter.TabIndex = 0;
            this.rbWorldCenter.TabStop = true;
            this.rbWorldCenter.Text = "(0,0,0)";
            this.rbWorldCenter.UseVisualStyleBackColor = true;
            this.rbWorldCenter.CheckedChanged += new System.EventHandler(this.rbWorldCenter_CheckedChanged);
            // 
            // buttonRoll
            // 
            this.buttonRoll.Enabled = false;
            this.buttonRoll.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.buttonRoll.Location = new System.Drawing.Point(12, 688);
            this.buttonRoll.Name = "buttonRoll";
            this.buttonRoll.Size = new System.Drawing.Size(333, 43);
            this.buttonRoll.TabIndex = 1;
            this.buttonRoll.Text = "Вращать вокруг центра";
            this.buttonRoll.UseVisualStyleBackColor = true;
            this.buttonRoll.Click += new System.EventHandler(this.buttonRoll_Click);
            // 
            // selectRollAxis
            // 
            this.selectRollAxis.Enabled = false;
            this.selectRollAxis.FormattingEnabled = true;
            this.selectRollAxis.Items.AddRange(new object[] { "X", "Y", "Z" });
            this.selectRollAxis.Location = new System.Drawing.Point(283, 643);
            this.selectRollAxis.Name = "selectRollAxis";
            this.selectRollAxis.Size = new System.Drawing.Size(59, 33);
            this.selectRollAxis.TabIndex = 2;
            this.selectRollAxis.SelectedIndexChanged += new System.EventHandler(this.selectRollAxis_SelectedIndexChanged);
            // 
            // textX1
            // 
            this.textX1.Enabled = false;
            this.textX1.Location = new System.Drawing.Point(55, 800);
            this.textX1.MaxLength = 5;
            this.textX1.Name = "textX1";
            this.textX1.Size = new System.Drawing.Size(59, 31);
            this.textX1.TabIndex = 13;
            this.textX1.Text = "0";
            this.textX1.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // textY1
            // 
            this.textY1.Enabled = false;
            this.textY1.Location = new System.Drawing.Point(170, 802);
            this.textY1.MaxLength = 5;
            this.textY1.Name = "textY1";
            this.textY1.Size = new System.Drawing.Size(59, 31);
            this.textY1.TabIndex = 12;
            this.textY1.Text = "0";
            this.textY1.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textZ1
            // 
            this.textZ1.Enabled = false;
            this.textZ1.Location = new System.Drawing.Point(281, 802);
            this.textZ1.MaxLength = 5;
            this.textZ1.Name = "textZ1";
            this.textZ1.Size = new System.Drawing.Size(59, 31);
            this.textZ1.TabIndex = 11;
            this.textZ1.Text = "0";
            this.textZ1.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 805);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 25);
            this.label10.TabIndex = 16;
            this.label10.Text = "x1:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(122, 803);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 25);
            this.label11.TabIndex = 15;
            this.label11.Text = "y1:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(233, 805);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 25);
            this.label12.TabIndex = 14;
            this.label12.Text = "z1:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(10, 768);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(221, 25);
            this.label13.TabIndex = 16;
            this.label13.Text = "Координаты прямой:";
            // 
            // textX2
            // 
            this.textX2.Enabled = false;
            this.textX2.Location = new System.Drawing.Point(55, 840);
            this.textX2.MaxLength = 5;
            this.textX2.Name = "textX2";
            this.textX2.Size = new System.Drawing.Size(59, 31);
            this.textX2.TabIndex = 13;
            this.textX2.Text = "0";
            this.textX2.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // textY2
            // 
            this.textY2.Enabled = false;
            this.textY2.Location = new System.Drawing.Point(170, 840);
            this.textY2.MaxLength = 5;
            this.textY2.Name = "textY2";
            this.textY2.Size = new System.Drawing.Size(59, 31);
            this.textY2.TabIndex = 12;
            this.textY2.Text = "0";
            this.textY2.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textZ2
            // 
            this.textZ2.Enabled = false;
            this.textZ2.Location = new System.Drawing.Point(281, 840);
            this.textZ2.MaxLength = 5;
            this.textZ2.Name = "textZ2";
            this.textZ2.Size = new System.Drawing.Size(59, 31);
            this.textZ2.TabIndex = 11;
            this.textZ2.Text = "0";
            this.textZ2.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(10, 843);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 25);
            this.label14.TabIndex = 16;
            this.label14.Text = "x2:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(122, 843);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 25);
            this.label15.TabIndex = 15;
            this.label15.Text = "y2:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(233, 843);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 25);
            this.label16.TabIndex = 14;
            this.label16.Text = "z2:";
            // 
            // textAngleForLineRotation
            // 
            this.textAngleForLineRotation.Enabled = false;
            this.textAngleForLineRotation.Location = new System.Drawing.Point(156, 887);
            this.textAngleForLineRotation.MaxLength = 5;
            this.textAngleForLineRotation.Name = "textAngleForLineRotation";
            this.textAngleForLineRotation.Size = new System.Drawing.Size(79, 31);
            this.textAngleForLineRotation.TabIndex = 3;
            this.textAngleForLineRotation.Text = "0";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(86, 890);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(63, 25);
            this.label17.TabIndex = 4;
            this.label17.Text = "Угол:";
            // 
            // buttonRotateAroundLine
            // 
            this.buttonRotateAroundLine.Enabled = false;
            this.buttonRotateAroundLine.Location = new System.Drawing.Point(10, 923);
            this.buttonRotateAroundLine.Name = "buttonRotateAroundLine";
            this.buttonRotateAroundLine.Size = new System.Drawing.Size(329, 43);
            this.buttonRotateAroundLine.TabIndex = 1;
            this.buttonRotateAroundLine.Text = "Повернуть вокруг прямой";
            this.buttonRotateAroundLine.UseVisualStyleBackColor = true;
            this.buttonRotateAroundLine.Click += new System.EventHandler(this.buttonRotateAroundLine_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(223, 648);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 25);
            this.label18.TabIndex = 20;
            this.label18.Text = "Ось:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(15, 648);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(63, 25);
            this.label19.TabIndex = 21;
            this.label19.Text = "Угол:";
            // 
            // textBoxAngleRotCenter
            // 
            this.textBoxAngleRotCenter.Enabled = false;
            this.textBoxAngleRotCenter.Location = new System.Drawing.Point(87, 643);
            this.textBoxAngleRotCenter.MaxLength = 5;
            this.textBoxAngleRotCenter.Name = "textBoxAngleRotCenter";
            this.textBoxAngleRotCenter.Size = new System.Drawing.Size(79, 31);
            this.textBoxAngleRotCenter.TabIndex = 22;
            this.textBoxAngleRotCenter.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(2030, 985);
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
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Алгем (на максималках)";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
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


