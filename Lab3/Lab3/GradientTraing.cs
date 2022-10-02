using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3Rastr
{
    public partial class GradientTraing : Form
    {
        public GradientTraing()
        {
            InitializeComponent();
        }

        //Правильное закрытие окна
        private void GradientTraing_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form ifrm = Application.OpenForms[0];
            ifrm.Show();
        }

        
    }
}
