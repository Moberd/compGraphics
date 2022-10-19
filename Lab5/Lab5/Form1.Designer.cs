
namespace Lab5
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFrac = new System.Windows.Forms.Button();
            this.buttonMountains = new System.Windows.Forms.Button();
            this.buttonBezier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(149, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Я хочу:";
            // 
            // buttonFrac
            // 
            this.buttonFrac.Location = new System.Drawing.Point(89, 76);
            this.buttonFrac.Name = "buttonFrac";
            this.buttonFrac.Size = new System.Drawing.Size(226, 61);
            this.buttonFrac.TabIndex = 0;
            this.buttonFrac.Text = "Рисовать фракталы";
            this.buttonFrac.UseVisualStyleBackColor = true;
            this.buttonFrac.Click += new System.EventHandler(this.buttonFrac_Click);
            // 
            // buttonMountains
            // 
            this.buttonMountains.Location = new System.Drawing.Point(89, 143);
            this.buttonMountains.Name = "buttonMountains";
            this.buttonMountains.Size = new System.Drawing.Size(226, 61);
            this.buttonMountains.TabIndex = 0;
            this.buttonMountains.Text = "Рисовать горы";
            this.buttonMountains.UseVisualStyleBackColor = true;
            this.buttonMountains.Click += new System.EventHandler(this.buttonMountains_Click);
            // 
            // buttonBezier
            // 
            this.buttonBezier.Location = new System.Drawing.Point(89, 210);
            this.buttonBezier.Name = "buttonBezier";
            this.buttonBezier.Size = new System.Drawing.Size(226, 61);
            this.buttonBezier.TabIndex = 0;
            this.buttonBezier.Text = "Рисовать кривые Безье";
            this.buttonBezier.UseVisualStyleBackColor = true;
            this.buttonBezier.Click += new System.EventHandler(this.buttonBezier_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 314);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonBezier);
            this.Controls.Add(this.buttonMountains);
            this.Controls.Add(this.buttonFrac);
            this.Name = "Form1";
            this.Text = "Сделай выбор, Нео";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonFrac;
        private System.Windows.Forms.Button buttonMountains;
        private System.Windows.Forms.Button buttonBezier;
    }
}

