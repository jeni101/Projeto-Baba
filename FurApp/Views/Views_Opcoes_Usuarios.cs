using Services.Autenticacao;
using Views.OpcoesMascara;
using Utils.Confirmacao_de_saida;
using Utils.Controle_de_execoesApp;

namespace Views.OpcoesUsuarios
{
    public class Views_Usuarios
    {
        private readonly Autenticador _autenticador;

        public Views_Usuarios(Autenticador autenticador)
        {
            _autenticador = autenticador;
        }
        public async Task Display_User_Partidas()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos,{_autenticador.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄    .       ");
                Console.WriteLine(" |  -=-        Menu Opções de Partidas       -=-  |    .     ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌       .   ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌ .         ");
                Console.WriteLine(" |-                         . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀         .  ");
                Console.WriteLine(" |-                         . . . . . . . . |  2  |           ▐                 ▌            ");
                Console.WriteLine(" |-                         . . . . . . . . |  3  |           ▐  ▐▄▌       ▐▄▌  ▌ Hmmmmmm..  ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █  .        . ");
                Console.WriteLine(" |================================================|         .   ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("  .               .                  .               .           ▐▀▄▄▄   ▄▄▄▀▌ .       .     ");
                Console.WriteLine("       .                     .                                   ▐    ▀▀▀    ▌               ");
                Console.WriteLine("   .                .                       .            .      ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌  .        .  ");
                Console.WriteLine("                                                                                             ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () => //Apitando porque falta coisa pro await
                {
                    await Task.Delay(0);

                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:

                            break;

                        case 2:

                            break;

                        case 3:

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
        public async Task Display_User_Adicionais()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Oque faremos,{_autenticador.PegarNomeConta()}?");
                Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄    .       ");
                Console.WriteLine(" |  -=-        Menu Opções Adicionais        -=-  |    .     ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌       .   ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌ .         ");
                Console.WriteLine(" |-                         . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀         .  ");
                Console.WriteLine(" |-                         . . . . . . . . |  2  |           ▐                 ▌            ");
                Console.WriteLine(" |-                         . . . . . . . . |  3  |           ▐  ▐▄▌       ▐▄▌  ▌ Hmmmmmm..  ");
                Console.WriteLine(" |__________________________________________|_____|           ▐   ▀   ▄▄▄   ▀   ▌            ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █  .        . ");
                Console.WriteLine(" |================================================|         .   ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine("  .               .                  .               .           ▐▀▄▄▄   ▄▄▄▀▌ .       .     ");
                Console.WriteLine("       .                     .                                   ▐    ▀▀▀    ▌               ");
                Console.WriteLine("   .                .                       .            .      ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌  .        .  ");
                Console.WriteLine("                                                                                             ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () => //Apitando porque falta coisa pro await
                {
                    await Task.Delay(0);
                    
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:

                            break;

                        case 2:

                            break;

                        case 3:

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