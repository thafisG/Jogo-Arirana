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
    public partial class Escolha : Form
    {
        public Escolha()
        {
            InitializeComponent();
        }
        public DialogResult Resultado { get; private set; }

        public static DialogResult Mostrar()
        {
            var msgBox = new Escolha();
            msgBox.lblMensagem.Text = "Escolha um movimento";
            msgBox.btnSim.Text = "Aproximação";
            msgBox.btnNao.Text = "Afastamento";
            msgBox.ShowDialog();
            return msgBox.Resultado;
        }

   

        private void Button2_Click_1(object sender, EventArgs e)
        {
            Resultado = DialogResult.No;
            Close();
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Resultado = DialogResult.Yes;
            Close();
        }
    }
}
