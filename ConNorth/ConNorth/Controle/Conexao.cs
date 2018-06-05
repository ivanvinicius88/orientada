using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConNorth.Controle
{
    public class Conexao
    {
        public static NpgsqlConnection getConexao()
        {
            NpgsqlConnection conexao = null;
            try
            {
                conexao = new NpgsqlConnection(" Server=localhost; Port=5432; User Id=postgres; Password=postgres; Database=fun; ");
                conexao.Open();
                Console.WriteLine("Conectado com o Banco de Dados");
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro ao conectar com o Banco de Dados" + erro.Message);
            }
            return conexao;
        }

        public static void setFechaConexao(NpgsqlConnection conexao)
        {
            if (conexao != null)
            {
                try
                {
                    conexao.Close();
                }
                catch(NpgsqlException erro)
                {
                   MessageBox.Show("Erro ao fechar a conexão com o Banco de Dados" + erro.Message);
                }
            }

        }

    }
}
