using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Revisao
{
    internal class Conecta
    {
        private static string sql = @"Server=localhost; Database=Revisao; Uid=Astrogildo; Pwd=123456";

        private static MySqlConnection connection = new MySqlConnection(sql);

        #region Método para abrir conexão
        public static MySqlConnection abreConexao()
        {
            try
            {
                if (connection.State.ToString() == "Closed")
                {
                    connection.Open();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return connection;
        }
        #endregion

        #region Método para fechar conexão

        public static void fechaConexao()
        {
            try
            {
                if (connection.State.ToString() == "Open")
                {
                    connection.Close();
                }

            }
            catch (MySqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
