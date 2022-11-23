
namespace Lab7
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.canvas = new System.Windows.Forms.PictureBox();
            this.rbAxonometric = new System.Windows.Forms.RadioButton();
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
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbCenter = new System.Windows.Forms.RadioButton();
            this.rbWorldCenter = new System.Windows.Forms.RadioButton();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnChoosePlot = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageShape = new System.Windows.Forms.TabPage();
            this.tabPagePlot = new System.Windows.Forms.TabPage();
            this.etY1 = new System.Windows.Forms.TextBox();
            this.etX1 = new System.Windows.Forms.TextBox();
            this.etSplit = new System.Windows.Forms.TextBox();
            this.etY0 = new System.Windows.Forms.TextBox();
            this.etX0 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabPageRotate = new System.Windows.Forms.TabPage();
            this.axizRotate = new System.Windows.Forms.ComboBox();
            this.Former = new System.Windows.Forms.Label();
            this.getDiv = new System.Windows.Forms.TextBox();
            this.Divisions = new System.Windows.Forms.Label();
            this.AddPoint = new System.Windows.Forms.Button();
            this.getZ = new System.Windows.Forms.TextBox();
            this.getY = new System.Windows.Forms.TextBox();
            this.getX = new System.Windows.Forms.TextBox();
            this.axZ = new System.Windows.Forms.Label();
            this.axY = new System.Windows.Forms.Label();
            this.axX = new System.Windows.Forms.Label();
            this.pbFormula = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rbDimetric = new System.Windows.Forms.RadioButton();
            this.btnShowPoints = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageShape.SuspendLayout();
            this.tabPagePlot.SuspendLayout();
            this.tabPageRotate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormula)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.canvas.Location = new System.Drawing.Point(235, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(979, 591);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            // 
            // rbAxonometric
            // 
            this.rbAxonometric.AutoSize = true;
            this.rbAxonometric.BackColor = System.Drawing.Color.White;
            this.rbAxonometric.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbAxonometric.Checked = true;
            this.rbAxonometric.Location = new System.Drawing.Point(974, 27);
            this.rbAxonometric.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rbAxonometric.Name = "rbAxonometric";
            this.rbAxonometric.Size = new System.Drawing.Size(172, 19);
            this.rbAxonometric.TabIndex = 17;
            this.rbAxonometric.TabStop = true;
            this.rbAxonometric.Text = "Триметрическая проекция";
            this.rbAxonometric.UseVisualStyleBackColor = false;
            this.rbAxonometric.CheckedChanged += new System.EventHandler(this.rbAxonometric_CheckedChanged);
            // 
            // rbPerspective
            // 
            this.rbPerspective.AutoSize = true;
            this.rbPerspective.BackColor = System.Drawing.Color.White;
            this.rbPerspective.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbPerspective.Location = new System.Drawing.Point(974, 7);
            this.rbPerspective.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rbPerspective.Name = "rbPerspective";
            this.rbPerspective.Size = new System.Drawing.Size(165, 19);
            this.rbPerspective.TabIndex = 17;
            this.rbPerspective.Text = "Перспективная проекция";
            this.rbPerspective.UseVisualStyleBackColor = false;
            this.rbPerspective.CheckedChanged += new System.EventHandler(this.rbPerspective_CheckedChanged);
            // 
            // buttonShape
            // 
            this.buttonShape.Location = new System.Drawing.Point(11, 265);
            this.buttonShape.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonShape.Name = "buttonShape";
            this.buttonShape.Size = new System.Drawing.Size(218, 25);
            this.buttonShape.TabIndex = 1;
            this.buttonShape.Text = "Нарисовать";
            this.buttonShape.UseVisualStyleBackColor = true;
            this.buttonShape.Click += new System.EventHandler(this.buttonShape_Click);
            // 
            // selectShape
            // 
            this.selectShape.FormattingEnabled = true;
            this.selectShape.Items.AddRange(new object[] {
            "Тетраэдр",
            "Гексаэдр",
            "Октаэдр"});
            this.selectShape.Location = new System.Drawing.Point(14, 85);
            this.selectShape.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.selectShape.Name = "selectShape";
            this.selectShape.Size = new System.Drawing.Size(190, 23);
            this.selectShape.TabIndex = 2;
            this.selectShape.SelectedIndexChanged += new System.EventHandler(this.comboBoxShape_SelectedIndexChanged);
            // 
            // buttonShift
            // 
            this.buttonShift.Enabled = false;
            this.buttonShift.Location = new System.Drawing.Point(8, 353);
            this.buttonShift.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(221, 25);
            this.buttonShift.TabIndex = 1;
            this.buttonShift.Text = "Сместить";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // buttonRotate
            // 
            this.buttonRotate.Enabled = false;
            this.buttonRotate.Location = new System.Drawing.Point(8, 421);
            this.buttonRotate.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(221, 25);
            this.buttonRotate.TabIndex = 1;
            this.buttonRotate.Text = "Повернуть";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // textAngle
            // 
            this.textAngle.Enabled = false;
            this.textAngle.Location = new System.Drawing.Point(66, 400);
            this.textAngle.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textAngle.MaxLength = 5;
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(47, 23);
            this.textAngle.TabIndex = 3;
            this.textAngle.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 402);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Угол:";
            // 
            // buttonScale
            // 
            this.buttonScale.Enabled = false;
            this.buttonScale.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonScale.Location = new System.Drawing.Point(8, 553);
            this.buttonScale.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(221, 25);
            this.buttonScale.TabIndex = 1;
            this.buttonScale.Text = "Отмасштабировать";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(161, 334);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Z:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(92, 334);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Y:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 334);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Х:";
            // 
            // textShiftZ
            // 
            this.textShiftZ.Enabled = false;
            this.textShiftZ.Location = new System.Drawing.Point(182, 332);
            this.textShiftZ.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textShiftZ.MaxLength = 5;
            this.textShiftZ.Name = "textShiftZ";
            this.textShiftZ.Size = new System.Drawing.Size(33, 23);
            this.textShiftZ.TabIndex = 5;
            this.textShiftZ.Text = "0";
            this.textShiftZ.TextChanged += new System.EventHandler(this.textShiftZ_TextChanged);
            // 
            // textShiftY
            // 
            this.textShiftY.Enabled = false;
            this.textShiftY.Location = new System.Drawing.Point(115, 332);
            this.textShiftY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textShiftY.MaxLength = 5;
            this.textShiftY.Name = "textShiftY";
            this.textShiftY.Size = new System.Drawing.Size(36, 23);
            this.textShiftY.TabIndex = 6;
            this.textShiftY.Text = "0";
            this.textShiftY.TextChanged += new System.EventHandler(this.textShiftY_TextChanged);
            // 
            // textShiftX
            // 
            this.textShiftX.Enabled = false;
            this.textShiftX.Location = new System.Drawing.Point(49, 332);
            this.textShiftX.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textShiftX.MaxLength = 5;
            this.textShiftX.Name = "textShiftX";
            this.textShiftX.Size = new System.Drawing.Size(36, 23);
            this.textShiftX.TabIndex = 7;
            this.textShiftX.Text = "0";
            this.textShiftX.TextChanged += new System.EventHandler(this.textShiftX_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(154, 472);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 14;
            this.label4.Text = "cZ:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(87, 470);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "cY:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 472);
            this.label7.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "cХ:";
            // 
            // textScaleZ
            // 
            this.textScaleZ.Enabled = false;
            this.textScaleZ.Location = new System.Drawing.Point(182, 470);
            this.textScaleZ.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textScaleZ.MaxLength = 5;
            this.textScaleZ.Name = "textScaleZ";
            this.textScaleZ.Size = new System.Drawing.Size(33, 23);
            this.textScaleZ.TabIndex = 11;
            this.textScaleZ.Text = "1";
            this.textScaleZ.TextChanged += new System.EventHandler(this.textScaleZ_TextChanged);
            // 
            // textScaleY
            // 
            this.textScaleY.Enabled = false;
            this.textScaleY.Location = new System.Drawing.Point(115, 470);
            this.textScaleY.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textScaleY.MaxLength = 5;
            this.textScaleY.Name = "textScaleY";
            this.textScaleY.Size = new System.Drawing.Size(36, 23);
            this.textScaleY.TabIndex = 12;
            this.textScaleY.Text = "1";
            this.textScaleY.TextChanged += new System.EventHandler(this.textScaleY_TextChanged);
            // 
            // textScaleX
            // 
            this.textScaleX.Enabled = false;
            this.textScaleX.Location = new System.Drawing.Point(49, 470);
            this.textScaleX.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.textScaleX.MaxLength = 5;
            this.textScaleX.Name = "textScaleX";
            this.textScaleX.Size = new System.Drawing.Size(36, 23);
            this.textScaleX.TabIndex = 13;
            this.textScaleX.Text = "1";
            this.textScaleX.TextChanged += new System.EventHandler(this.textScaleX_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(145, 402);
            this.label8.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ось:";
            // 
            // selectAxis
            // 
            this.selectAxis.Enabled = false;
            this.selectAxis.FormattingEnabled = true;
            this.selectAxis.Items.AddRange(new object[] {
            "X",
            "Y",
            "Z"});
            this.selectAxis.Location = new System.Drawing.Point(182, 398);
            this.selectAxis.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.selectAxis.Name = "selectAxis";
            this.selectAxis.Size = new System.Drawing.Size(33, 23);
            this.selectAxis.TabIndex = 2;
            this.selectAxis.SelectedIndexChanged += new System.EventHandler(this.selectAxis_SelectedIndexChanged);
            // 
            // btnShowAxis
            // 
            this.btnShowAxis.Location = new System.Drawing.Point(974, 94);
            this.btnShowAxis.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnShowAxis.Name = "btnShowAxis";
            this.btnShowAxis.Size = new System.Drawing.Size(102, 25);
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
            this.rbIsometric.Location = new System.Drawing.Point(974, 47);
            this.rbIsometric.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rbIsometric.Name = "rbIsometric";
            this.rbIsometric.Size = new System.Drawing.Size(173, 19);
            this.rbIsometric.TabIndex = 17;
            this.rbIsometric.Text = "Изометрическая проекция";
            this.rbIsometric.UseVisualStyleBackColor = false;
            this.rbIsometric.CheckedChanged += new System.EventHandler(this.rbIsometric_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 491);
            this.label9.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 15);
            this.label9.TabIndex = 16;
            this.label9.Text = "Относительно:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbCenter);
            this.panel1.Controls.Add(this.rbWorldCenter);
            this.panel1.Location = new System.Drawing.Point(8, 509);
            this.panel1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(190, 41);
            this.panel1.TabIndex = 19;
            // 
            // rbCenter
            // 
            this.rbCenter.AutoSize = true;
            this.rbCenter.Location = new System.Drawing.Point(8, 25);
            this.rbCenter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rbCenter.Name = "rbCenter";
            this.rbCenter.Size = new System.Drawing.Size(105, 19);
            this.rbCenter.TabIndex = 0;
            this.rbCenter.Text = "Центр фигуры";
            this.rbCenter.UseVisualStyleBackColor = true;
            // 
            // rbWorldCenter
            // 
            this.rbWorldCenter.AutoSize = true;
            this.rbWorldCenter.Checked = true;
            this.rbWorldCenter.Location = new System.Drawing.Point(8, 6);
            this.rbWorldCenter.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rbWorldCenter.Name = "rbWorldCenter";
            this.rbWorldCenter.Size = new System.Drawing.Size(57, 19);
            this.rbWorldCenter.TabIndex = 0;
            this.rbWorldCenter.TabStop = true;
            this.rbWorldCenter.Text = "(0,0,0)";
            this.rbWorldCenter.UseVisualStyleBackColor = true;
            this.rbWorldCenter.CheckedChanged += new System.EventHandler(this.rbWorldCenter_CheckedChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.SystemColors.Control;
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLoad.Location = new System.Drawing.Point(8, 7);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(221, 25);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Загрузить из файла";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnChoosePlot
            // 
            this.btnChoosePlot.Location = new System.Drawing.Point(38, 13);
            this.btnChoosePlot.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnChoosePlot.Name = "btnChoosePlot";
            this.btnChoosePlot.Size = new System.Drawing.Size(146, 28);
            this.btnChoosePlot.TabIndex = 0;
            this.btnChoosePlot.Text = "Выбрать функцию";
            this.btnChoosePlot.UseVisualStyleBackColor = true;
            this.btnChoosePlot.Click += new System.EventHandler(this.btnChoosePlot_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageShape);
            this.tabControl.Controls.Add(this.tabPagePlot);
            this.tabControl.Controls.Add(this.tabPageRotate);
            this.tabControl.Location = new System.Drawing.Point(8, 49);
            this.tabControl.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(224, 212);
            this.tabControl.TabIndex = 21;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageShape
            // 
            this.tabPageShape.Controls.Add(this.selectShape);
            this.tabPageShape.Location = new System.Drawing.Point(4, 24);
            this.tabPageShape.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPageShape.Name = "tabPageShape";
            this.tabPageShape.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPageShape.Size = new System.Drawing.Size(216, 184);
            this.tabPageShape.TabIndex = 0;
            this.tabPageShape.Text = "Фигура";
            this.tabPageShape.UseVisualStyleBackColor = true;
            // 
            // tabPagePlot
            // 
            this.tabPagePlot.Controls.Add(this.etY1);
            this.tabPagePlot.Controls.Add(this.etX1);
            this.tabPagePlot.Controls.Add(this.etSplit);
            this.tabPagePlot.Controls.Add(this.etY0);
            this.tabPagePlot.Controls.Add(this.etX0);
            this.tabPagePlot.Controls.Add(this.label16);
            this.tabPagePlot.Controls.Add(this.label13);
            this.tabPagePlot.Controls.Add(this.label17);
            this.tabPagePlot.Controls.Add(this.label12);
            this.tabPagePlot.Controls.Add(this.label15);
            this.tabPagePlot.Controls.Add(this.label11);
            this.tabPagePlot.Controls.Add(this.label14);
            this.tabPagePlot.Controls.Add(this.label10);
            this.tabPagePlot.Controls.Add(this.btnChoosePlot);
            this.tabPagePlot.Location = new System.Drawing.Point(4, 24);
            this.tabPagePlot.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPagePlot.Name = "tabPagePlot";
            this.tabPagePlot.Padding = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.tabPagePlot.Size = new System.Drawing.Size(216, 184);
            this.tabPagePlot.TabIndex = 1;
            this.tabPagePlot.Text = "График";
            this.tabPagePlot.UseVisualStyleBackColor = true;
            // 
            // etY1
            // 
            this.etY1.Location = new System.Drawing.Point(120, 110);
            this.etY1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.etY1.MaxLength = 6;
            this.etY1.Name = "etY1";
            this.etY1.PlaceholderText = "y1";
            this.etY1.Size = new System.Drawing.Size(42, 23);
            this.etY1.TabIndex = 2;
            // 
            // etX1
            // 
            this.etX1.Location = new System.Drawing.Point(120, 80);
            this.etX1.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.etX1.MaxLength = 6;
            this.etX1.Name = "etX1";
            this.etX1.PlaceholderText = "x1";
            this.etX1.Size = new System.Drawing.Size(42, 23);
            this.etX1.TabIndex = 2;
            // 
            // etSplit
            // 
            this.etSplit.Location = new System.Drawing.Point(144, 152);
            this.etSplit.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.etSplit.MaxLength = 6;
            this.etSplit.Name = "etSplit";
            this.etSplit.Size = new System.Drawing.Size(49, 23);
            this.etSplit.TabIndex = 2;
            // 
            // etY0
            // 
            this.etY0.Location = new System.Drawing.Point(55, 110);
            this.etY0.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.etY0.MaxLength = 6;
            this.etY0.Name = "etY0";
            this.etY0.PlaceholderText = "y0";
            this.etY0.Size = new System.Drawing.Size(42, 23);
            this.etY0.TabIndex = 2;
            // 
            // etX0
            // 
            this.etX0.Location = new System.Drawing.Point(55, 80);
            this.etX0.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.etX0.MaxLength = 6;
            this.etX0.Name = "etX0";
            this.etX0.PlaceholderText = "x0";
            this.etX0.Size = new System.Drawing.Size(42, 23);
            this.etX0.TabIndex = 2;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label16.Location = new System.Drawing.Point(157, 102);
            this.label16.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(21, 32);
            this.label16.TabIndex = 1;
            this.label16.Text = "]";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label13.Location = new System.Drawing.Point(157, 73);
            this.label13.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(21, 32);
            this.label13.TabIndex = 1;
            this.label13.Text = "]";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label17.Location = new System.Drawing.Point(23, 155);
            this.label17.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "Кол-во разбиений:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(41, 56);
            this.label12.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 15);
            this.label12.TabIndex = 1;
            this.label12.Text = "Диапазоны отсечения:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label15.Location = new System.Drawing.Point(97, 102);
            this.label15.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(19, 32);
            this.label15.TabIndex = 1;
            this.label15.Text = ",";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(41, 102);
            this.label11.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 32);
            this.label11.TabIndex = 1;
            this.label11.Text = "[";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label14.Location = new System.Drawing.Point(97, 73);
            this.label14.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(19, 32);
            this.label14.TabIndex = 1;
            this.label14.Text = ",";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(41, 73);
            this.label10.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(21, 32);
            this.label10.TabIndex = 1;
            this.label10.Text = "[";
            // 
            // tabPageRotate
            // 
            this.tabPageRotate.Controls.Add(this.axizRotate);
            this.tabPageRotate.Controls.Add(this.Former);
            this.tabPageRotate.Controls.Add(this.getDiv);
            this.tabPageRotate.Controls.Add(this.Divisions);
            this.tabPageRotate.Controls.Add(this.AddPoint);
            this.tabPageRotate.Controls.Add(this.getZ);
            this.tabPageRotate.Controls.Add(this.getY);
            this.tabPageRotate.Controls.Add(this.getX);
            this.tabPageRotate.Controls.Add(this.axZ);
            this.tabPageRotate.Controls.Add(this.axY);
            this.tabPageRotate.Controls.Add(this.axX);
            this.tabPageRotate.Location = new System.Drawing.Point(4, 24);
            this.tabPageRotate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabPageRotate.Name = "tabPageRotate";
            this.tabPageRotate.Size = new System.Drawing.Size(216, 184);
            this.tabPageRotate.TabIndex = 2;
            this.tabPageRotate.Text = "Фигура вращения";
            this.tabPageRotate.UseVisualStyleBackColor = true;
            // 
            // axizRotate
            // 
            this.axizRotate.FormattingEnabled = true;
            this.axizRotate.Items.AddRange(new object[] {
            "OX",
            "OY",
            "OZ"});
            this.axizRotate.Location = new System.Drawing.Point(47, 154);
            this.axizRotate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.axizRotate.Name = "axizRotate";
            this.axizRotate.Size = new System.Drawing.Size(134, 23);
            this.axizRotate.TabIndex = 23;
            this.axizRotate.SelectedIndexChanged += new System.EventHandler(this.axizRotate_SelectedIndexChanged);
            // 
            // Former
            // 
            this.Former.AutoSize = true;
            this.Former.Location = new System.Drawing.Point(48, 137);
            this.Former.Name = "Former";
            this.Former.Size = new System.Drawing.Size(127, 15);
            this.Former.TabIndex = 26;
            this.Former.Text = "Задать ось вращения:";
            // 
            // getDiv
            // 
            this.getDiv.Location = new System.Drawing.Point(153, 102);
            this.getDiv.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getDiv.Name = "getDiv";
            this.getDiv.Size = new System.Drawing.Size(43, 23);
            this.getDiv.TabIndex = 25;
            // 
            // Divisions
            // 
            this.Divisions.AutoSize = true;
            this.Divisions.Location = new System.Drawing.Point(31, 104);
            this.Divisions.Name = "Divisions";
            this.Divisions.Size = new System.Drawing.Size(107, 15);
            this.Divisions.TabIndex = 24;
            this.Divisions.Text = "Число разбиений:";
            // 
            // AddPoint
            // 
            this.AddPoint.AutoSize = true;
            this.AddPoint.Location = new System.Drawing.Point(47, 64);
            this.AddPoint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AddPoint.Name = "AddPoint";
            this.AddPoint.Size = new System.Drawing.Size(132, 26);
            this.AddPoint.TabIndex = 23;
            this.AddPoint.Text = "Добавить точку";
            this.AddPoint.UseVisualStyleBackColor = true;
            this.AddPoint.Click += new System.EventHandler(this.AddPoint_Click);
            // 
            // getZ
            // 
            this.getZ.Location = new System.Drawing.Point(155, 31);
            this.getZ.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getZ.Name = "getZ";
            this.getZ.Size = new System.Drawing.Size(25, 23);
            this.getZ.TabIndex = 5;
            // 
            // getY
            // 
            this.getY.Location = new System.Drawing.Point(104, 31);
            this.getY.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getY.Name = "getY";
            this.getY.Size = new System.Drawing.Size(25, 23);
            this.getY.TabIndex = 4;
            // 
            // getX
            // 
            this.getX.Location = new System.Drawing.Point(47, 31);
            this.getX.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.getX.Name = "getX";
            this.getX.Size = new System.Drawing.Size(25, 23);
            this.getX.TabIndex = 3;
            // 
            // axZ
            // 
            this.axZ.AutoSize = true;
            this.axZ.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.axZ.Location = new System.Drawing.Point(156, 6);
            this.axZ.Name = "axZ";
            this.axZ.Size = new System.Drawing.Size(23, 25);
            this.axZ.TabIndex = 2;
            this.axZ.Text = "Z";
            // 
            // axY
            // 
            this.axY.AutoSize = true;
            this.axY.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.axY.Location = new System.Drawing.Point(104, 6);
            this.axY.Name = "axY";
            this.axY.Size = new System.Drawing.Size(23, 25);
            this.axY.TabIndex = 1;
            this.axY.Text = "Y";
            // 
            // axX
            // 
            this.axX.AutoSize = true;
            this.axX.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.axX.Location = new System.Drawing.Point(47, 6);
            this.axX.Name = "axX";
            this.axX.Size = new System.Drawing.Size(23, 25);
            this.axX.TabIndex = 0;
            this.axX.Text = "X";
            // 
            // pbFormula
            // 
            this.pbFormula.BackColor = System.Drawing.Color.White;
            this.pbFormula.Location = new System.Drawing.Point(242, 7);
            this.pbFormula.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.pbFormula.Name = "pbFormula";
            this.pbFormula.Size = new System.Drawing.Size(202, 43);
            this.pbFormula.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFormula.TabIndex = 22;
            this.pbFormula.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "txt";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Текстовые файлы|*.txt;";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "TXT|*.txt";
            // 
            // rbDimetric
            // 
            this.rbDimetric.AutoSize = true;
            this.rbDimetric.BackColor = System.Drawing.Color.White;
            this.rbDimetric.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rbDimetric.Location = new System.Drawing.Point(974, 67);
            this.rbDimetric.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.rbDimetric.Name = "rbDimetric";
            this.rbDimetric.Size = new System.Drawing.Size(167, 19);
            this.rbDimetric.TabIndex = 17;
            this.rbDimetric.Text = "Прямая проекция";
            this.rbDimetric.UseVisualStyleBackColor = false;
            this.rbDimetric.CheckedChanged += new System.EventHandler(this.rbDimetric_CheckedChanged_1);
            // 
            // btnShowPoints
            // 
            this.btnShowPoints.Location = new System.Drawing.Point(1078, 94);
            this.btnShowPoints.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.btnShowPoints.Name = "btnShowPoints";
            this.btnShowPoints.Size = new System.Drawing.Size(109, 25);
            this.btnShowPoints.TabIndex = 18;
            this.btnShowPoints.Text = "Показать точки";
            this.btnShowPoints.UseVisualStyleBackColor = true;
            this.btnShowPoints.Click += new System.EventHandler(this.btnShowPoints_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1214, 591);
            this.Controls.Add(this.pbFormula);
            this.Controls.Add(this.buttonShape);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnShowPoints);
            this.Controls.Add(this.btnShowAxis);
            this.Controls.Add(this.rbPerspective);
            this.Controls.Add(this.rbIsometric);
            this.Controls.Add(this.rbDimetric);
            this.Controls.Add(this.rbAxonometric);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textScaleZ);
            this.Controls.Add(this.textScaleY);
            this.Controls.Add(this.textScaleX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textShiftZ);
            this.Controls.Add(this.textShiftY);
            this.Controls.Add(this.textShiftX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textAngle);
            this.Controls.Add(this.selectAxis);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.buttonShift);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(1, 1, 1, 1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Построение трёхмерных моделей";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageShape.ResumeLayout(false);
            this.tabPagePlot.ResumeLayout(false);
            this.tabPagePlot.PerformLayout();
            this.tabPageRotate.ResumeLayout(false);
            this.tabPageRotate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFormula)).EndInit();
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
        private System.Windows.Forms.RadioButton rbAxonometric;
        private System.Windows.Forms.Button btnShowAxis;
        private System.Windows.Forms.RadioButton rbIsometric;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbCenter;
        private System.Windows.Forms.RadioButton rbWorldCenter;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnChoosePlot;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageShape;
        private System.Windows.Forms.TabPage tabPagePlot;
        private System.Windows.Forms.TextBox etY1;
        private System.Windows.Forms.TextBox etX1;
        private System.Windows.Forms.TextBox etSplit;
        private System.Windows.Forms.TextBox etY0;
        private System.Windows.Forms.TextBox etX0;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox pbFormula;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TabPage tabPageRotate;
        private System.Windows.Forms.ComboBox axizRotate;
        private System.Windows.Forms.Label Former;
        private System.Windows.Forms.TextBox getDiv;
        private System.Windows.Forms.Label Divisions;
        private System.Windows.Forms.Button AddPoint;
        private System.Windows.Forms.TextBox getZ;
        private System.Windows.Forms.TextBox getY;
        private System.Windows.Forms.TextBox getX;
        private System.Windows.Forms.Label axZ;
        private System.Windows.Forms.Label axY;
        private System.Windows.Forms.Label axX;
        private System.Windows.Forms.RadioButton rbDimetric;
        private System.Windows.Forms.Button btnShowPoints;
    }
}


