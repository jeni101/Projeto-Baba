using System;
using Models;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;
using Models.JogosApp;
using Services.Autenticacao;
using Views.OpcoesMascara;
using Confirmacao_de_saida;

namespace Views.Contas
{
    public class Views_De_Contas
    {
        public void DisplayMenu_LoginInicial()
        {
            int[] validos = { 1, 2 };
            bool sair = false;
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

                int opcao = int.Parse(escolha ?? "");
                switch (opcao)
                {
                    case 1:
                        //Linkar Função de Criação de Novo Usuário
                        break;

                    case 2:
                        //Linkar Função de Verificação de Usuario
                        break;

                    case 0:
                        Confirmacao.ExibirMensagemSaida(ref opcao);
                        sair = true;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}
