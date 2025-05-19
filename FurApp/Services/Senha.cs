using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Utils.Pelase.CensuradorDeSenha;

namespace Services.Senha
{
    public static class ObtencaoSenha
    {
        private const int TamanhoMinimo = 8;
        private const int TentativasMax = 3;

        public static string DefinirSenha()
        {
            for (int tentativas = 1; tentativas <= TentativasMax; tentativas++)
            {
                Console.Write($"Digite sua senha (mínimo {TamanhoMinimo} caracteres): ");
                string senha = Console.ReadLine() ?? string.Empty;

                Console.Write("Confirme a senha: ");
                string confirmacao = Console.ReadLine() ?? string.Empty;

                try
                {
                    ValidarSenha(senha, confirmacao);
                    return senha;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine($"Tentativas restantes: {TentativasMax - tentativas}");
                }
            }

            throw new InvalidOperationException("Número máximo de tentativas excedido");
        }

        public static void ValidarSenha(string senha, string confirmacao)
        {
            if (senha.Length < TamanhoMinimo)
                throw new ArgumentException($"Senha deve possuir pelo menos {TamanhoMinimo} caracteres");

            if (senha != confirmacao)
                throw new ArgumentException("As senhas não coincidem");
        }

        public static string CensurarSenha(string senha)
        {
            return CensuradorDeSenha.HashPassword(senha);
        }
    }
}