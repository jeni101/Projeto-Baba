using System;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;
using GerenciadorApp;
using PersistenciaApp;
using ContaUsuarioApp;

namespace FuraoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)

            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao FurApp!\n Escolha como deseja proseguir\n");

                Console.WriteLine("=======Furao App======");
                Console.WriteLine("loguin..............|1|");
                Console.WriteLine("Cadastrar conta.....|2|");
                Console.WriteLine("======================");

                string? escolha = Console.ReadLine();

                switch (escolha)
                {

                    case "1":
                    {
                        Console.WriteLine("Por favor, selecione seu tipo de conta:");
                        Console.WriteLine("1. Jogador");
                        Console.WriteLine("2. Técnico");
                        Console.WriteLine("3. Árbitro");
                        string? tipoConta = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Voce selecionou {tipoConta}\n");
                        Console.WriteLine("Agora informe seu Nome de usuario: ");
                        string? nome = Console.ReadLine();

                        Console.WriteLine("Por favor, informe sua senha: ");
                        string? senha = Console.ReadLine();

                        ContaUsuario conta = new ContaUsuario(nome ?? "", senha ?? "", idade: 0, saldo: 0, interesses: "", amistosos: "");
                        conta.Login(tipoConta ?? "", nome ?? "", senha ?? "");

                        
                        
    

                        

                        
                        
                        break;

                    }


                    

                }

                


            
            



            // Console.Clear();
            // GerenciadorDeConta gerenciador = new GerenciadorDeConta();
            
            // var contasPorTipo = PersistenciaDeContas.CarregarContasAgrupadas(); // lendo o json 

            // gerenciador.CadastrarConta(); // Chama o método de cadastro de conta
            

            

            // Console.WriteLine("\nCadastro concluído!");
            // Console.WriteLine("Pressione qualquer tecla para sair...");
            // Console.ReadKey();
            }
        }
    }
}
