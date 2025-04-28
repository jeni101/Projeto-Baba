using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

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

                return posicoes["posicoes_jogadores_futebol"];
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
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

            throw new KeyNotFoundException(nome);
        }
    }
}