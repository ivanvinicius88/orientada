using ConNorth.Modelo;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConNorth.Controle
{
    public class FuncionarioDB
    {
        //listar---------------------------------------------------------------------------------------------------------------------------
        public static List<Funcionario> getConsultaFuncionarios(NpgsqlConnection conexao)
        {
            List<Funcionario> lista = new List<Funcionario>();
            try
            {
                string sql = "select * from funcionario";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    int id = (int)dr["idfuncionario"];
                    string nome = (string)dr["nome"];
                    int cpf = (int)dr["cpf"];
                    Funcionario funcionario = new Funcionario();
                    funcionario.idfuncionario = id;
                    funcionario.nome = nome;
                    funcionario.cpf = cpf;
                    lista.Add(funcionario);
                }
                dr.Close();
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro no SQL:" + erro.Message);
            }
            return lista;
        }

        //listar2---------------------------------------------------------------------------------------------------------------------------
        public static DataTable getConsultaFuncionario2(NpgsqlConnection conexao)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from funcionario";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                using (NpgsqlDataAdapter dat = new NpgsqlDataAdapter(cmd))
                {
                    dat.Fill(dt);
                }
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro no SQL" + erro.Message);
            }
            return dt;
        }

        //adicionar---------------------------------------------------------------------------------------------------------------------------
        public static bool setIncluiFuncionario(NpgsqlConnection conexao, Funcionario funcionario)
        {
            bool incluiu = false;

            try
            {
                string sql = "insert into funcionario (idfuncionario, nome, cpf) values (@id, @nome, @cpf)";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = funcionario.idfuncionario;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = funcionario.nome;
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Integer).Value = funcionario.cpf;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    incluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro no SQL: " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro" + erro.Message);
            }
            return incluiu;
        }

        //alterar---------------------------------------------------------------------------------------------------------------------------
        public static bool setAlteraFuncionario(NpgsqlConnection conexao, Funcionario funcionario)
        {
            bool alterou = false;

            try
            {
                string sql = "update funcionario set idfuncionario=@id, nome=@nome, cpf=@cpf";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = funcionario.idfuncionario;
                cmd.Parameters.Add("@nome", NpgsqlTypes.NpgsqlDbType.Varchar).Value = funcionario.nome;
                cmd.Parameters.Add("@cpf", NpgsqlTypes.NpgsqlDbType.Integer).Value = funcionario.cpf;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    alterou = true;
                }

            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro no SQL: " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
            return alterou;

        }

        //excluir---------------------------------------------------------------------------------------------------------------------------
        public static bool setExcluiFuncionario(NpgsqlConnection conexao, int idfuncionario)
        {
            bool excluiu = false;
            try
            {
                string sql = " delete from funcionario where idfuncionario=@id ";
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conexao);
                cmd.Parameters.Add("@id", NpgsqlTypes.NpgsqlDbType.Integer).Value = idfuncionario;
                int valor = cmd.ExecuteNonQuery();
                if (valor == 1)
                {
                    excluiu = true;
                }
            }
            catch (NpgsqlException erro)
            {
                MessageBox.Show("Erro no SQL: " + erro.Message);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }
            return excluiu;
        }
    }
}
