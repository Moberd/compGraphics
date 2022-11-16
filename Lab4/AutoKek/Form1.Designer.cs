
namespace AutoKek
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
            this.buttonPolygon = new System.Windows.Forms.Button();
            this.comboBoxShape = new System.Windows.Forms.ComboBox();
            this.buttonShift = new System.Windows.Forms.Button();
            this.textShiftX = new System.Windows.Forms.TextBox();
            this.textShiftY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonRotate = new System.Windows.Forms.Button();
            this.textAngle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonScale = new System.Windows.Forms.Button();
            this.textScaleX = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonСhooseCentre = new System.Windows.Forms.Button();
            this.labelChoodePoint = new System.Windows.Forms.Label();
            this.buttonRotateLine = new System.Windows.Forms.Button();
            this.buttonCrossLines = new System.Windows.Forms.Button();
            this.buttonIsPointInPolygon = new System.Windows.Forms.Button();
            this.buttonClassifyPoint = new System.Windows.Forms.Button();
            this.textScaleY = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.labelClassifyPoint = new System.Windows.Forms.Label();
            this.labelConvexPolygon = new System.Windows.Forms.Label();
            this.labelPointInPolygon = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Right;
            this.canvas.Location = new System.Drawing.Point(157, 0);
            this.canvas.Margin = new System.Windows.Forms.Padding(2);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(780, 468);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // buttonPolygon
            // 
            this.buttonPolygon.Location = new System.Drawing.Point(13, 81);
            this.buttonPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.buttonPolygon.Name = "buttonPolygon";
            this.buttonPolygon.Size = new System.Drawing.Size(135, 23);
            this.buttonPolygon.TabIndex = 1;
            this.buttonPolygon.Text = "Нарисовать что-нибудь";
            this.buttonPolygon.UseVisualStyleBackColor = true;
            this.buttonPolygon.Click += new System.EventHandler(this.buttonPolygon_Click);
            // 
            // comboBoxShape
            // 
            this.comboBoxShape.Enabled = false;
            this.comboBoxShape.FormattingEnabled = true;
            this.comboBoxShape.Items.AddRange(new object[] { "Полигон", "Отрезок", "Точка" });
            this.comboBoxShape.Location = new System.Drawing.Point(13, 107);
            this.comboBoxShape.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxShape.Name = "comboBoxShape";
            this.comboBoxShape.Size = new System.Drawing.Size(137, 21);
            this.comboBoxShape.TabIndex = 2;
            this.comboBoxShape.SelectedIndexChanged += new System.EventHandler(this.comboBoxShape_SelectedIndexChanged);
            // 
            // buttonShift
            // 
            this.buttonShift.Enabled = false;
            this.buttonShift.Location = new System.Drawing.Point(13, 161);
            this.buttonShift.Margin = new System.Windows.Forms.Padding(2);
            this.buttonShift.Name = "buttonShift";
            this.buttonShift.Size = new System.Drawing.Size(135, 23);
            this.buttonShift.TabIndex = 1;
            this.buttonShift.Text = "Сместить";
            this.buttonShift.UseVisualStyleBackColor = true;
            this.buttonShift.Click += new System.EventHandler(this.buttonShift_Click);
            // 
            // textShiftX
            // 
            this.textShiftX.Enabled = false;
            this.textShiftX.Location = new System.Drawing.Point(33, 142);
            this.textShiftX.Margin = new System.Windows.Forms.Padding(2);
            this.textShiftX.MaxLength = 5;
            this.textShiftX.Name = "textShiftX";
            this.textShiftX.Size = new System.Drawing.Size(43, 20);
            this.textShiftX.TabIndex = 3;
            // 
            // textShiftY
            // 
            this.textShiftY.Enabled = false;
            this.textShiftY.Location = new System.Drawing.Point(107, 142);
            this.textShiftY.Margin = new System.Windows.Forms.Padding(2);
            this.textShiftY.MaxLength = 5;
            this.textShiftY.Name = "textShiftY";
            this.textShiftY.Size = new System.Drawing.Size(43, 20);
            this.textShiftY.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Х:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(87, 144);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y:";
            // 
            // buttonRotate
            // 
            this.buttonRotate.Enabled = false;
            this.buttonRotate.Location = new System.Drawing.Point(13, 206);
            this.buttonRotate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRotate.Name = "buttonRotate";
            this.buttonRotate.Size = new System.Drawing.Size(135, 23);
            this.buttonRotate.TabIndex = 1;
            this.buttonRotate.Text = "Повернуть";
            this.buttonRotate.UseVisualStyleBackColor = true;
            this.buttonRotate.Click += new System.EventHandler(this.buttonRotate_Click);
            // 
            // textAngle
            // 
            this.textAngle.Enabled = false;
            this.textAngle.Location = new System.Drawing.Point(67, 187);
            this.textAngle.Margin = new System.Windows.Forms.Padding(2);
            this.textAngle.MaxLength = 5;
            this.textAngle.Name = "textAngle";
            this.textAngle.Size = new System.Drawing.Size(83, 20);
            this.textAngle.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 189);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Градусы:";
            // 
            // buttonScale
            // 
            this.buttonScale.Enabled = false;
            this.buttonScale.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonScale.Location = new System.Drawing.Point(13, 251);
            this.buttonScale.Margin = new System.Windows.Forms.Padding(2);
            this.buttonScale.Name = "buttonScale";
            this.buttonScale.Size = new System.Drawing.Size(135, 23);
            this.buttonScale.TabIndex = 1;
            this.buttonScale.Text = "Отмасштабировать";
            this.buttonScale.UseVisualStyleBackColor = true;
            this.buttonScale.Click += new System.EventHandler(this.buttonScale_Click);
            // 
            // textScaleX
            // 
            this.textScaleX.Enabled = false;
            this.textScaleX.Location = new System.Drawing.Point(37, 232);
            this.textScaleX.Margin = new System.Windows.Forms.Padding(2);
            this.textScaleX.MaxLength = 5;
            this.textScaleX.Name = "textScaleX";
            this.textScaleX.Size = new System.Drawing.Size(43, 20);
            this.textScaleX.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 234);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "cХ:";
            // 
            // buttonСhooseCentre
            // 
            this.buttonСhooseCentre.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonСhooseCentre.Enabled = false;
            this.buttonСhooseCentre.Location = new System.Drawing.Point(35, 33);
            this.buttonСhooseCentre.Margin = new System.Windows.Forms.Padding(2);
            this.buttonСhooseCentre.Name = "buttonСhooseCentre";
            this.buttonСhooseCentre.Size = new System.Drawing.Size(87, 23);
            this.buttonСhooseCentre.TabIndex = 1;
            this.buttonСhooseCentre.Text = "Выбрать центр";
            this.buttonСhooseCentre.UseVisualStyleBackColor = false;
            this.buttonСhooseCentre.Visible = false;
            this.buttonСhooseCentre.Click += new System.EventHandler(this.buttonСhooseCentre_Click);
            // 
            // labelChoodePoint
            // 
            this.labelChoodePoint.AutoSize = true;
            this.labelChoodePoint.BackColor = System.Drawing.SystemColors.Control;
            this.labelChoodePoint.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.labelChoodePoint.Location = new System.Drawing.Point(7, 4);
            this.labelChoodePoint.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelChoodePoint.Name = "labelChoodePoint";
            this.labelChoodePoint.Size = new System.Drawing.Size(205, 32);
            this.labelChoodePoint.TabIndex = 4;
            this.labelChoodePoint.Text = "Выберите точку";
            this.labelChoodePoint.Visible = false;
            // 
            // buttonRotateLine
            // 
            this.buttonRotateLine.Enabled = false;
            this.buttonRotateLine.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonRotateLine.Location = new System.Drawing.Point(13, 292);
            this.buttonRotateLine.Margin = new System.Windows.Forms.Padding(2);
            this.buttonRotateLine.Name = "buttonRotateLine";
            this.buttonRotateLine.Size = new System.Drawing.Size(135, 23);
            this.buttonRotateLine.TabIndex = 1;
            this.buttonRotateLine.Text = "Повернуть ребро на 90º";
            this.buttonRotateLine.UseVisualStyleBackColor = true;
            this.buttonRotateLine.Click += new System.EventHandler(this.buttonRotateLine_Click);
            // 
            // buttonCrossLines
            // 
            this.buttonCrossLines.Enabled = false;
            this.buttonCrossLines.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonCrossLines.Location = new System.Drawing.Point(13, 318);
            this.buttonCrossLines.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCrossLines.Name = "buttonCrossLines";
            this.buttonCrossLines.Size = new System.Drawing.Size(135, 23);
            this.buttonCrossLines.TabIndex = 1;
            this.buttonCrossLines.Text = "Пересечь рёбра";
            this.buttonCrossLines.UseVisualStyleBackColor = true;
            this.buttonCrossLines.Click += new System.EventHandler(this.buttonCrossLines_Click);
            // 
            // buttonIsPointInPolygon
            // 
            this.buttonIsPointInPolygon.Enabled = false;
            this.buttonIsPointInPolygon.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonIsPointInPolygon.Location = new System.Drawing.Point(13, 361);
            this.buttonIsPointInPolygon.Margin = new System.Windows.Forms.Padding(2);
            this.buttonIsPointInPolygon.Name = "buttonIsPointInPolygon";
            this.buttonIsPointInPolygon.Size = new System.Drawing.Size(135, 44);
            this.buttonIsPointInPolygon.TabIndex = 1;
            this.buttonIsPointInPolygon.Text = "Проверить принадлежность точки полигону";
            this.buttonIsPointInPolygon.UseVisualStyleBackColor = true;
            this.buttonIsPointInPolygon.Click += new System.EventHandler(this.buttonIsPointInPolygon_Click);
            // 
            // buttonClassifyPoint
            // 
            this.buttonClassifyPoint.Enabled = false;
            this.buttonClassifyPoint.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.buttonClassifyPoint.Location = new System.Drawing.Point(13, 407);
            this.buttonClassifyPoint.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClassifyPoint.Name = "buttonClassifyPoint";
            this.buttonClassifyPoint.Size = new System.Drawing.Size(135, 44);
            this.buttonClassifyPoint.TabIndex = 1;
            this.buttonClassifyPoint.Text = "Классифицировать положение точки относительно ребра";
            this.buttonClassifyPoint.UseVisualStyleBackColor = true;
            this.buttonClassifyPoint.Click += new System.EventHandler(this.buttonClassifyPoint_Click);
            // 
            // textScaleY
            // 
            this.textScaleY.Enabled = false;
            this.textScaleY.Location = new System.Drawing.Point(107, 232);
            this.textScaleY.Margin = new System.Windows.Forms.Padding(2);
            this.textScaleY.MaxLength = 5;
            this.textScaleY.Name = "textScaleY";
            this.textScaleY.Size = new System.Drawing.Size(43, 20);
            this.textScaleY.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(82, 233);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "cY:";
            // 
            // labelClassifyPoint
            // 
            this.labelClassifyPoint.AutoSize = true;
            this.labelClassifyPoint.Location = new System.Drawing.Point(728, 13);
            this.labelClassifyPoint.Name = "labelClassifyPoint";
            this.labelClassifyPoint.Size = new System.Drawing.Size(0, 15);
            this.labelClassifyPoint.TabIndex = 5;
            // 
            // labelConvexPolygon
            // 
            this.labelConvexPolygon.AutoSize = true;
            this.labelConvexPolygon.Location = new System.Drawing.Point(728, 13);
            this.labelConvexPolygon.Name = "labelConvexPolygon";
            this.labelConvexPolygon.Size = new System.Drawing.Size(0, 15);
            this.labelConvexPolygon.TabIndex = 6;
            // 
            // labelPointInPolygon
            // 
            this.labelPointInPolygon.AutoSize = true;
            this.labelPointInPolygon.Location = new System.Drawing.Point(728, 33);
            this.labelPointInPolygon.Name = "labelPointInPolygon";
            this.labelPointInPolygon.Size = new System.Drawing.Size(0, 15);
            this.labelPointInPolygon.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(40, 62);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 19);
            this.button1.TabIndex = 8;
            this.button1.Text = "Центр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(937, 468);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelPointInPolygon);
            this.Controls.Add(this.labelConvexPolygon);
            this.Controls.Add(this.labelClassifyPoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelChoodePoint);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textScaleY);
            this.Controls.Add(this.textScaleX);
            this.Controls.Add(this.textAngle);
            this.Controls.Add(this.textShiftY);
            this.Controls.Add(this.textShiftX);
            this.Controls.Add(this.comboBoxShape);
            this.Controls.Add(this.buttonClassifyPoint);
            this.Controls.Add(this.buttonIsPointInPolygon);
            this.Controls.Add(this.buttonCrossLines);
            this.Controls.Add(this.buttonRotateLine);
            this.Controls.Add(this.buttonScale);
            this.Controls.Add(this.buttonСhooseCentre);
            this.Controls.Add(this.buttonRotate);
            this.Controls.Add(this.buttonShift);
            this.Controls.Add(this.buttonPolygon);
            this.Controls.Add(this.canvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Алгем (на минималках)";
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button button1;

        #endregion

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button buttonPolygon;
        private System.Windows.Forms.ComboBox comboBoxShape;
        private System.Windows.Forms.Button buttonShift;
        private System.Windows.Forms.TextBox textShiftX;
        private System.Windows.Forms.TextBox textShiftY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonRotate;
        private System.Windows.Forms.TextBox textAngle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonScale;
        private System.Windows.Forms.TextBox textScaleX;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonСhooseCentre;
        private System.Windows.Forms.Label labelChoodePoint;
        private System.Windows.Forms.Button buttonRotateLine;
        private System.Windows.Forms.Button buttonCrossLines;
        private System.Windows.Forms.Button buttonIsPointInPolygon;
        private System.Windows.Forms.Button buttonClassifyPoint;
        private System.Windows.Forms.TextBox textScaleY;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelClassifyPoint;
        private System.Windows.Forms.Label labelConvexPolygon;
        private System.Windows.Forms.Label labelPointInPolygon;
    }
}

