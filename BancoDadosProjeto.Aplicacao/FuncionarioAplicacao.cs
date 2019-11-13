using BancoDadosProjeto.Dominio;
using ConexaoBD;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;


namespace BancoDadosProjeto.Aplicacao
{
    public class FuncionarioAplicacao
    {
        private bd bd;
        private void Inserir(Funcionarios funcionarios)
        {
            var strQuery = "";
            strQuery += "INSERT INTO FUNCIONARIOS(Nome,DataNascimento,Salario,Atividades) ";
            strQuery += string.Format(" values('{0}','{1}','{2}','{3}')",funcionarios.nome,funcionarios.dataNascimento, funcionarios.salario, funcionarios.atividades);

            using(bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        private void Alterar(Funcionarios funcionarios)
        {
            var strQuery = "";
            strQuery += "Update Funcionarios SET ";
            strQuery += string.Format("Nome = '{0}', ",funcionarios.nome);
            strQuery += string.Format("DataNascimento = '{0}', ",funcionarios.dataNascimento);
            strQuery += string.Format("Salario = '{0}', ",funcionarios.salario);
            strQuery += string.Format("Atividades ='{0}'",funcionarios.atividades);
            strQuery += string.Format("WHERE CodFuncionario = '{0}'", funcionarios.codFuncionario);

            using (bd = new bd())
            {
                bd.ExecutaComando(strQuery);
            }
        }

        public void Salvar(Funcionarios funcionarios)
        {
            if (funcionarios.codFuncionario >0)
            {
                Alterar(funcionarios);
            }
            else
            {
                Inserir(funcionarios);
            }
        }

        public void Excluir(int codFuncionario)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format("DELETE FROM Funcionarios WHERE CodFuncionario = '{0}'",codFuncionario) ;
                bd.ExecutaComando(strQuery);
            }
        }

        public List<Funcionarios> ListarTodos()
        {
            using(bd = new bd())
            {
                var strQuery = "SELECT * FROM Funcionarios ";
                var retorno= bd.ExecutaComandoComRetorno(strQuery);
                return ReaderEmLista(retorno);
            }            
        }

        public Funcionarios ListarPorId(int codFuncionario)
        {
            using (bd = new bd())
            {
                var strQuery = string.Format("SELECT * FROM Funcionarios WHERE CodFuncionario = {0}",codFuncionario);
                var retorno = bd.ExecutaComandoComRetorno(strQuery);
                return ReaderEmLista(retorno).FirstOrDefault();
            }
        }
        public  List<Funcionarios> ReaderEmLista(SqlDataReader reader)
        {
            var funcionarios = new  List<Funcionarios>();
            while (reader.Read())
            {
                var tempoObjeto = new Funcionarios()
                {
                    codFuncionario = int.Parse(reader["CodFuncionario"].ToString()),
                    nome =reader["Nome"].ToString(),
                    dataNascimento = DateTime.Parse(reader["DataNascimento"].ToString()),
                    salario = double.Parse(reader["Salario"].ToString()),
                    atividades = reader["Atividades"].ToString(),
                };
            funcionarios.Add(tempoObjeto);
            }
            reader.Close();
            return funcionarios;
        }
    }
}