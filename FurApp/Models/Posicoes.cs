using System.Text.Json;
/*
namespace PosicoesApp
{
    public class Posicao
    {
        private const string CaminhoArquivo = "../Database/posicoes.json";

        public Dictionary<string, List<Dictionary<string, string>>> PegarPosicoes()
        {
            try
            {
                var json = File.ReadAllText(CaminhoArquivo);
                var posicoes = JsonSerializer.Deserialize<Dictionary<string, Dictionary<string, List<Dictionary<string, string>>>>>(json);

                if (posicoes != null && posicoes.ContainsKey("posicoes_jogadores_futebol"))
                {
                    return posicoes["posicoes_jogadores_futebol"];
                }
                throw new KeyNotFoundException("A chave 'posicoes_jogadores_futebol' não foi encontrada no arquivo JSON.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao carregar posições: {ex.Message}");
            }
        }

        public string Abreviacoes(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome da posição não pode ser nulo ou vazio.");
            }

            var categorias = PegarPosicoes();

            foreach (var categoria in categorias.Values)
            {
                var posicao = categoria.FirstOrDefault(p => p.ContainsKey("nome") && p["nome"].Equals(nome, StringComparison.OrdinalIgnoreCase));
                if (posicao != null && posicao.ContainsKey("abreviacao"))
                {
                    return posicao["abreviacao"];
                }
            }

            throw new KeyNotFoundException($"Posição '{nome}' não encontrada.");
        }

        public void ListarPosicoes()
        {
            var categorias = PegarPosicoes();

            Console.WriteLine("Posições disponíveis:");
            foreach (var categoria in categorias)
            {
                Console.WriteLine($"\nCategoria: {categoria.Key}");
                foreach (var posicao in categoria.Value)
                {
                    Console.WriteLine($"- Nome: {posicao["nome"]}, Abreviação: {posicao["abreviacao"]}");
                }
            }
        }

        public Dictionary<string, string> EscolherPosicao()
        {
            var categorias = PegarPosicoes();

            ListarPosicoes();

            Console.Write("\nDigite o nome ou abreviação da posição desejada: ");
            string escolha = Console.ReadLine()?.Trim() ?? "0";

            if (string.IsNullOrWhiteSpace(escolha))
            {
                throw new ArgumentException("Entrada inválida. Por favor, digite o nome ou abreviação da posição.");
            }

            foreach (var categoria in categorias.Values)
            {
                var posicao = categoria.FirstOrDefault(p =>
                    p.ContainsKey("nome") && p["nome"].Equals(escolha, StringComparison.OrdinalIgnoreCase) ||
                    p.ContainsKey("abreviacao") && p["abreviacao"].Equals(escolha, StringComparison.OrdinalIgnoreCase));

                if (posicao != null)
                {
                    Console.WriteLine($"\nPosição selecionada: {posicao["nome"]} ({posicao["abreviacao"]})");
                    return posicao; 
                }
            }

            throw new KeyNotFoundException($"Posição '{escolha}' não encontrada. Tente novamente.");
        }
    }
}


//Abaixo exemplo de uso no Programa
/*
using System;

namespace PosicoesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var posicaoManager = new Posicao();

                Console.WriteLine("Bem-vindo ao sistema de seleção de posições!");
                var posicaoEscolhida = posicaoManager.EscolherPosicao();

                Console.WriteLine("\nDetalhes da posição escolhida:");
                Console.WriteLine($"Nome: {posicaoEscolhida["nome"]}");
                Console.WriteLine($"Abreviação: {posicaoEscolhida["abreviacao"]}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }
        }
    }
}
*/