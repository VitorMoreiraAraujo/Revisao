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

namespace Revisao
{
    public partial class frmRevisao : Form
    {
        public frmRevisao()
        {
            InitializeComponent();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string sql = String.Format("SELECT * FROM Pessoa WHERE IDPessoa = {0}", txtID.Text);

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            cmd.Connection = Conecta.abreConexao();

            MySqlDataReader dr;

            try
            {
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    lblNome.Text = dr["Nome"].ToString();
                    lblCPF.Text = dr["CPF"].ToString();
                    lblEndereco.Text = dr["Endereco"].ToString();
                    lblEmail.Text = dr["Email"].ToString();
                    lblContato.Text = dr["Contato"].ToString();
                    lbxLista.Items.Clear();
                    lbxLista.Items.Add(dr["Lista"].ToString());
                }
                dr.Close();
                cmd.Dispose();

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally 
            {
                Conecta.fechaConexao();
            
            }
        }
    }
}
