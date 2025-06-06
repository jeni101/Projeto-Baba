using Utils.Controle_de_execoesApp;
using Utils.Confirmacao_de_saida;
using Views.OpcoesMascara;

namespace Views.Partidas
{
    public class Views_Partidas
    {
        public async Task Display_InfoPartidas_22()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();                         //  Aqui precisa fazer Bastante coisa, Como por exemplo:
                View_Inicial.Display_Mascara01();        //    Adicionar Times no Rodapé, Placar Automático, Listar cada jogador e Linkar funções dos botões
                Console.WriteLine(" .____________________ Placar ____________________.");
                Console.WriteLine(" |-=-    Time A        0  X  0     Time B      -=-|");
                Console.WriteLine(" |========================|=======================|   . ._______________________________.  . ");
                Console.WriteLine(" | - Tecnico              | - Tecnico             |     |-      |  |         |  |      -|    ");
                Console.WriteLine(" | - jogador 1            | - Jogador 1           |  .  |       |  ˙‾‾‾‾-‾‾‾‾˙  |       |    ");
                Console.WriteLine(" | - jogador 2            | - Jogador 2           |     |       ˙‾‾‾‾‾-----‾‾‾‾‾˙       |.   ");
                Console.WriteLine(" | - jogador 3            | - Jogador 3           |   . |                               |    ");
                Console.WriteLine(" | - jogador 4            | - Jogador 4           |     |                               |    ");
                Console.WriteLine(" | - jogador 5            | - Jogador 5           | .   |            __---__            |    ");
                Console.WriteLine(" | - jogador 6            | - Jogador 6           |     |           |       |           |    ");
                Console.WriteLine(" | - jogador 7            | - Jogador 7           |   . |==========|=== - ===|==========|  . ");
                Console.WriteLine(" | - jogador 8            | - Jogador 8           |     |           |       |           |    ");
                Console.WriteLine(" | - jogador 9            | - Jogador 9           | .   |            ‾‾---‾‾            |    ");
                Console.WriteLine(" | - jogador 10           | - Jogador 10          |     |                               |    ");
                Console.WriteLine(" | - jogador 11           | - Jogador 11          |    .|                               |    ");
                Console.WriteLine(" |================================================|     |       ._____-----_____.       | .  ");
                Console.WriteLine(" .-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=.     |       |  .____-____.  |       |    ");
                Console.WriteLine(" |- Adicionar Gol . |  1  |-                |  2  |  .  |-      |  |         |  |      -|    ");
                Console.WriteLine(" |==================|=====|=================|=====| .   ˙‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾˙  . ");
                Console.WriteLine(" |- Encerrar  . . . |  3  |- Voltar . . . . |  0  |              .         .        .        ");
                Console.WriteLine(" |================================================| .       .            .              .    ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                 {
                     int opcao = int.Parse(escolha ?? "");
                     switch (opcao)
                     {
                         case 1:
                             //linkar Função de Adicionar Gol
                             break;

                         case 2:
                             //Linkar Função Extra
                             break;

                         case 3:
                             //Linkar Função de Encerrar Partida
                             break;

                         case 0:
                             Confirmacao.ExibirMensagemVoltando(ref opcao);
                             sair = true;
                             break;

                         default:
                             throw new ArgumentOutOfRangeException();
                     }
                 }, escolha ?? "", contador_de_erros);
                if (sair) break;
            }
        }
        public async Task Display_InfoPartidas_14()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();                         //  Aqui precisa fazer Bastante coisa, Como por exemplo:
                View_Inicial.Display_Mascara01();        //    Adicionar Times no Rodapé, Placar Automático, Listar cada jogador e Linkar funções dos botões
                Console.WriteLine(" .____________________ Placar ____________________.");
                Console.WriteLine(" |-=-    Time A        0  X  0     Time B      -=-|");
                Console.WriteLine(" |========================|=======================|   . ._______________________________.  . ");
                Console.WriteLine(" | - Tecnico              | - Tecnico             |     |-      |  |         |  |      -|    ");
                Console.WriteLine(" | - jogador 1            | - Jogador 1           |  .  |       |  ˙‾‾‾‾-‾‾‾‾˙  |       |    ");
                Console.WriteLine(" | - jogador 2            | - Jogador 2           |     |       ˙‾‾‾‾‾-----‾‾‾‾‾˙       |.   ");
                Console.WriteLine(" | - jogador 3            | - Jogador 3           |   . |                               |    ");
                Console.WriteLine(" | - jogador 4            | - Jogador 4           |     |                               |    ");
                Console.WriteLine(" | - jogador 5            | - Jogador 5           | .   |            __---__            |    ");
                Console.WriteLine(" | - jogador 6            | - Jogador 6           |     |           |       |           |    ");
                Console.WriteLine(" | - jogador 7            | - Jogador 7           |   . |==========|=== - ===|==========|  . ");
                Console.WriteLine(" |                        |                       |     |           |       |           |    ");
                Console.WriteLine(" |================================================| .   |            ‾‾---‾‾            |    ");
                Console.WriteLine(" .-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=.     |                               |    ");
                Console.WriteLine(" |- Adicionar Gol . |  1  |-                |  2  |    .|                               |    ");
                Console.WriteLine(" |==================|=====|=================|=====|     |       ._____-----_____.       | .  ");
                Console.WriteLine(" |- Encerrar  . . . |  3  |- Voltar . . . . |  0  |     |       |  .____-____.  |       |    ");
                Console.WriteLine(" |================================================|  .  |-      |  |         |  |      -|    ");
                Console.WriteLine("                                                    .   ˙‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾˙  . ");
                Console.WriteLine(" • Digite a Opção Desejada:                                      .         .        .        ");
                string? escolha = Console.ReadLine();

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                 {
                     int opcao = int.Parse(escolha ?? "");
                     switch (opcao)
                     {
                         case 1:
                             //linkar Função de Adicionar Gol
                             break;

                         case 2:
                             //Linkar Função Extra
                             break;

                         case 3:
                             //Linkar Função de Encerrar Partida
                             break;

                         case 0:
                             Confirmacao.ExibirMensagemVoltando(ref opcao);
                             sair = true;
                             break;

                         default:
                             throw new ArgumentOutOfRangeException();
                     }
                 }, escolha ?? "", contador_de_erros);
                if (sair) break;
            }
        }
        public async Task Display_InfoPartidas_10()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();                         //  Aqui precisa fazer Bastante coisa, Como por exemplo:
                View_Inicial.Display_Mascara01();        //    Adicionar Times no Rodapé, Placar Automático, Listar cada jogador e Linkar funções dos botões
                Console.WriteLine(" .____________________ Placar ____________________.");
                Console.WriteLine(" |-=-    Time A        0  X  0     Time B      -=-|");
                Console.WriteLine(" |========================|=======================|   . ._______________________________.  . ");
                Console.WriteLine(" | - Tecnico              | - Tecnico             |     |-      |  |         |  |      -|    ");
                Console.WriteLine(" | - jogador 1            | - Jogador 1           |  .  |       |  ˙‾‾‾‾-‾‾‾‾˙  |       |    ");
                Console.WriteLine(" | - jogador 2            | - Jogador 2           |     |       ˙‾‾‾‾‾-----‾‾‾‾‾˙       |.   ");
                Console.WriteLine(" | - jogador 3            | - Jogador 3           |   . |                               |    ");
                Console.WriteLine(" | - jogador 4            | - Jogador 4           |     |                               |    ");
                Console.WriteLine(" | - jogador 5            | - Jogador 5           | .   |            __---__            |    ");
                Console.WriteLine(" |                        |                       |     |           |       |           |    ");
                Console.WriteLine(" |================================================|   . |==========|=== - ===|==========|  . ");
                Console.WriteLine(" .-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=.     |           |       |           |    ");
                Console.WriteLine(" |- Adicionar Gol . |  1  |-                |  2  | .   |            ‾‾---‾‾            |    ");
                Console.WriteLine(" |==================|=====|=================|=====|     |                               |    ");
                Console.WriteLine(" |- Encerrar  . . . |  3  |- Voltar . . . . |  0  |    .|                               |    ");
                Console.WriteLine(" |================================================|     |       ._____-----_____.       | .  ");
                Console.WriteLine("                                                        |       |  .____-____.  |       |    ");
                Console.WriteLine("  • Digite a Opção Desejada:                         .  |-      |  |         |  |      -|    ");
                Console.WriteLine("                                                    .   ˙‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾˙  . ");
                string? escolha = Console.ReadLine();

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                 {
                     int opcao = int.Parse(escolha ?? "");
                     switch (opcao)
                     {
                         case 1:
                            //linkar Função de Adicionar Gol
                             break;

                         case 2:
                            //Linkar Função Extra
                             break;

                         case 3:
                            //Linkar Função de Encerrar Partida
                             break;

                         case 0:
                             Confirmacao.ExibirMensagemVoltando(ref opcao);
                             sair = true;
                             break;

                         default:
                             throw new ArgumentOutOfRangeException();
                     }
                 }, escolha ?? "", contador_de_erros);
                if (sair) break;
            }
        }
    }
}
