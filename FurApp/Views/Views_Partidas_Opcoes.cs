
// using Models.JogosApp;
// using Services.Jogos;
// using Views.OpcoesMascara;

// namespace Views.PartidasApp
// {
//     public class ViewsPartidas
//     {
//         public static async Task Display_Menu_OpcoesPartidas()
//         {
//             await Task.Delay(0);
//             Console.Clear();
//             View_Inicial.Display_Mascara01();
//             Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄    .       ");
//             Console.WriteLine(" |  -=-       Menu Opções de Partida         -=-  |    .     ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌       .   ");
//             Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌ .         ");
//             Console.WriteLine(" |- Cria Novo Jogo  . . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀         .  ");
//             Console.WriteLine(" |- Ver Jogos Disponíveis . . . . . . . . . |  2  |           ▐   ▄         ▄   ▌            ");
//             Console.WriteLine(" |- Ver Jogos Agendados . . . . . . . . . . |  3  |           ▐  ▐▀▌       ▐▀▌  ▌ Você Sabia ");
//             Console.WriteLine(" |__________________________________________|_____|           ▐       ▄▄▄       ▌ Que eu Amo ");
//             Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |            █    ▄ ▀█▀ ▄    █  . Jogar??. ");
//             Console.WriteLine(" |================================================|         .   ▀▄   ▀███▀   ▄▀              ");
//             Console.WriteLine("   .        .          .          .               .  .           ▐▀▄▄▄   ▄▄▄▀▌ .       .     ");
//             Console.WriteLine("     .                         .      .                          ▐    ▀▀▀    ▌               ");
//             Console.WriteLine("                    .                         .          .      ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌  .        .  ");
//             Console.WriteLine("               .                .       .                     .                      .       ");
//             Console.WriteLine(" • Digite a Opção Desejada: ");
//             string? opcao = Console.ReadLine()?.Trim();
//             if (opcao == "1")
//             {
//                 var jogosServices = new JogosServices();
//                 Jogo? novoJogo = await Jogo.CriarJogo(jogosServices); //Terminar de Implementar o Código

               
//             }
//             else if (opcao == "2")
//             {
//                 //
//             }
//             else if (opcao == "3")
//             {
//                 //
//             }
//             else
//             {
//                 Console.WriteLine("Opção inválida. Tente novamente.");
//                 await Display_Menu_OpcoesPartidas();
//             }

//         }

//         public static async Task Display_Menu_CriacaoJogo()
//         {
//             await Task.Delay(0);
//             Console.Clear();
//             View_Inicial.Display_Mascara01();
//             Console.WriteLine(" .________________________________________________.           ▄▀▀▄▄         ▄▄▀▀▄    .       ");
//             Console.WriteLine(" |  -=-         Menu Criação de Jogo         -=-  |    .     ▐   ▄▄▀▄▄▀▀▀▄▄▀▄▄   ▌       .   ");
//             Console.WriteLine(" |================================================|          ▐  ▄▀ ▄       ▄ ▀▄  ▌ .         ");
//             Console.WriteLine(" |- Selecionar Campo  . . . . . . . . . . . |  1  |           ▀▌ ▀▀ ▀▀▄▄▄▀▀ ▀▀ ▐▀         .  ");
//             Console.WriteLine(" |- Selecionar Nome . . . . . . . . . . . . |  2  |           ▐             ▄   ▌            ");
//             Console.WriteLine(" |- Selecionar Data . . . . . . . . . . . . |  3  |           ▐  ▐█▌       ▐█▌  ▌ Novo Jogo? ");
//             Console.WriteLine(" |- Selecionar Hora . . . . . . . . . . . . |  4  |           ▐   ▀   ▄▄▄   ▀   ▌  Ai Sim!!  ");
//             Console.WriteLine(" |- Selecionar Local  . . . . . . . . . . . |  5  |            █    ▄ ▀█▀ ▄    █  .        . ");
//             Console.WriteLine(" |__________________________________________|_____|         .   ▀▄   ▀▀ ▀▀   ▄▀              ");
//             Console.WriteLine(" |- SAIR  . . . . . . . . . . . . . . . . . |  0  |  .           ▐▀▄▄▄   ▄▄▄▀▌ .       .     ");
//             Console.WriteLine(" |================================================|              ▐    ▀▀▀    ▌               ");
//             Console.WriteLine("   .                .                       .            .      ▐▀▄▄▀▀▄▄▄▀▀▄▄▀▌  .        .  ");
//             Console.WriteLine("         .               .              .               .                       .            ");
//             Console.WriteLine(" • Digite a Opção Desejada: ");

//             //Terminar de Implementar o Código
            
//             // Aqui você pode implementar a lógica para criar um jogo, como selecionar times, data, hora e local.
//         }
//     }
// }
