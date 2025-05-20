using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace appCarro
{
    public partial class Alterar_Carro : Form
    {
        private MySqlConnection mCon;
        private MySqlDataAdapter mApater;
        private DataSet mDS;
        public Alterar_Carro()
        {
            InitializeComponent();
            carregaCombo();
        }

        public void carregaCombo()
        {
            comboBox1.Items.Clear();
            mDS = new DataSet();
            mCon = new MySqlConnection("Persist Security Info=false;" + "server=127.0.0.1;database=bd_carro;uid=root");
            mCon.Open();
            MySqlCommand SQL = new MySqlCommand("select car_modelo from tbl_carro", mCon);
            MySqlDataReader MySqlDR = SQL.ExecuteReader();
            while (MySqlDR.Read())
            {
                comboBox1.Items.Add(MySqlDR["car_modelo"].ToString());
            }
            MySqlDR.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand(
 "UPDATE tbl_carro " +
 "SET car_placa = @placa, car_marca = @marca, car_modelo = @modelo, car_ano = @ano, car_preco = @preco " +
 "WHERE car_modelo = @nomePesquisado", mCon);
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            SQL.Parameters.AddWithValue("@placa", txtPlaca.Text);
            SQL.Parameters.AddWithValue("@marca", txtMarca.Text);
            SQL.Parameters.AddWithValue("@modelo", txtModelo.Text);
            SQL.Parameters.AddWithValue("@ano", txtAno.Text);
            SQL.Parameters.AddWithValue("@preco", (float)txtPreco.Value);
            SQL.ExecuteNonQuery();
            MessageBox.Show("Cadastro Alterado");
            comboBox1.Text = "";
            carregaCombo();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand("select * from tbl_carro where car_modelo=@NomePesquisado", mCon);
            SQL.Parameters.AddWithValue("@NomePesquisado", comboBox1.Text);
            MySqlDataReader MySqlDR2 = SQL.ExecuteReader();
            MySqlDR2.Read();
            txtPlaca.Text = MySqlDR2["car_placa"].ToString();
            txtMarca.Text = MySqlDR2["car_marca"].ToString();
            txtModelo.Text = MySqlDR2["car_modelo"].ToString();
            txtAno.Text = MySqlDR2["car_ano"].ToString();
            txtPreco.Text = MySqlDR2["car_preco"].ToString();
            groupBox1.Visible = true;
            MySqlDR2.Close();
        }
    }
}
