using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Funcionario
{
    static class ConexaoBanco
    {
        //criei 4 variáveis declaradas passando as informações do banco de dados.
        private const string servidor = "localhost";
        private const string bancoDados = "dbFuncionarios";
        private const string usuario = "root";
        private const string senha = "123456789";

        //declarando variavel bancoServidor para fazer a conexao com o banco de dados.
        static public string bancoServidor = $"server={servidor}; user id={usuario}; database={bancoDados}; password={senha}";
    }
}
