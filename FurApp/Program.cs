using System;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;
using GerenciadorApp;

namespace FuraoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            GerenciadorDeConta gerenciador = new GerenciadorDeConta();
            gerenciador.CadastrarConta(); // Chama o método de cadastro de conta

            Console.WriteLine("\nCadastro concluído!");
            Console.WriteLine("Pressione qualquer tecla para sair...");
            Console.ReadKey();
        }
    }
}
