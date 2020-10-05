using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlCommand = System.Data.SqlClient.SqlCommand;
using SqlConnection = System.Data.SqlClient.SqlConnection;

namespace Calopsite
{
    class BD
    {
        public static string serverName = "localhost";
        public static string dataBaseName = "Calopsite";
        public static string sqlUser = "root";
        public static string sqlPassword = "root";
        public static int modoAcesso = 1;

        private static string stringConexao;

        private static void atribuirDadosAcessoBancoDados(string servidor, string bancoDados, string sqlUser,
            string sqlPassword, int modoAcesso)
        {
            BD.dataBaseName = bancoDados;
            BD.serverName = servidor;
            BD.sqlUser = sqlUser;
            BD.sqlPassword = sqlPassword;
            BD.modoAcesso = modoAcesso;
        }

        private static string construirConexao()
        {
            if (stringConexao != null)
            {
                return stringConexao;
            }

            MySqlConnectionStringBuilder sqlBuilder = new MySqlConnectionStringBuilder
            {
                Server = serverName,
                UserID = sqlUser,
                Password = sqlPassword,
                Database = dataBaseName
            };

            stringConexao = sqlBuilder.ToString();
            return stringConexao;
        }

        public void executarComando(MySqlCommand command)
        {
            using (MySqlConnection con = new MySqlConnection(BD.construirConexao()))
            using (command)
            {
                con.Open();
                command.Connection = con;
                command.ExecuteNonQuery();

                con.Close();
            }
        }


        public DataTable executarConsulta(MySqlCommand query)
        {
            var dataTable = new DataTable();

            using (MySqlConnection con = new MySqlConnection(BD.construirConexao()))
            using (query)
            {
                con.Open();
                query.Connection = con;

                using (DbDataReader rdr = query.ExecuteReader(CommandBehavior.SequentialAccess))
                {

                    dataTable.Load(rdr);

                }

                con.Close();
            }

            return dataTable;

        }

    }
}