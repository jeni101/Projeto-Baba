using ContaApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;

namespace PersistenciaApp
{
    public static class PersistenciaDeContas
    {
        private static string caminhoArquivo = "../Database/dados.json";
        private static bool modoDebug = true;

        // Salva as contas agrupadas por tipo
        public static void SalvarContas(List<Conta> novasContas)
        {
            var contasPorTipo = CarregarContasAgrupadas(); // Dicionário: tipo -> contas

            foreach (var conta in novasContas)
            {
                var tipo = ObterTipoDaConta(conta);

                if (!contasPorTipo.ContainsKey(tipo))
                    contasPorTipo[tipo] = new List<Conta>();

                contasPorTipo[tipo].Add(conta);
            }

            var configuracoes = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
                Formatting = modoDebug ? Formatting.Indented : Formatting.None
            };

            var json = JsonConvert.SerializeObject(contasPorTipo, configuracoes);
            File.WriteAllText(caminhoArquivo, json);
        }

        // Carrega todas as contas em uma lista única (útil pra cadastro)
        public static List<Conta> CarregarContas()
        {
            var contasAgrupadas = CarregarContasAgrupadas();
            var todasContas = new List<Conta>();

            foreach (var lista in contasAgrupadas.Values)
                todasContas.AddRange(lista);

            return todasContas;
        }

        // Carrega contas agrupadas por tipo (útil pro login otimizado)
        public static Dictionary<string, List<Conta>> CarregarContasAgrupadas()
        {
            if (!File.Exists(caminhoArquivo))
                return new Dictionary<string, List<Conta>>();

            var json = File.ReadAllText(caminhoArquivo);

            return JsonConvert.DeserializeObject<Dictionary<string, List<Conta>>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }) ?? new Dictionary<string, List<Conta>>();
        }

        // Identifica o tipo da conta com base no nome da classe
        private static string ObterTipoDaConta(Conta conta)
        {
            if (conta == null) return "Desconhecido";
            
            if (conta is ContaJogador) return "Jogador";
            if (conta is ContaTecnico) return "Tecnico";
            if (conta is ContaArbitro) return "Arbitro";
            

            return "Desconhecido";
        }

    }
}
