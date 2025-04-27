using System;
using PersistenciaApp;
using System.Linq;
using ContaJogadorApp;

namespace TimesApp
{
    public class Times
    {
        public void ListarTimes(string nomeJogador)
        {
            var contas = PersistenciaDeContas.CarregarContasAgrupadas();

            // Verifica se tem jogadores
            if (contas.TryGetValue("Jogador", out var listaContas))
            {
                // Procura o jogador pelo nome
                var jogadorBase = listaContas.FirstOrDefault(c => c.Nome == nomeJogador);

                // Faz o cast para ContaJogador - ou seja converter o objeto de conta p contaJOgador p acesar oq tem la, no caso a variavel time q so existe em contaJOgador
                if (jogadorBase is ContaJogador jogador)
                {
                    Console.WriteLine($"{jogador.Nome} está inscrito nos seguintes times:");

                    // Percorre a lista de times, print de cada item mas e se for 1 so vai prentar letra por letra
                    foreach (var time in jogador.Time)
                    {
                        Console.WriteLine(time);
                        
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Jogador não encontrado ou não é do tipo esperado.");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma conta de jogador foi encontrada.");
            }
        }
    }
}
