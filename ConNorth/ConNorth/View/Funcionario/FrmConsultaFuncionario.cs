using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConNorth.Controle;
using ConNorth.Modelo;
using ConNorth.View.Funcionario;

namespace ConNorth.View
{
    public partial class FrmConsultaFuncionario : Form
    {
        private void FrmConsultaFuncionario_Load(object sender, EventArgs e)
        { }

        internal NpgsqlConnection conexao = null;

        public FrmConsultaFuncionario(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
            atualizaTela();
        }

        private void atualizaTela()
        {
            dataGridView1.DataSource = FuncionarioDB.getConsultaFuncionario2(this.conexao);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmNovoFuncionario form = new FrmNovoFuncionario(conexao);
            form.ShowDialog();
            atualizaTela();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int idfuncionario = dataGridView1.CurrentRow.Cells[0].Value.GetHashCode();
            bool excluiu = FuncionarioDB.setExcluiFuncionario(conexao, idfuncionario);
            if (excluiu)
            {
                MessageBox.Show("Funcionario Excluido Com Sucesso! ");
                atualizaTela();
            }
            else
            {
                MessageBox.Show("Erro ao excluir Funcionario");
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*

            int idfuncionario = dataGridView1.CurrentRow.Cells[0].Value.GetHashCode();
            string nome = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            int cpf = dataGridView1.CurrentRow.Cells[2].Value.GetHashCode();
            Funcionario funcionario = new Funcionario();
            funcionario.idfuncionario = idfuncionario;
            funcionario.nome = nome;
            funcionario.cpf = cpf;
            bool alterou = FuncionarioDB.setAlteraFuncionario(conexao, funcionario);
            if (alterou)
            {
                MessageBox.Show("Estado Alterado Com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao alterar o Estado");
                atualizaTela();
            }
            */
        }
    }
}
