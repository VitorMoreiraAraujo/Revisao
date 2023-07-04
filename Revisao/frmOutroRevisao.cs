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

        #region Método Modifica

        private void modifica(string sql)
        {
            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = Conecta.abreConexao();
            try
            {
                if (MessageBox.Show("Deseja realmente fazer está ação ?", MessageBoxIcon.Warning.ToString(), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    int resu = cm.ExecuteNonQuery();
                    if (resu > 0)
                    {
                        MessageBox.Show("Ação efetuada com sucesso");
                    }
                    else
                    {
                        MessageBox.Show("Erro ao efetuar certa ação");
                    }
                    cm.Dispose();
                }

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
        #endregion


        #region Método pesquisar

        private void pesquisa(string sql)
        {
            MySqlCommand cm = new MySqlCommand();
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = Conecta.abreConexao();
            MySqlDataReader dr;
            try
            {
                dr = cm.ExecuteReader();
                while (dr.Read())
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

        #endregion
        private void lbxLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmOutroRevisao_Load(object sender, EventArgs e)
        {
            string sql = "SELECT Nome FROM Clientes";
            pesquisa(sql);
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            string excluir = String.Format("DELETE FROM Clientes WHERE Nome = '{0}'", lbxLista.SelectedItem);
            modifica(excluir);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            lbxLista.Items.Clear();
            string pesquisar = "SELECT Nome FROM Clientes";
            pesquisa(pesquisar);
        }
    }
}
