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

namespace Revisao
{
    public partial class frmOutroRevisao : Form
    {
        public frmOutroRevisao()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbxLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmOutroRevisao_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Nome FROM Pessoa";
            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = Conecta.abreConexao();
            MySqlDataReader dr;
            try
            {
                dr = cm.ExecuteReader();
                while(dr.Read())
                {
                    lbxLista.Items.Add(dr["Nome"].ToString());
                }
                dr.Close();
                cm.Dispose();
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
