using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Atividade_P.D.S_02
{
    /// <summary>
    /// Lógica interna para Pessoa.xaml
    /// </summary>
    public partial class Pessoa : Window
    {
        private MySqlConnection conexao;
        
        public Pessoa()
        {

            InitializeComponent();
            Conexao();
            

        }
       private void Conexao()
       {
                string conexaoString = "server=localhost;database=app_contato_bd;user=root;password=root;port=3360";
                conexao = new MySqlConnection(conexaoString);

                conexao.Open();
            

        }

       

        private void BtSalvar(object sender, RoutedEventArgs e)
        {
            
            
                var nome = txtNome.Text;
                var email = txtEmail.Text;
                var telefone = txtTelefone.Text;
                var dataNascimento = dtpData.Text;

                string query = "INSERT INTO Contato (nome_con, email_con, telefone_con, data_nasc_con) VALUES (@_nome, @_email, @_telefone, @_datanascimento)";
                var comando = new MySqlCommand(query, conexao);

                comando.Parameters.AddWithValue("@_nome", nome);
                comando.Parameters.AddWithValue("@_email", email);
                comando.Parameters.AddWithValue("@_telefone", telefone);
                comando.Parameters.AddWithValue("@_datanascimento", dataNascimento);

            dataNascimento = "2000-00-00";
            Convert.



                comando.ExecuteNonQuery();

                var opcao = MessageBox.Show("Salvo com sucesso! \nDeseja realizar um novo cadastro? ", "Informação");
                 

                //if (opcao == DialogResult.Yes)
                //{
                //    LimparInputs();
                //}
                //else
                //{
                //    this.Close();
                //}


           
        }
    }
    
}
