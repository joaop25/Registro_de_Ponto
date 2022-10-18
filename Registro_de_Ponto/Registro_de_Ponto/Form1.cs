using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Registro_de_Ponto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> senha = new List<string>();
            List<string> usuario = new List<string>();

            using MySqlConnection Cn = new MySqlConnection();
            Cn.ConnectionString = "server = localhost; database = Registro_de_Ponto; uid = joao_teste; pwd = 123; port = 3306";
            Cn.Open();
            using MySqlCommand cmd = new MySqlCommand($"SELECT usuario,senha FROM usuarios where usuario = '{textusuario.Text}' and senha = '{textsenha.Text}'", Cn);
            using MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                 usuario.Add(reader[0].ToString());
                 senha.Add(reader[1].ToString());
            }

            if (textusuario.Text == usuario[0].ToString() && textsenha.Text == senha[0].ToString())
            {
                MessageBox.Show("Login realizado com sucesso");
                reader.Close();

                Ponto ponto = new Ponto(textusuario.Text, textsenha.Text);
                ponto.Show();
                this.Hide();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }

}