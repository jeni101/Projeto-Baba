using System;
using Models;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;
using Models.JogosApp;
using Views.OpcoesAdministrador;
using Services.Autenticacao;
using Views.OpcoesMascara;
using Utils.Confirmacao_de_saida;
using Utils.Controle_de_execoesApp;

namespace Views.OpcoesContas
{
    public class Views_De_OpcoesContas
    {
        public async Task Display_MenuAdministrador()
        {
            int[] validos = { 1, 2, 3, 4, 5, 6 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Olá, {Autenticador.Instancia.PegarNomeConta()}!");
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
                            await Views_Administrador.Display_Adm_Contas();
                            break;

                        case 2:
                            await Views_Administrador.Display_Adm_Jogador();
                            break;

                        case 3:
                            await Views_Administrador.Display_Adm_Tecnico();
                            break;

                        case 4:
                            await Views_Administrador.Display_Adm_Times();
                            break;

                        case 5:
                            await Views_Administrador.Display_Adm_Jogos();
                            break;

                        case 6:
                            await Views_Administrador.Display_Adm_Partidas();
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
                Console.WriteLine($"• Olá, {Autenticador.Instancia.PegarNomeConta()}!");
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

                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                {
                    await Task.Delay(0);

                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //linkar Função de ExibirPerfil do Jogador
                            break;

                        case 2:
                            // linkar Função de Entrar em um time
                            break;

                        case 3:
                            // Vou linkar MENU de Informações de Partidas
                            break;

                        case 4:
                            // Vou linkar MENU de Opções Adicionais
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
        public async Task Display_MenuTecnico()
        {
            int[] validos = { 1, 2, 3, 4 };
            bool sair = false;
            int contador_de_erros = 0;

            while (!sair)
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine($"• Olá, {Autenticador.Instancia.PegarNomeConta()}!");
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
                
                var HouveErro = await ControleDeExecoes.ExecutarComTratamento(async () =>
                {
                    await Task.Delay(0);
                    
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            //Linkar Função de ExibirPerfil do tecnico
                            break;

                        case 2:
                            //Linkar Função de Gerenciamento/Criação de Time
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
}
