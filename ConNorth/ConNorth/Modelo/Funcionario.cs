using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConNorth.Modelo
{
    public class Funcionario
    {
        public int idfuncionario { get; set; }
        public string nome { get; set; }
        public int cpf { get; set; }


    }
}
