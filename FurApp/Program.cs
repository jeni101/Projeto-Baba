using System;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;
using GerenciadorApp;

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
                Console.WriteLine(" Bem vindo ao FurApp!\n Escolha como deseja proseguir:\n");

                Console.WriteLine("=======Furao App======");
                Console.WriteLine("loguin..............|1|");
                Console.WriteLine("Cadastrar conta.....|2|");
                Console.WriteLine("Sair................|x|");
                Console.WriteLine("======================");

                string? escolha = Console.ReadLine()?.ToLower();

                switch (escolha)
                {

                    case "1":
                    {
                        Console.Clear();
                        Console.WriteLine("Por favor, selecione seu tipo de conta:\n");
                        Console.WriteLine("======= Conta =======");
                        Console.WriteLine("Jogador............|1|");
                        Console.WriteLine("Técnico............|2|");
                        Console.WriteLine("Árbitro............|3|");
                        Console.WriteLine("======================");
                        string? tipoConta = Console.ReadLine();

                        Console.Clear();
                        Console.WriteLine($"Voce selecionou {tipoConta}\n");
                        Console.WriteLine("Agora informe seu Nome de usuario: ");
                        string? nome = Console.ReadLine();

                        Console.WriteLine("Por favor, informe sua senha: ");
                        string? senha = Console.ReadLine();

                        Conta_Usuario conta = new Conta_Usuario(nome ?? "", senha ?? "", idade: 0, saldo: 0, interesses: "", amistosos: "");
                        conta.Login( nome ?? "", senha ?? "");


            
                        break;

                    }

                    case "2":
                    {
                        Console.Clear();
                        GerenciadorDeConta gerenciador = new GerenciadorDeConta();
                        
                        var contasPorTipo = Persistencia_De_Contas.Carregar_Contas(); // lendo o json 

                        gerenciador.CadastrarConta(); // Chama o método de cadastro de conta
                        

                        

                        Console.WriteLine("\nCadastro concluído!");
                        Console.WriteLine("Pressione qualquer tecla para sair...");
                        Console.ReadKey();


                        break;

                    }

                    case "x":

                    {
                        Console.Clear();
                        Console.WriteLine("Saindo ..............");
                        return;
                    }
    

                    

                }

                
            }
        }
    }
}
