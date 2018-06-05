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
using ConNorth.Modelo;
using ConNorth.Controle;

namespace ConNorth.View.Funcionario
{
    public partial class FrmNovoFuncionario : Form
    {

        internal NpgsqlConnection conexao = null;

        public FrmNovoFuncionario(NpgsqlConnection conexao)
        {
            InitializeComponent();
            this.conexao = conexao;
        }

        private void FrmNovoFuncionario_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        //btn cadastrar com problema
        private void button1_Click(object sender, EventArgs e)
        {
            /* 

             int id = int.Parse(textBox1.Text);
             string nome = textBox2.Text;
             int cpf = int.Parse(textBox3.Text);
             Funcionario funcionario = new Funcionario();
             funcionario.idfuncionario = id;
             funcionario.nome = nome;
             funcionario.cpf = cpf;
             bool incluiu = FuncionarioDB.setIncluiFuncionario(this.conexao, funcionario);
             if (incluiu)
             {
                 MessageBox.Show("Funcionário Incluido com Sucesso ");
                 Close();
             }
             else
             {
                 MessageBox.Show("Houve um Erro ao Incluir o Funcionário");
             }

             */
        }
    }
}
