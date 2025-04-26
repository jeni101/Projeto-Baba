using ContaApp;
using Newtonsoft.Json;

namespace PersistenciaApp
{
    public static class PersistenciaDeContas
    {
         
        private static string caminhoArquivo = "../Database/dados.json";

        public static void SalvarContas(List<Conta> contas)
        {
            var json = JsonConvert.SerializeObject(contas, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            File.WriteAllText(caminhoArquivo, json);
        }

        public static List<Conta> CarregarContas()
        {
            if (!File.Exists(caminhoArquivo))
                return new List<Conta>();

            var json = File.ReadAllText(caminhoArquivo);

            return JsonConvert.DeserializeObject<List<Conta>>(json, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            }) ?? new List<Conta>();
        }
    }
}
