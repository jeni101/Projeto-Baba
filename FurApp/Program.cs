using System;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;
using GerenciadorApp;
using PersistenciaApp;


namespace FuraoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            GerenciadorDeConta gerenciador = new GerenciadorDeConta();
            
            var contas = PersistenciaDeContas.CarregarContas(); // lendo o json 

            gerenciador.CadastrarConta(); // Chama o método de cadastro de conta
            

            

            Console.WriteLine("\nCadastro concluído!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
