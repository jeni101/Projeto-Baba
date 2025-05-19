namespace Views.OpcoesAdministrador
{
    public static class Views_Administrador
    {
        public static void Display_Adm_Contas()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"• Oque faremos, (contaLogada.Nome)? \n"); //Criar Função que Mostra o nome do usuário
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄            ");
                Console.WriteLine(" |  -=-            Menu de Contas            -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Criar Nova Conta  . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀            ");
                Console.WriteLine(" |- Editar Conta Existente  . . . . . . . . |  2  |           ▐   ▄         ▄   ▌            ");
                Console.WriteLine(" |- Deletar Conta Existente . . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌            ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █             ");
                Console.WriteLine(" |================================================|             ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("                                                                 ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine("                                                                 ▐    ▀▀▀    ▌               ");
                Console.WriteLine("                                                                ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌              ");
                Console.WriteLine("                                                                                             ");
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
                        //Linkar Função de Exclusão de Conta
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
        public static void Display_Adm_Jogador()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"• Oque faremos, (contaLogada.Nome)? \n"); //Criar Função que Mostra o nome do usuário
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄            ");
                Console.WriteLine(" |  -=-           Menu de Jogador            -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Adicionar Novo Jogador  . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀            ");
                Console.WriteLine(" |- Editar Informações de Jogador . . . . . |  2  |           ▐   ▄         ▄   ▌            ");
                Console.WriteLine(" |- Deletar Informações de Jogador  . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌            ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █             ");
                Console.WriteLine(" |================================================|             ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("                                                                 ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine("                                                                 ▐    ▀▀▀    ▌               ");
                Console.WriteLine("                                                                ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌              ");
                Console.WriteLine("                                                                                             ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        //Linkar Função de Criação de Jogador
                        break;

                    case "2":
                        //Linkar Função de Edição de Jogador
                        break;

                    case "3":
                        //Linkar Função de Exclusão de Jogador
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