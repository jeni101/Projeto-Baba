using Services.Autenticacao;
using Services.Register;
using Views.OpcoesMascara;
using Views.OpcoesContas;
using Utils.Confirmacao_de_saida;
using Utils.Controle_de_execoesApp;
using Models.ContaApp;
using Models.ContaApp.ADM;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;

namespace Views.Contas
{
    public class Views_De_Contas
    {
        private readonly Autenticador _autenticador;
        private readonly Registro _registro;
        private readonly Views_De_OpcoesContas _menuContas;

        public Views_De_Contas(Autenticador autenticador, Registro registro, Views_De_OpcoesContas menuContas)
        {
            _autenticador = autenticador;
            _registro = registro;
            _menuContas = menuContas;
        }

        public async Task DisplayMenu_LoginInicial()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair) //aqui pode só ser true
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine(" • Olá! Seleciona uma Opção Abaixo: ");
                Console.WriteLine(" .________________________________________________.    .      ▄▀▀▄▄         ▄▄▀▀▄       .    ");
                Console.WriteLine(" |  -=-           Opções de Login            -=-  |          ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌           ");
                Console.WriteLine(" |================================================|        . ▐  ▄▀ ▄       ▄ ▀▄  ▌           ");
                Console.WriteLine(" |- Novo Usuário  . . . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀      .     ");
                Console.WriteLine(" |- Usuário Existente . . . . . . . . . . . |  2  |     .     ▐   ▄         ▄   ▌  Olá! Seja ");
                Console.WriteLine(" |__________________________________________|_____|       .   ▐  ▐▀▌       ▐▀▌  ▌Bem-Vindo(a)");
                Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |     .     ▐       ▄▄▄       ▌ ao FurApp! ");
                Console.WriteLine(" |================================================|.           █    ▄ ▀█▀ ▄    █    ╯        ");
                Console.WriteLine("  .          .                       .                          ▀▄   ▀███▀   ▄▀   .          ");
                Console.WriteLine("                    .                                     .      ▐▀▄▄▄   ▄▄▄▀▌          .    ");
                Console.WriteLine("      .                    .                 .                   ▐    ▀▀▀    ▌               ");
                Console.WriteLine("                .                                         .     ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌      .       ");
                Console.WriteLine("       .            .             .          .            .            .           .         ");
                Console.WriteLine(" • Digite a Opção Desejada: ");
                string? escolha = Console.ReadLine();

                //Transformei em var para não considerar como false ou true quando a opção funcionar
                //ps.: Se quiser ser mais expecifico, chame de ExecutarComTratamentoAsync, aqui e na funcao, pela boa prática
               var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            await _registro.RegistrarAsync();
                            break;

                        case 2:
                            Conta? contaLogada = await _autenticador.LoginAsync();

                            if (contaLogada != null)
                            {
                                if (contaLogada is Conta_Administrador adm)
                                {
                                    Console.WriteLine("Redirecionando para o menu do Administrador...");
                                    await _menuContas.Display_MenuAdministrador();
                                }
                                else if (contaLogada is Conta_Jogador jogador)
                                {
                                    Console.WriteLine("Redirecionando para o menu do Jogador...");
                                    await _menuContas.Display_MenuJogador();
                                }
                                else if (contaLogada is Conta_Tecnico tecnico)
                                {
                                    Console.WriteLine("Redirecionando para o menu do Técnico...");
                                    await _menuContas.Display_MenuTecnico();
                                }
                            }
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemSaida(ref opcao); //Se quiser, faz uma "opcaoSaida" para não congestionar
                            sair = true;
                            break;

                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }, escolha ?? "", contador_de_erros);
                if (sair) break; //Deixei em uma linha só, mas vai de sua escolha
            }
        }
    }
}
