using BancoDadosProjeto.Dominio;
using BancoDadosProjeto.Aplicacao;
using System;
using System.Data.SqlClient;




namespace DOS
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bd = new bd();
            var app = new FuncionarioAplicacao();

            SqlConnection conexao = new SqlConnection(@"data source=DESKTOP-OQUK6D7\SQLEXPRESS;Integrated Security =SSPI;Initial Catalog =ExemploBD");
            conexao.Open();
            
            Console.Write(" Qual o nome do Funcionário ? ");
            string Nome = Console.ReadLine();
            Console.Write(" Qual é a data de nascimento do funcionário ? ");
            string DataNascimento = Console.ReadLine();
            Console.Write(" Qual será o valor do salário do funcionario ? ");
            double Salario = Convert.ToDouble(Console.ReadLine());
            Console.Write(" Qual será a atividade do funcionário ? ");
            string Atividades = Console.ReadLine();

            var funcinarios = new Funcionarios
            {
                nome = Nome,
                dataNascimento =DateTime.Parse(DataNascimento),
                salario = Salario,
                atividades = Atividades

            };
            
            app.Salvar(funcinarios); 
            var dados = app.ListarTodos();

            foreach(var funcionario in dados)
            {
                Console.WriteLine("Código do Funcionario : {0},Nome: {1},Data de Nascimento: {2},Salario:R${3},Atividades: {4}", funcionario.codFuncionario,funcionario.nome,funcionario.dataNascimento,funcionario.salario,funcionario.atividades);
            }
        }
    }
}

