using ContaJogadorApp;
using JogosApp;

namespace Util_OpcoesContas
{
    public class Utils_De_OpcoesContas
    {
        private Conta_Jogador contaLogada;

        public Utils_De_OpcoesContas(Conta_Jogador conta)
        {
            contaLogada = conta;
        }
        public void Display_MenuAdministrador()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Olá, {contaLogada.Nome}!\n");
                Console.WriteLine(".______________________________________.");
                Console.WriteLine("|  -=-     Menu Administrador     -=-  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|Opções de Conta . . . . . . . . |  1  |");
                Console.WriteLine("|Opções de Jogador . . . . . . . |  2  |");
                Console.WriteLine("|Opções de Técnico . . . . . . . |  3  |");
                Console.WriteLine("|Opções de Arbitro . . . . . . . |  4  |");
                Console.WriteLine("|Opções de Time. . . . . . . . . |  5  |");
                Console.WriteLine("|Opções de Jogo. . . . . . . . . |  6  |");
                Console.WriteLine("|Opções de Partidas. . . . . . . |  6  |");
                Console.WriteLine("|________________________________|_____|");
                Console.WriteLine("|LOGOFF. . . . . . . . . . . . . |  0  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        // Vou linkar MENU de Opções de Conta
                        break;

                    case "2":
                        // Vou linkar MENU de Opções de Jogador
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

                    case "0":
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
        public void Display_MenuArbitro()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Olá, {contaLogada.Nome}!\n");
                Console.WriteLine(".______________________________________.");
                Console.WriteLine("|  -=-        Menu Arbitro        -=-  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|Opções de Jogo. . . . . . . . . |  1  |");
                Console.WriteLine("|Opções de Partidas. . . . . . . |  2  |");
                Console.WriteLine("|________________________________|_____|");
                Console.WriteLine("|LOGOFF. . . . . . . . . . . . . |  0  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        // Vou linkar MENU de Opções de Jogos
                        break;

                    case "2":
                        // Vou linkar MENU de Opções de Partidas
                        break;

                    case "0":
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
        public void Display_MenuJogador()
        {
            while (true)
            {
                Console.WriteLine($"Olá, {contaLogada.Nome}!\n");
                Console.WriteLine(".______________________________________.");
                Console.WriteLine("|  -=-        Menu Jogador        -=-  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|Informações do Jogador. . . . . |  1  |");
                Console.WriteLine("|Entrar em um Time . . . . . . . |  2  |");
                Console.WriteLine("|Jogos e Partidas  . . . . . . . |  3  |");
                Console.WriteLine("|Opções Adicionais . . . . . . . |  4  |");
                Console.WriteLine("|________________________________|_____|");
                Console.WriteLine("|LOGOFF. . . . . . . . . . . . . |  0  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        // Vou linkar MENU de Informações do Jogador
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

                    case "0":
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
