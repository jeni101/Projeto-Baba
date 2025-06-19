using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp.Campos;
using Repository.PersistenciaApp.Campos.Tipo;
using Services.Json;

namespace Repository.Database.Initializer.Campos
{
    public class InitializerCampos
    {
        private readonly RepositoryCampos _repoCampos;
        private readonly RepositoryCamposTipo _repoCamposTipo;
        private readonly JsonServices _jsonServices;

        public InitializerCampos(RepositoryCampos repoCampos, RepositoryCamposTipo repoCamposTipo, JsonServices jsonServices)
        {
            _repoCampos = repoCampos;
            _repoCamposTipo = repoCamposTipo;
            _jsonServices = jsonServices;
        }

        public async Task InitializeAsync()
        {
            string filePath = Path.Combine("FurApp", "Database", "campos.json");

            // Verifica se o arquivo já existe e tem conteúdo.
            if (_jsonServices.FileExists(filePath) && (await _jsonServices.ReadFileAsync(filePath))?.Length > 2)
            {
                Console.WriteLine("Campos já inicializados no JSON. Pulando a inicialização.");
                return;
            }

            Console.WriteLine("Inicializando Campos no JSON...");

            var tiposDeCampo = await _repoCamposTipo.GetAll();
            if (!tiposDeCampo.Any())
            {
                Console.WriteLine("Aviso: Nenhum Tipo de Campo encontrado. Inicialize os tipos de campo primeiro.");
                return;
            }

            var classico = tiposDeCampo.FirstOrDefault(t => t.Tipo.Equals("Clássico", StringComparison.OrdinalIgnoreCase));
            var areia = tiposDeCampo.FirstOrDefault(t => t.Tipo.Equals("Areia", StringComparison.OrdinalIgnoreCase));
            var quadra = tiposDeCampo.FirstOrDefault(t => t.Tipo.Equals("Quadra", StringComparison.OrdinalIgnoreCase));


            var campos = new List<Campo>();

            if (classico != null)
            {
                campos.Add(new Campo("Campão", "Ao lado do complexo esportivo", 22, classico));
                campos.Add(new Campo("Pista de Atletismo", "No meio da pista de atletismo", 22, classico));
            }
            if (areia != null)
            {
                campos.Add(new Campo("Quadra de Areia 1", "Campo de areia próximo ao complexo esportivo", 10, areia));
            }
            if (quadra != null)
            {
                campos.Add(new Campo("Quadra A", "Quadra interna, à esquerda, complexo esportivo", 10, quadra));
                campos.Add(new Campo("Quadra B", "Quadra interna, à direita, complexo esportivo", 10, quadra));
                campos.Add(new Campo("Quadra C", "Quadra externa, à esquerda, complexo esportivo", 10, quadra));
                campos.Add(new Campo("Quadra D", "Quadra externa, à direita, complexo esportivo", 10, quadra));
                campos.Add(new Campo("Quadra Portaria", "Quadra perto da portaria", 10, quadra));
            }

            foreach (var campo in campos)
            {
                if (await _repoCampos.SalvarAsync(campo))
                {
                    Console.WriteLine($"Campo '{campo.Nome}' inicializado com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Erro ao inicializar Campo '{campo.Nome}'.");
                }
            }

            Console.WriteLine("Inicialização de Campos concluída.");
        }
    }
}