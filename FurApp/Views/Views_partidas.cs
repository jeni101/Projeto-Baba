using System;
using Models.JogosApp;
using Services.Jogos;

namespace Views.PartidasApp
{
    public class ViewsPartidas
    {
        public static async Task DisplayOpcoesPartidas()
        {
            await Task.Delay(0);

            Console.WriteLine("""
            Selecione uma opção:
            1. Criar Jogo
            2. Ver jogos disponiveis
            3. Ver jogos agendados
            """);
            string? opcao = Console.ReadLine()?.Trim();
            if (opcao == "1")
            {
                var jogosServices = new JogosServices();
                Jogo? novoJogo = await Jogo.CriarJogo(jogosServices);

               
            }
            else if (opcao == "2")
            {
                //
            }
            else if (opcao == "3")
            {
                //
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
                await DisplayOpcoesPartidas();
            }

        }

        public static async Task DisplayCriacaoJogo()
        {
            await Task.Delay(0);

            Console.WriteLine("""
            Criar Jogo:
            1. selecionar Campo
            2. Selecionar Nome
            3. Selecionar Data
            4. Selecionar Hora
            5. Selecionar Local
            """);
            
            // Aqui você pode implementar a lógica para criar um jogo, como selecionar times, data, hora e local.
        }
    }
}
