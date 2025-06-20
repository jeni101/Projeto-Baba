using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;
using Models.TimesApp;
using Views.OpcoesAdministrador;
using Services.Autenticacao;
using Services.Times;
using Services.Jogos;
using Views.OpcoesMascara;
using Utils.Confirmacao_de_saida;
using Utils.Controle_de_execoesApp;
using Utils.Mappers.Usuario;
using DTO.Perfil.Usuario;
using Presentation.Perfil;
using Views.OpcoesUsuarios;

namespace Views.OpcoesContas
{
    public class Views_De_OpcoesContas
    {
        private readonly Autenticador _autenticador;
        private readonly Views_Administrador _viewsAdministrador;
        private readonly Views_Usuarios _viewsUsuarios;
        private readonly TimesServices _timeServices;
        private readonly JogosServices _jogosServices;

        public Views_De_OpcoesContas(Autenticador autenticador, Views_Administrador viewsAdministrador, Views_Usuarios viewsUsuarios, TimesServices timeServices, JogosServices jogosServices)
        {
            _autenticador = autenticador;
            _viewsAdministrador = viewsAdministrador;
            _viewsUsuarios = viewsUsuarios;
            _timeServices = timeServices;
            _jogosServices = jogosServices;
        }

        public async Task Display_MenuAdministrador()
        {
            int[] validos = { 1, 2, 3, 4, 5, 6 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Olá, {_autenticador.PegarNomeConta()}!");
                Console.WriteLine(" .________________________________________________.    .      ▄▀▀▄▄         ▄▄▀▀▄       .    ");
                Console.WriteLine(" |  -=-          Menu Administrador          -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|        . ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Opções de Conta . . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀      .     ");
                Console.WriteLine(" |- Opções de Jogador . . . . . . . . . . . |  2  |     .     ▐   ▄         ▄   ▌ Oque Vamos ");
                Console.WriteLine(" |- Opções de Técnico . . . . . . . . . . . |  3  |       .   ▐  ▐█▌       ▐█▌  ▌Fazer Hoje? ");
                Console.WriteLine(" |- Opções de Time  . . . . . . . . . . . . |  4  |     .     ▐   ▀   ▄▄▄   ▀   ▌Chefinho(a)?");
                Console.WriteLine(" |- Opções de Jogo  . . . . . . . . . . . . |  5  |.           █    ▄ ▀█▀ ▄    █   ╯         ");
                Console.WriteLine(" |- Opções de Partidas  . . . . . . . . . . |  6  |         .   ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine(" |__________________________________________|_____|              ▐▀▄▄▄   ▄▄▄▀▌           .   ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |   .      .   ▐    ▀▀▀    ▌               ");
                Console.WriteLine(" |================================================|             ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌    .         ");
                Console.WriteLine("       .             .            .          .            .            .           .         ");

                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            await _viewsAdministrador.Display_Adm_Contas();
                            break;

                        case 2:
                            await _viewsAdministrador.Display_Adm_Jogador();
                            break;

                        case 3:
                            await _viewsAdministrador.Display_Adm_Tecnico();
                            break;

                        case 4:
                            await _viewsAdministrador.Display_Adm_Times();
                            break;

                        case 5:
                            await _viewsAdministrador.Display_Adm_Jogos();
                            break;

                        case 6:
                            await _viewsAdministrador.Display_Adm_Partidas();
                            break;

                        case 0:
                            int temp = opcao;
                            Confirmacao.ExibirMensagemSaida(ref temp);
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", contador_de_erros);
                if (sair) break;
            }
        }
        public async Task Display_MenuJogador()
        {
            int[] validos = { 1, 2, 3, 4 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Olá, {_autenticador.PegarNomeConta()}!");
                Console.WriteLine(" .________________________________________________.   .       ▄▀▀▄▄         ▄▄▀▀▄    .       ");
                Console.WriteLine(" |  -=-             Menu Jogador             -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌       .   ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Informações do Jogador  . . . . . . . . |  1  |       .   ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀   .        ");
                Console.WriteLine(" |- Entrar em um Time . . . . . . . . . . . |  2  |           ▐   ▄         ▄   ▌  Quais são ");
                Console.WriteLine(" |- Jogos e Partidas  . . . . . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌ os Planos. ");
                Console.WriteLine(" |- Opções Adicionais . . . . . . . . . . . |  4  |   .       ▐   ▀   ▄▄▄   ▀   ▌  de Hoje?  ");
                Console.WriteLine(" |__________________________________________|_____|         .  █    ▄ ▀█▀ ▄    █   ╯         ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |             ▀▄   ▀▀ ▀▀   ▄▀              ");
                Console.WriteLine(" |================================================|      .       ▐▀▄▄▄   ▄▄▄▀▌         .     ");
                Console.WriteLine("   .                .                     .                      ▐    ▀▀▀    ▌ .             ");
                Console.WriteLine("            .                 .                         .       ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌           .  ");
                Console.WriteLine("       .            .             .          .            .            .           .         ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                Conta? contaLogada = _autenticador.PegarContaLogada();

                if (contaLogada is Conta_Usuario usuarioLogado)
                {
                    var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                    {
                        await Task.Delay(0);

                        int opcao = int.Parse(escolha ?? "");
                        switch (opcao)
                        {
                            case 1:
                                PerfilUsuarioDTO perfilDTO = MapperUsuario.ToPerfilUsuarioDTO(usuarioLogado);
                                PresenterPerfil.ExibirPerfil(perfilDTO);
                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                Console.ReadKey();
                                break;

                            case 2:
                                // linkar Função de Entrar em um time
                                break;

                            case 3:
                                await _viewsUsuarios.Display_User_Partidas();
                                break;

                            case 4:
                                await _viewsUsuarios.Display_User_Adicionais();
                                break;

                            case 0:
                                Confirmacao.ExibirMensagemSaida(ref opcao);
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
        public async Task Display_MenuTecnico()
        {
            int[] validos = { 1, 2, 3, 4 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Olá, {_autenticador.PegarNomeConta()}!");
                Console.WriteLine(" .________________________________________________.     .     ▄▀▀▄▄         ▄▄▀▀▄         .  ");
                Console.WriteLine(" |  -=-             Menu Tecnico             -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌    .      ");
                Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Informações do Tecnic . . . . . . . . . |  1  |       .   ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀        .   ");
                Console.WriteLine(" |- Criar / Gerenciar Time  . . . . . . . . |  2  |  .        ▐   ▄         ▄   ▌Opa! Qual é ");
                Console.WriteLine(" |- Criar / Entrar em um Jogo . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌ a Novidade ");
                Console.WriteLine(" |- Pesquisar Jogador . . . . . . . . . . . |  4  |      .    ▐   ▀   ▄▄▄   ▀   ▌ de Hoje?   ");
                Console.WriteLine(" |__________________________________________|_____|  .         █    ▄ ▀█▀ ▄    █    ╯        ");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |             ▀▄   ▀▀ ▀▀   ▄▀   .          ");
                Console.WriteLine(" |================================================|       .      ▐▀▄▄▄   ▄▄▄▀▌          .    ");
                Console.WriteLine("      .                    .                 .                   ▐    ▀▀▀    ▌               ");
                Console.WriteLine("                .                   .                     .     ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌      .       ");
                Console.WriteLine("       .            .             .          .            .            .           .         ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                Conta? contaLogada = _autenticador.PegarContaLogada();

                if (contaLogada is Conta_Tecnico tecnicoLogado)
                {
                    var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                    {
                        await Task.Delay(0);

                        int opcao = int.Parse(escolha ?? "");
                        switch (opcao)
                        {
                            case 1:
                                PerfilUsuarioDTO perfilDTO = MapperUsuario.ToPerfilUsuarioDTO(tecnicoLogado);
                                PresenterPerfil.ExibirPerfil(perfilDTO);
                                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                                Console.ReadKey();
                                break;

                            case 2:
                                await CriarTimeParaTecnico(tecnicoLogado);
                                break;

                            case 3:
                                //Linkar Função de Criação/Entrada em Jogos
                                break;

                            case 4:
                                //Linkar Função de Pesquisa de Perfil de Jogador (Mostrar Informações)
                                break;

                            case 0:
                                Confirmacao.ExibirMensagemSaida(ref opcao);
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

        private async Task CriarTimeParaTecnico(Conta_Tecnico tecnicoLogado)
        {
            Console.Clear();
            View_Inicial.Display_Mascara01();
            Console.WriteLine("--- Criar Novo Time ---");

            Console.Write("Digite o nome do time: ");
            string? nomeTime = Console.ReadLine();

            Console.Write("Digite a abreviação do time (ex: FLA, SAO): ");
            string? abreviacaoTime = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeTime) || string.IsNullOrWhiteSpace(abreviacaoTime))
            {
                Console.WriteLine("Nome e abreviação não podem ser vazios. Tente novamente.");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
                return;
            }

            Time? novoTime = await _timeServices.CriarTime(nomeTime, abreviacaoTime, tecnicoLogado);

            if (novoTime != null)
            {
                Console.WriteLine($"Time '{novoTime.Nome}' criado com sucesso!");
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
