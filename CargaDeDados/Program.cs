using CargaDeDados.Enitities;
using CargaDeDados.Infra;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace CargaDeDados
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();           

            Console.WriteLine("Carregando arquivos.");

            Console.WriteLine("Inserindo dados.");
            repository.InserirPais();
            repository.InserirSexo();
            repository.InserirQuestao();
            repository.InserirCliente();
            repository.InserirPedido();
            repository.InserirQuestaoOpcao();
            repository.InserirResposta();

            Console.WriteLine("Dados inseridos com sucesso!");

        }
    }
}
