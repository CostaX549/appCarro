using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appCarro
{
    public partial class Buscar_Carro : Form
    {
        private MySqlConnection mCon;
        private MySqlDataAdapter mApater;
        private DataSet mDS;
        public Buscar_Carro()
        {
            InitializeComponent();
            mDS = new DataSet();
            mCon = new MySqlConnection("Persist Security Info=false;" + "server=127.0.0.1;database=bd_carro;uid=root");
            mCon.Open();
            carregaCombo();
        }

        public void carregaCombo()
        {
            MySqlCommand SQL = new MySqlCommand("select car_modelo from tbl_carro", mCon);
            MySqlDataReader MySqlDR = SQL.ExecuteReader();
            while (MySqlDR.Read())
            {
                comboBox1.Items.Add(MySqlDR["car_modelo"].ToString());
            }
            MySqlDR.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand("select * from tbl_carro where car_modelo=@NomePesquisado", mCon);
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            MySqlDataReader MySqlDR2 = SQL.ExecuteReader();
            MySqlDR2.Read();
            lblplaca.Text = "Placa: " + MySqlDR2["car_placa"].ToString();
            lblmarca.Text = "Marca: " + MySqlDR2["car_marca"].ToString();
            lblmodelo.Text = "Modelo: " + MySqlDR2["car_modelo"].ToString();
            lblano.Text = "Ano: " + MySqlDR2["car_ano"].ToString();
            lblpreco.Text = "Preço: " + MySqlDR2["car_preco"].ToString();
            groupBox1.Visible = true;
            MySqlDR2.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand("delete from tbl_carro where car_modelo=@NomePesquisado", mCon);
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            MySqlDataReader MySqlDR2 = SQL.ExecuteReader();
            MySqlDR2.Read();
            MessageBox.Show("Cadastro Excluído com Sucesso!");
            MySqlDR2.Close();
            comboBox1.Text = "";
            comboBox1.Items.Clear();
            carregaCombo();
            groupBox1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Alterar_Carro alterarForm = new Alterar_Carro();
            alterarForm.ShowDialog();
        }
    }
}
