using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appCarro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Cadastrar_Carro cadastroForm = new Cadastrar_Carro();
            cadastroForm.ShowDialog();

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Buscar_Carro buscarForm = new Buscar_Carro();
            buscarForm.ShowDialog();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alterar_Carro alterarForm = new Alterar_Carro();
            alterarForm.ShowDialog();
        }
    }
}
