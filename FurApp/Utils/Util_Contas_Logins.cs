using ContaJogadorApp;
using JogosApp;

namespace Util_Contas
{
    public class Utils_De_Contas
    {
        private Conta_Jogador contaLogada;

        public Utils_De_Contas(Conta_Jogador conta)
        {
            contaLogada = conta;
        }
        public void DisplayMenu_LoginInicial()
        {   Console.WriteLine(".______________________________________.");
            Console.WriteLine("|  -=-       Login Inicial        -=-  |");
            Console.WriteLine("|======================================|");
            Console.WriteLine("|Novo Usuário. . . . . . . . . . |  1  |");
            Console.WriteLine("|Usuário Existente . . . . . . . |  2  |");
            Console.WriteLine("|________________________________|_____|");
            Console.WriteLine("|SAIR. . . . . . . . . . . . . . |  0  |");
            Console.WriteLine("|======================================|");
            string? escolha = Console.ReadLine();

            switch (escolha)
            {
                case "1":
                    //Linkar Função de Criação de Novo Usuário
                    break;

                case "2":
                    //Linkar Função de Verificação de Usuario
                    break;

                case "0":
                    Console.WriteLine("Saindo .............");
                    return;
            }
        }
        // public void DisplayMenu_SelecaoContas()
        // {   Console.WriteLine($"Vamos lá, {contaLogada.Nome}!\n");
        //     Console.WriteLine(".______________________________________.");
        //     Console.WriteLine("|  -=-       Login Inicial        -=-  |");
        //     Console.WriteLine("|======================================|");
        //     Console.WriteLine("|Conta Torcedor. . . . . . . . . |  1  |");
        //     Console.WriteLine("|Conta Técnico . . . . . . . . . |  2  |");
        //     Console.WriteLine("|________________________________|_____|");
        //     Console.WriteLine("|VOLTAR. . . . . . . . . . . . . |  0  |");
        //     Console.WriteLine("|======================================|");
        //     string? escolha = Console.ReadLine();

        //     switch (escolha)
        //     {
        //         case "1":
        //             //Linkar Função de Acesso ao Login
        //             break;

        //         case "2":
        //             break;

        //         case "3":
        //             break;

        //         case "4":
        //             break;

        //         case "5":
        //             break;

        //         case "0":
        //             Console.WriteLine("Saindo .............");
        //             return;
        //     }
        // }
    }
}
