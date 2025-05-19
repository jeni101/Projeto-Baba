using System;
using Models;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;
using Models.JogosApp;
using Views.OpcoesAdministrador;
using Services.Autenticacao;


namespace Views.OpcoesContas
{
    public static class Views_De_OpcoesContas
    {
        public static void Display_MenuAdministrador()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"• Olá, {Autenticador.Instancia.PegarNomeConta()}!");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄            ");
                Console.WriteLine(" |  -=-          Menu Administrador          -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Opções de Conta . . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀            ");
                Console.WriteLine(" |- Opções de Jogador . . . . . . . . . . . |  2  |           ▐   ▄         ▄   ▌            ");
                Console.WriteLine(" |- Opções de Técnico . . . . . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌            ");
                Console.WriteLine(" |- Opções de Arbitro . . . . . . . . . . . |  4  |           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- Opções de Time  . . . . . . . . . . . . |  5  |            █    ▄ ▀█▀ ▄    █             ");
                Console.WriteLine(" |- Opções de Jogo  . . . . . . . . . . . . |  6  |             ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine(" |- Opções de Partidas  . . . . . . . . . . |  7  |              ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine(" |__________________________________________|_____|              ▐    ▀▀▀    ▌               ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |             ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌              ");
                Console.WriteLine(" |================================================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        Views_Administrador.Display_Adm_Contas();
                        break;

                    case "2":
                        Views_Administrador.Display_Adm_Jogador();
                        break;

                    case "3":
                        // Vou linkar MENU de Opções de Tecnico
                        break;

                    case "4":
                        // Vou linkar MENU de Opções de Arbitro
                        break;

                    case "5":
                        // Vou linkar MENU de Opções de Times
                        break;

                    case "6":
                        // Vou linkar MENU de Opções de Jogos
                        break;

                    case "7":
                        // Vou linkar MENU de Opções de Partidas
                        break;

                    case "0": //Linkar Nova Case 0
                        Console.Write("Tem certeza que desejas sair? (S/N): ");
                        string? confirmacao = Console.ReadLine();

                        if (!string.IsNullOrEmpty(confirmacao) && confirmacao.Trim().ToUpper() == "S")
                        {
                            Console.WriteLine("Saindo da Conta...");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Comando Errado, Tente Novamente: ");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Comando Errado, Tente Novamente: ");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void Display_MenuJogador()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"• Olá, {Autenticador.Instancia.PegarNomeConta()}!");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄            ");
                Console.WriteLine(" |  -=-             Menu Jogador             -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Informações do Jogador  . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀            ");
                Console.WriteLine(" |- Entrar em um Time . . . . . . . . . . . |  2  |           ▐   ▄         ▄   ▌            ");
                Console.WriteLine(" |- Jogos e Partidas  . . . . . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌            ");
                Console.WriteLine(" |- Opções Adicionais . . . . . . . . . . . |  4  |           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |__________________________________________|_____|            █    ▄ ▀█▀ ▄    █             ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |             ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine(" |================================================|              ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine("                                                                 ▐    ▀▀▀    ▌               ");
                Console.WriteLine("                                                                ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌              ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        //linkar Função de ExibirPerfil do Jogador
                        break;

                    case "2":
                        // linkar Função de Entrar em um time
                        break;

                    case "3":
                        // Vou linkar MENU de Informações de Partidas
                        break;

                    case "4":
                        // Vou linkar MENU de Opções Adicionais
                        break;

                    case "0": //Linkar Nova Case 0
                        Console.Write("Tem certeza que desejas sair? (S/N): ");
                        string? confirmacao = Console.ReadLine();

                        if (!string.IsNullOrEmpty(confirmacao) && confirmacao.Trim().ToUpper() == "S")
                        {
                            Console.WriteLine("Saindo da Conta...");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Comando Errado, Tente Novamente: ");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Comando Errado, Tente Novamente: ");
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void Display_MenuTecnico()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"• Olá, {Autenticador.Instancia.PegarNomeConta()}!");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄            ");
                Console.WriteLine(" |  -=-             Menu Tecnico             -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Informações do Tecnic . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀            ");
                Console.WriteLine(" |- Criar / Gerenciar Time  . . . . . . . . |  2  |           ▐   ▄         ▄   ▌            ");
                Console.WriteLine(" |- Criar / Entrar em um Jogo . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌            ");
                Console.WriteLine(" |- Pesquisar Jogador . . . . . . . . . . . |  4  |           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |__________________________________________|_____|            █    ▄ ▀█▀ ▄    █             ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |             ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine(" |================================================|              ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine("                                                                 ▐    ▀▀▀    ▌               ");
                Console.WriteLine("                                                                ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌              ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        //Linkar Função de ExibirPerfil do tecnico
                        break;

                    case "2":
                        //Linkar Função de Gerenciamento/Criação de Time
                        break;

                    case "3":
                        //Linkar Função de Criação/Entrada em Jogos
                        break;

                    case "4":
                        //Linkar Função de Pesquisa de Perfil de Jogador (Mostrar Informações)
                        break;

                    case "0": //Linkar Nova Case 0
                        Console.Write("Tem certeza que desejas sair? (S/N): ");
                        string? confirmacao = Console.ReadLine();

                        if (!string.IsNullOrEmpty(confirmacao) && confirmacao.Trim().ToUpper() == "S")
                        {
                            Console.WriteLine("Saindo da Conta...");
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Comando Errado, Tente Novamente: ");
                            Console.ReadKey();
                        }
                        break;

                    default:
                        Console.WriteLine("Comando Errado, Tente Novamente: ");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
