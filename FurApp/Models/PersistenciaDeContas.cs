using System.Text.Json;

namespace ContaUsuarioApp
{
    public static class Persistencia_De_Contas
    {
        private const string caminhoArquivo = "../Database/contas_usuarios.json";
        private static bool modoDebug = true;
        
        public static List<Conta_Usuario> Carregar_Contas()
        {
            if (!File.Exists(caminhoArquivo))
            {
                return new List<Conta_Usuario>();
            }
            
            try
            {
                string json = File.ReadAllText(caminhoArquivo);
                return JsonSerializer.Deserialize<List<Conta_Usuario>>(json) ?? new List<Conta_Usuario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Conta_Usuario>();
            }
        }

        public static void Salvar_Contas(List<Conta_Usuario> contas)
        {
            try
            {
                string diretorio = Path.GetDirectoryName(caminhoArquivo) ?? "0";
                if (!Directory.Exists(diretorio))
                {
                    Directory.CreateDirectory(diretorio);
                }

                string json = JsonSerializer.Serialize(contas, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(caminhoArquivo, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
