using ContaJogadorApp;
using JogosApp;

namespace Views.Contas
{
    public class Views_De_Contas
    {
        private Conta_Jogador contaLogada;

        public Views_De_Contas(Conta_Jogador conta)
        {
            contaLogada = conta;
        }
        public void DisplayMenu_LoginInicial()
        {
            while (true)
            {
                Console.WriteLine(".______________________________________.");
                Console.WriteLine("|  -=-       Login Inicial        -=-  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|Novo Usuário. . . . . . . . . . |  1  |");
                Console.WriteLine("|Usuário Existente . . . . . . . |  2  |");
                Console.WriteLine("|________________________________|_____|");
                Console.WriteLine("|SAIR. . . . . . . . . . . . . . |  0  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
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
                        Console.Write("Tem certeza que desejas sair? (S/N): ");
                        string? confirmacao = Console.ReadLine();

                        if (!string.IsNullOrEmpty(confirmacao) && confirmacao.Trim().ToUpper() == "S")
                        {
                            Console.WriteLine("Saindo...");
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
        public void DisplayMenu_Contas()
        {
            while (true)
            {
                Console.WriteLine($"Vamos lá, {contaLogada.Nome}!\n");
                Console.WriteLine(".______________________________________.");
                Console.WriteLine("|  -=-       Menu de Contas       -=-  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|Criar Nova Conta. . . . . . . . |  1  |");
                Console.WriteLine("|Editar Conta Existente. . . . . |  2  |");
                Console.WriteLine("|Deletar Conta Existente . . . . |  3  |");
                Console.WriteLine("|________________________________|_____|");
                Console.WriteLine("|VOLTAR. . . . . . . . . . . . . |  0  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        //Linkar Função de Criação de Conta
                        break;

                    case "2":
                        //Linkar Função de Edição de Conta
                        break;

                    case "3":
                        //Linkar Função de Remover Conta
                        break;

                    case "0":
                        Console.Write("Tem certeza que desejas sair? (S/N): ");
                        string? confirmacao = Console.ReadLine();

                        if (!string.IsNullOrEmpty(confirmacao) && confirmacao.Trim().ToUpper() == "S")
                        {
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
