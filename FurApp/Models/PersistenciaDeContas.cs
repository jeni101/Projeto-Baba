using ContaApp;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.IO;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;


//Isso vai salvar contas de usuario, depois dividiremos mais corretamente
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

            string json = File.ReadAllText(caminhoArquivo);
            return JsonSerializer.Deserialize<List<ContaUsuario>>(json) ?? new List<ContaUsuario>();
        }

        public static void SalvarContas(List<ContaUsuario> contas)
        {
            string json = JsonSerializer.Serialize(contas, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(caminhoArquivo, json);
        }

    }
}
