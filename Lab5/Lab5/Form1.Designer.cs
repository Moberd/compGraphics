
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
            this.buttonFrac.Location = new System.Drawing.Point(53, 30);
            this.buttonFrac.Margin = new System.Windows.Forms.Padding(2);
            this.buttonFrac.Name = "buttonFrac";
            this.buttonFrac.Size = new System.Drawing.Size(136, 70);
            this.buttonFrac.TabIndex = 0;
            this.buttonFrac.Text = "Фрактальные узоры";
            this.buttonFrac.UseVisualStyleBackColor = true;
            this.buttonFrac.Click += new System.EventHandler(this.buttonFrac_Click);
            // 
            // buttonMountains
            // 
            this.buttonMountains.Location = new System.Drawing.Point(53, 104);
            this.buttonMountains.Margin = new System.Windows.Forms.Padding(2);
            this.buttonMountains.Name = "buttonMountains";
            this.buttonMountains.Size = new System.Drawing.Size(136, 70);
            this.buttonMountains.TabIndex = 1;
            this.buttonMountains.Text = "Горный массив";
            this.buttonMountains.UseVisualStyleBackColor = true;
            this.buttonMountains.Click += new System.EventHandler(this.buttonMountains_Click);
            // 
            // buttonBezier
            // 
            this.buttonBezier.Location = new System.Drawing.Point(53, 178);
            this.buttonBezier.Margin = new System.Windows.Forms.Padding(2);
            this.buttonBezier.Name = "buttonBezier";
            this.buttonBezier.Size = new System.Drawing.Size(136, 70);
            this.buttonBezier.TabIndex = 2;
            this.buttonBezier.Text = "Кривые Безье";
            this.buttonBezier.UseVisualStyleBackColor = true;
            this.buttonBezier.Click += new System.EventHandler(this.buttonBezier_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(238, 273);
            this.Controls.Add(this.buttonBezier);
            this.Controls.Add(this.buttonMountains);
            this.Controls.Add(this.buttonFrac);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор задания";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonFrac;
        private System.Windows.Forms.Button buttonMountains;
        private System.Windows.Forms.Button buttonBezier;
    }
}

