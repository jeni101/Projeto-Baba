using Services.Autenticacao;
using Views.OpcoesMascara;
using Confirmacao_de_saida;
using Controle_de_execoesApp;

namespace Views.OpcoesAdministrador
{
    public static class Views_Administrador
    {
        public static void Display_Adm_Contas()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos,{Autenticador.Instancia.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄    .       ");
                Console.WriteLine(" |  -=-        Menu Opções de Contas         -=-  |    .     ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌       .   ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌ .         ");
                Console.WriteLine(" |- Criar Nova Conta  . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀         .  ");
                Console.WriteLine(" |- Editar Conta Existente  . . . . . . . . |  2  |        .  ▐   ▄         ▄   ▌ .          ");
                Console.WriteLine(" |- Deletar Conta Existente . . . . . . . . |  3  | .         ▐  ▐█▌       ▐█▌  ▌      .     ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █  .        . ");
                Console.WriteLine(" |================================================|         .   ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("  .               .                  .               .           ▐▀▄▄▄   ▄▄▄▀▌ .       .     ");
                Console.WriteLine("       .                     .                                   ▐    ▀▀▀    ▌               ");
                Console.WriteLine("   .                .                       .            .      ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌  .        .  ");
                Console.WriteLine("                                                                                             ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de Criação de Conta
                            break;

                        case 2:
                            //Linkar Função de Edição de Conta
                            break;

                        case 3:
                            //Linkar Função de Exclusão de Conta
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemVoltando(ref opcao);
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", ref Contador_de_erros);
                if (sair)
                    break;
            }
        }
        public static void Display_Adm_Jogador()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos, {Autenticador.Instancia.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄     .      ");
                Console.WriteLine(" |  -=-       Menu Opções de Jogador         -=-  |     .    ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌        .  ");
                Console.WriteLine(" |- Adicionar Novo Jogador  . . . . . . . . |  1  |        .  ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀  .         ");
                Console.WriteLine(" |- Editar Informações de Jogador . . . . . |  2  |   .       ▐   ▄         ▄   ▌            ");
                Console.WriteLine(" |- Deletar Informações de Jogador  . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌      .     ");
                Console.WriteLine(" |__________________________________________|_____|        .  ▐   ▀   ▄▄▄   ▀   ▌          . ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |     .      █    ▄ ▀█▀ ▄    █ .      .    ");
                Console.WriteLine(" |================================================|          .  ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("    .             .          .               .      .            ▐▀▄▄▄   ▄▄▄▀▌       .     . ");
                Console.WriteLine("          .                         .                    .       ▐    ▀▀▀    ▌   .           ");
                Console.WriteLine("   .               .                     .      .           .   ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌           .  ");
                Console.WriteLine("         .             .       .                       .                            .        ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de Criação de Jogador
                            break;

                        case 2:
                            //Linkar Função de Edição de Jogador
                            break;

                        case 3:
                            //Linkar Função de Exclusão de Jogador
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemVoltando(ref opcao);
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", ref Contador_de_erros);
                if (sair)
                    break;
            }
        }
        public static void Display_Adm_Tecnico()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos, {Autenticador.Instancia.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄         .  ");
                Console.WriteLine(" |  -=-       Menu Opções de Técnico         -=-  |  .       ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌   .       ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌       .   ");
                Console.WriteLine(" |- Adicionar Novo Tecnico  . . . . . . . . |  1  |   .       ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀   .        ");
                Console.WriteLine(" |- Editar Informações de Tecnico . . . . . |  2  |       .   ▐   ▄         ▄   ▌         .  ");
                Console.WriteLine(" |- Deletar Informações de Tecnico  . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌ .          ");
                Console.WriteLine(" |__________________________________________|_____|   .       ▐   ▀   ▄▄▄   ▀   ▌     .      ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █           . ");
                Console.WriteLine(" |================================================|        .    ▀▄   ▀▀ ▀▀   ▄▀  .     .     ");
                Console.WriteLine("            .                        .                           ▐▀▄▄▄   ▄▄▄▀▌            .  ");
                Console.WriteLine("   .                   .                        .          .     ▐    ▀▀▀    ▌   .           ");
                Console.WriteLine("       .                           .                            ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌           .  ");
                Console.WriteLine("                   .                      .          .             .                    .    ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de Criação de Tecnico
                            break;

                        case 2:
                            //Linkar Função de Edição de Tecnico
                            break;

                        case 3:
                            //Linkar Função de Exclusão de Tecnico
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemVoltando(ref opcao);
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", ref Contador_de_erros);
                if (sair)
                    break;
            }
        }
        public static void Display_Adm_Times()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos, {Autenticador.Instancia.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.   .       ▄▀▀▄▄         ▄▄▀▀▄   .        ");
                Console.WriteLine(" |  -=-       Menu Opções de Times           -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|      .   ▐  ▄▀ ▄       ▄ ▀▄  ▌     .     ");
                Console.WriteLine(" |- Adicionar Novo Time . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀          . ");
                Console.WriteLine(" |- Editar Informações de Times . . . . . . |  2  | .         ▐   ▄         ▄   ▌ .          ");
                Console.WriteLine(" |- Deletar Informações de Times  . . . . . |  3  |       .   ▐  ▐█▌       ▐█▌  ▌    .       ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |   .        █    ▄ ▀█▀ ▄    █         .   ");
                Console.WriteLine(" |================================================|         .   ▀▄   ▀▀ ▀▀   ▄▀    .         ");
                Console.WriteLine("        .               .                   .       .            ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine("               .                  .                 .      .     ▐    ▀▀▀    ▌               ");
                Console.WriteLine("      .                  .                .                     ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌    .         ");
                Console.WriteLine("               .                 .           .          .           .         .        .     ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de Criação de Times
                            break;

                        case 2:
                            //Linkar Função de Edição de Times
                            break;

                        case 3:
                            //Linkar Função de Exclusão de Times
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemVoltando(ref opcao);
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", ref Contador_de_erros);
                if (sair)
                    break;
            }
        }
        public static void Display_Adm_Jogos()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos, {Autenticador.Instancia.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.   .       ▄▀▀▄▄         ▄▄▀▀▄      .     ");
                Console.WriteLine(" |  -=-       Menu Opções de Jogos           -=-  |       .  ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Adicionar Novo Jogo . . . . . . . . . . |  1  |    .      ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀   .        ");
                Console.WriteLine(" |- Editar Informações de Jogos . . . . . . |  2  |           ▐   ▄         ▄   ▌         .  ");
                Console.WriteLine(" |- Deletar Informações de Jogos  . . . . . |  3  |.         .▐  ▐█▌       ▐█▌  ▌            ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █      .      ");
                Console.WriteLine(" |================================================|      .      ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("            .            .                  .                    ▐▀▄▄▄   ▄▄▄▀▌  .            ");
                Console.WriteLine("  .                 .           .                    .       .   ▐    ▀▀▀    ▌          .    ");
                Console.WriteLine("      .           .                   .      .                  ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌.             ");
                Console.WriteLine("                                 .                    .                         .            ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de Criação de Jogos
                            break;

                        case 2:
                            //Linkar Função de Edição de Jogos
                            break;

                        case 3:
                            //Linkar Função de Exclusão de Jogos
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemVoltando(ref opcao);
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", ref Contador_de_erros);
                if (sair)
                    break;
            }
        }
        public static void Display_Adm_Partidas()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos, {Autenticador.Instancia.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.   .       ▄▀▀▄▄         ▄▄▀▀▄    .       ");
                Console.WriteLine(" |  -=-       Menu Opções de Partidas        -=-  |        . ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|    .     ▐  ▄▀ ▄       ▄ ▀▄  ▌      .    ");
                Console.WriteLine(" |- Adicionar Nova Partida  . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀          . ");
                Console.WriteLine(" |- Editar Informações de Partidas  . . . . |  2  | .     .   ▐   ▄         ▄   ▌   .        ");
                Console.WriteLine(" |- Deletar Informações de Partidas . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌        .   ");
                Console.WriteLine(" |- Encerrar Partidas . . . . . . . . . . . |  4  |    .      ▐   ▀   ▄▄▄   ▀   ▌   .        ");
                Console.WriteLine(" |__________________________________________|_____|        .   █    ▄ ▀█▀ ▄    █             ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |  .          ▀▄   ▀▀ ▀▀   ▄▀   .      .   ");
                Console.WriteLine(" |================================================|        .     ▐▀▄▄▄   ▄▄▄▀▌               ");
                Console.WriteLine("      .             .                        .                   ▐    ▀▀▀    ▌        .      ");
                Console.WriteLine("                               .                        .       ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌.             ");
                Console.WriteLine("             .            .            .           .            .                 .          ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de Criação de Partidas
                            break;

                        case 2:
                            //Linkar Função de Edição de Partidas
                            break;

                        case 3:
                            //Linkar Função de Exclusão de Partidas
                            break;

                        case 4:
                            //Linkar Função de Encerrar Partidas
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemVoltando(ref opcao);
                            sair = true;
                            break;
                            

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", ref Contador_de_erros);
                if (sair)
                    break;
            }
        }
    }
}