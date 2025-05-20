using System;
using Models;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;
using Models.JogosApp;
using Services.Autenticacao;
using Services.Register;
using Views.OpcoesMascara;
using Confirmacao_de_saida;
using System.Threading.Tasks;
using Controle_de_execoesApp;

namespace Views.Contas
{
    public class Views_De_Contas
    {
        public async Task DisplayMenu_LoginInicial()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
            int Contador_de_erros = 0;

            while (!sair)
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

                bool HouveErro = ControleDeExecoes.ExecutarComTratamento(() =>
                {
                    int opcao = int.Parse(escolha ?? "");
                    switch (opcao)
                    {
                        case 1:
                            await Registro.Instancia.RegistrarAsync();
                            break;

                        case 2:
                            await Autenticador.Instancia.LoginAsync();
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemSaida(ref opcao);
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
