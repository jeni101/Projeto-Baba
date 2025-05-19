using System;

namespace Confirmacao_de_saida
{
    public class Confirmacao
    {
        public static bool ExibirMensagemSaida(ref int escolha)
        {
            if (escolha != 0) return false;

            while (true)
            {
                Console.WriteLine("Tem certeza que deseja sair de sua conta? (S/N)");
                string resposta = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (resposta == "S")
                {
                    Console.Clear();
                    AnimacaoApp.SairAnimados.ExibirMensagemSaida2();
                    return true; // Saiu
                }
                else if (resposta == "N")
                {
                    return true; // Cancelou saída
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Comando errado, tente novamente.\n");
                }
            }
        }
        public static bool ExibirMensagemVoltando(ref int escolha)
        {
            if (escolha != 0) return false;

            while (true)
            {
                Console.WriteLine("Tem certeza que deseja voltar? (S/N)");
                string resposta = Console.ReadLine()?.Trim().ToUpper() ?? "";

                if (resposta == "S")
                {
                    Console.Clear();
                    AnimacaoApp.SairAnimados.ExibirMensagemVoltar();
                    return true; // Saiu
                }
                else if (resposta == "N")
                {
                    return true; // Cancelou saída
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Comando errado, tente novamente.\n");
                }
            }
        }
    }
}
