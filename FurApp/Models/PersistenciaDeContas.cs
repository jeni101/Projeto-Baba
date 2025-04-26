using ContaApp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace PersistenciaApp
{
    public static class PersistenciaDeContas
    {
        // Caminho pro arquivo onde vai salvar os dados
        private static string caminhoArquivo = "../Database/dados.json";

        // Modo debug: se true, deixa o JSON identado bonitinho
        private static bool modoDebug = true;

        // Salva novas contas, mantendo as antigas
        public static void SalvarContas(List<Conta> novasContas)
        {
            // Carrega as contas existentes (se houver)
            var contasAtuais = CarregarContas();

            // Junta as novas com as antigas
            contasAtuais.AddRange(novasContas);

            // Configurações pra serialização do JSON
            var configuracoes = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple, // aqui ja deixa um pouco menos poluido
                Formatting = modoDebug ? Formatting.Indented : Formatting.None // identa se tiver no debug se n manda poluido mesmo
            };

            // Converte pra JSON com as configuracoes
            var json = JsonConvert.SerializeObject(contasAtuais, configuracoes);

            // Salva no arquivo
            File.WriteAllText(caminhoArquivo, json);
        }

        // Carrega as contas do arquivo
        public static List<Conta> CarregarContas()
        {
            if (!File.Exists(caminhoArquivo))
                return new List<Conta>(); // Se não tiver nada, começa vazio

            var json = File.ReadAllText(caminhoArquivo);

            return JsonConvert.DeserializeObject<List<Conta>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }) ?? new List<Conta>();
        }
    }
}
