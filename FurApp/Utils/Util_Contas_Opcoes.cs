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
        {   Console.WriteLine($"Olá, {contaLogada.Nome}!\n");
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
                    // Fazer uma confirmação antes de sair de fato
                    Console.WriteLine("Saindo .............");
                    return;
            }
        }
        public void Display_MenuArbitro()
        {   Console.WriteLine($"Olá, {contaLogada.Nome}!\n");
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
                    // Fazer uma confirmação antes de sair de fato
                    Console.WriteLine("Saindo .............");
                    return;
            }
        }
    }
}
