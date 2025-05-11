using System;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;
using ContaUsuarioApp;

using System;
using MySqlConnector;

namespace FurApp
{
    class Program
    {
        static void Main()
        {
            try
            {
                string connStr = "Server=127.0.0.1;Port=18046;User ID=root;Password=qhG171U4;Database=furapp;";

                using var cn = new MySqlConnection(connStr);
                cn.Open();
                Console.WriteLine("Conectado com sucesso ao banco 'furapp'!\n");

                string query = "SELECT abreviacao, categoria FROM posicoes_jogadores";

                using var cmd = new MySqlCommand(query, cn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string abreviacao = reader["abreviacao"]?.ToString() ?? "N/A";
                    string categoria = reader["categoria"]?.ToString() ?? "Sem Categoria";

                    Console.WriteLine($"Abreviação: {abreviacao} - Categoria: {categoria}");
                }

                Console.WriteLine("\nPressione qualquer tecla para sair...");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao conectar:");
                Console.WriteLine(ex.Message);
                Console.WriteLine("\nDetalhes completos:");
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
/*
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

                        ContaUsuario conta = new ContaUsuario(nome ?? "", senha ?? "", idade: 0, saldo: 0, interesses: "", amistosos: "");
                        conta.Login(tipoConta ?? "", nome ?? "", senha ?? "");


            
                        break;

                    }

                    case "2":
                    {
                        Console.Clear();
                        GerenciadorDeConta gerenciador = new GerenciadorDeConta();
                        
                        var contasPorTipo = PersistenciaDeContas.CarregarContasAgrupadas(); // lendo o json 

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
*/