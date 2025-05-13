using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace appCarro
{
    public partial class Cadastrar_Carro : Form
    {
        private MySqlConnection mCon;
        private MySqlDataAdapter mApater;
        private DataSet mDS;

        public Cadastrar_Carro()
        {
            InitializeComponent();
            mDS = new DataSet();
            mCon = new MySqlConnection("Persist Security Info=false;server=127.0.0.1;database=bd_carro;uid=root");

            mCon.Open();
            exibe();
        }
        public void exibe()
        {
            if (mCon.State == ConnectionState.Open)
            {
                mDS.Clear();
                mApater = new MySqlDataAdapter("SELECT * FROM tbl_carro", mCon);
                mApater.Fill(mDS, "dados");
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                dataGridView1.Refresh();
                dataGridView1.DataSource = mDS;
                dataGridView1.DataMember = "dados";
            }
        }
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand SQL = new MySqlCommand(
                 "INSERT INTO tbl_carro (car_placa, car_marca, car_modelo, car_ano, car_preco) " +
                 "VALUES (@placa, @marca, @modelo, @ano, @preco)", mCon);

            SQL.Parameters.AddWithValue("@placa", txtPlaca.Text);
            SQL.Parameters.AddWithValue("@marca", txtMarca.Text);
            SQL.Parameters.AddWithValue("@modelo", txtModelo.Text);
            SQL.Parameters.AddWithValue("@ano", txtAno.Text);
            SQL.Parameters.AddWithValue("@preco", (float)txtPreco.Value);


            SQL.ExecuteNonQuery();


            MessageBox.Show("Cadastro Realizado");
            exibe();
        }
    }
}
