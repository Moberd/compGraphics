
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFrac = new System.Windows.Forms.Button();
            this.buttonMountains = new System.Windows.Forms.Button();
            this.buttonBezier = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFrac
            // 
            this.buttonFrac.Location = new System.Drawing.Point(53, 40);
            this.buttonFrac.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFrac.Name = "buttonFrac";
            this.buttonFrac.Size = new System.Drawing.Size(136, 32);
            this.buttonFrac.TabIndex = 0;
            this.buttonFrac.Text = "Рисовать фракталы";
            this.buttonFrac.UseVisualStyleBackColor = true;
            this.buttonFrac.Click += new System.EventHandler(this.buttonFrac_Click);
            // 
            // buttonMountains
            // 
            this.buttonMountains.Location = new System.Drawing.Point(53, 74);
            this.buttonMountains.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonMountains.Name = "buttonMountains";
            this.buttonMountains.Size = new System.Drawing.Size(136, 32);
            this.buttonMountains.TabIndex = 0;
            this.buttonMountains.Text = "Рисовать горы";
            this.buttonMountains.UseVisualStyleBackColor = true;
            this.buttonMountains.Click += new System.EventHandler(this.buttonMountains_Click);
            // 
            // buttonBezier
            // 
            this.buttonBezier.Location = new System.Drawing.Point(53, 109);
            this.buttonBezier.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBezier.Name = "buttonBezier";
            this.buttonBezier.Size = new System.Drawing.Size(136, 32);
            this.buttonBezier.TabIndex = 0;
            this.buttonBezier.Text = "Рисовать кривые Безье";
            this.buttonBezier.UseVisualStyleBackColor = true;
            this.buttonBezier.Click += new System.EventHandler(this.buttonBezier_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 163);
            this.Controls.Add(this.buttonBezier);
            this.Controls.Add(this.buttonMountains);
            this.Controls.Add(this.buttonFrac);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Сделай выбор, Нео";
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button buttonFrac;
        private System.Windows.Forms.Button buttonMountains;
        private System.Windows.Forms.Button buttonBezier;
    }
}

