using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp18
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Controls.Add(pictureBox2);
            this.Controls.Add(pictureBox1);
        }

        private void botãoJogar(object sender, DragEventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Form2 OutroForm = new Form2();
            OutroForm.Show();
            this.Hide();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form3 OutroForm = new Form3();
            OutroForm.Show();
            this.Hide();
        }
     
    }
}
