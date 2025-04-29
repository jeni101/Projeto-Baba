using ContaApp;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;


namespace ContaUsuarioApp
{
    public static class PersistenciaDeContas
    {
        private const string caminhoArquivo = "../Database/contas_usuarios.json";
        private static bool modoDebug = true;
        
        public static List<ContaUsuario> CarregarContas()
        {
            if (!File.Exists(caminhoArquivo))
            {
                return new List<ContaUsuario>();
            }
            
            try
            {
                string json = File.ReadAllText(caminhoArquivo);
                return JsonSerializer.Deserialize<List<ContaUsuario>>(json) ?? new List<ContaUsuario>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ContaUsuario>();
            }
        }

        public static void SalvarContas(List<ContaUsuario> contas)
        {
            try
            {
                string diretorio = Path.GetDirectoryName(caminhoArquivo);
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
