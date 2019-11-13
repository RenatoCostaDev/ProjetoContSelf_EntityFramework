using System;
using System.Collections.Generic;
using System.Text;

namespace BancoDadosProjeto.Dominio
{
    public class Funcionarios
    {
        public int codFuncionario { get; set; }

        public string nome { get; set; }

        public DateTime dataNascimento { get; set; }

        public double salario { get; set; }

        public string atividades { get; set; }
    }
}
