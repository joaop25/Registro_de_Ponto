using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_de_Ponto
{
    public partial class Ponto : Form
    {

        public string Usuario { get; set; }
        public string Senha { get; set; }

        public Ponto(string usuario, string senha)
        {
            Usuario = usuario;
            Senha = senha;
            InitializeComponent();
        }

        public Ponto()
        {
            InitializeComponent();
        }

        private void Ponto_Load(object sender, EventArgs e)
        {

            try
            {

                labelusuario.Text = Usuario;


                string ponto_inicio_dia = "";

                using MySqlConnection Cn = new MySqlConnection();
                Cn.ConnectionString = "server = localhost; database = Registro_de_Ponto; uid = joao_teste; pwd = 123; port = 3306";
                Cn.Open();


                using MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pontos where usuario = '{Usuario}' and Data ='{DateTime.Today.ToString("yyyy-MM-dd")}'", Cn);
                using MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    ponto_inicio_dia = reader[2].ToString();
                }

                if(ponto_inicio_dia != "")
                {
                    var horas = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    ponto_inicio_dia = DateTime.Parse(ponto_inicio_dia).ToString("yyyy-MM-dd HH:mm:ss");

                    var resultado = DateTime.Parse(horas) - DateTime.Parse(ponto_inicio_dia);

                    labelhoras.Text = resultado.ToString();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro: " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                try
                {


                    string ponto_inicio_dia = "";
                    string ponto_inicio_almoco = "";
                    string ponto_fim_almoco = "";
                    string ponto_fim_dia = "";

                    using MySqlConnection Cn = new MySqlConnection();
                    Cn.ConnectionString = "server = localhost; database = Registro_de_Ponto; uid = joao_teste; pwd = 123; port = 3306";
                    Cn.Open();


                    using MySqlCommand cmd = new MySqlCommand($"SELECT * FROM pontos where usuario = '{Usuario}' and Data = '{DateTime.Today.ToString("yyyy-MM-dd")}'", Cn);
                    using MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        ponto_inicio_dia = reader[2].ToString();
                        ponto_inicio_almoco = reader[3].ToString();
                        ponto_fim_almoco = reader[4].ToString();
                        ponto_fim_dia = reader[5].ToString();

                    }
                    reader.Close();
                    if (ponto_inicio_dia == "")
                    {
                        using MySqlCommand cmd2 = new MySqlCommand($"insert pontos (usuario,ponto_inicio_dia,Data) values('{Usuario}','{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{DateTime.Today.ToString("yyyy-MM-dd")}')", Cn);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Ponto registrado com sucesso");

                    }
                    else if (ponto_inicio_almoco == "")
                    {
                        using MySqlCommand cmd2 = new MySqlCommand($"update pontos set ponto_inicio_almoco = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where usuario = '{Usuario}' and Data = '{DateTime.Today.ToString("yyyy-MM-dd")}'", Cn);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Ponto registrado com sucesso");

                    }

                    else if (ponto_fim_almoco == "")
                    {
                        using MySqlCommand cmd2 = new MySqlCommand($"update pontos set ponto_fim_almoco = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where usuario = '{Usuario}' and Data = '{DateTime.Today.ToString("yyyy-MM-dd")}'", Cn);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Ponto registrado com sucesso");

                    }

                    else if (ponto_fim_dia == "")
                    {
                        using MySqlCommand cmd2 = new MySqlCommand($"update pontos set ponto_fim_dia = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where usuario = '{Usuario}' and Data = '{DateTime.Today.ToString("yyyy-MM-dd")}'", Cn);
                        cmd2.ExecuteNonQuery();

                        MessageBox.Show("Ponto registrado com sucesso");

                    }
                    
                    
                    if(ponto_inicio_dia != "")
                    {
                        var horas = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        ponto_inicio_dia = DateTime.Parse(ponto_inicio_dia).ToString("yyyy-MM-dd HH:mm:ss");

                        var resultado = DateTime.Parse(horas) - DateTime.Parse(ponto_inicio_dia);

                        labelhoras.Text = resultado.ToString();
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }
    }
}


