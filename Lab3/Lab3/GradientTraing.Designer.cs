namespace Lab3Rastr
{
    partial class GradientTraing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            this.color1 = new System.Windows.Forms.Button();
            this.color2 = new System.Windows.Forms.Button();
            this.color3 = new System.Windows.Forms.Button();
            this.Clear = new System.Windows.Forms.Button();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).BeginInit();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.Color.White;
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(10, 9);
            this.canvas.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(379, 460);
            this.canvas.TabIndex = 0;
            this.canvas.TabStop = false;
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // color1
            // 
            this.color1.Location = new System.Drawing.Point(397, 46);
            this.color1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.color1.Name = "color1";
            this.color1.Size = new System.Drawing.Size(149, 47);
            this.color1.TabIndex = 1;
            this.color1.UseVisualStyleBackColor = true;
            this.color1.Click += new System.EventHandler(this.color1_Click);
            // 
            // color2
            // 
            this.color2.Location = new System.Drawing.Point(397, 99);
            this.color2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.color2.Name = "color2";
            this.color2.Size = new System.Drawing.Size(149, 47);
            this.color2.TabIndex = 2;
            this.color2.UseVisualStyleBackColor = true;
            this.color2.Click += new System.EventHandler(this.color2_Click);
            // 
            // color3
            // 
            this.color3.Location = new System.Drawing.Point(397, 152);
            this.color3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.color3.Name = "color3";
            this.color3.Size = new System.Drawing.Size(149, 47);
            this.color3.TabIndex = 3;
            this.color3.UseVisualStyleBackColor = true;
            this.color3.Click += new System.EventHandler(this.color3_Click);
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(397, 423);
            this.Clear.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(149, 46);
            this.Clear.TabIndex = 4;
            this.Clear.Text = "Отчистить";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Цвета треугольника";
            // 
            // GradientTraing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 482);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.color3);
            this.Controls.Add(this.color2);
            this.Controls.Add(this.color1);
            this.Controls.Add(this.canvas);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "GradientTraing";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Градиентное окрашивание треугольника";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GradientTraing_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.canvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.ColorDialog colorDialog;

        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Button color1;
        private System.Windows.Forms.Button color2;
        private System.Windows.Forms.Button color3;
        private System.Windows.Forms.Button Clear;

        #endregion

        private Label label1;
    }
}