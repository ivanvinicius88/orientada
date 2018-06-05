using ConNorth.Controle;
using ConNorth.Modelo;
using ConNorth.View;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConNorth
{
    public partial class Form1 : Form
    {
        private void Form1_Load(object sender, EventArgs e)
        { }

        //Objeto conexão
        public NpgsqlConnection conexao = null;

        //iniciando o objeto de conexão
        public Form1()
        {
            InitializeComponent();
            this.conexao = Conexao.getConexao();
        }

        //Fechando a conexão
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Conexao.setFechaConexao(conexao);
        }

        //botão FUNCIONARIOS
        private void button1_Click(object sender, EventArgs e)
        {
            FrmConsultaFuncionario form = new FrmConsultaFuncionario(conexao);
            form.Show();
        }

        //botão REGIÃO
        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        //botão TERRITÓRIOS
        private void button3_Click(object sender, EventArgs e)
        {

        }

        //botão FUNCIONÀRIOS TERRITÓRIOS
        private void button4_Click(object sender, EventArgs e)
        {

        }

        //botão SAIR
        private void button5_Click(object sender, EventArgs e)
        {
            Conexao.setFechaConexao(conexao);
            Close();
        }
    }
}
