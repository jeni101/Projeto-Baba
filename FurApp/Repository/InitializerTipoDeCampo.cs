using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp.Campos;
using Repository.PersistenciaApp.Campos.Tipo;
using Services.Json;

namespace Repository.Database.Initializer.Campos.Tipo
{
    public class InitializerTipoCampos
    {
        private readonly RepositoryCamposTipo _tiposCampoRepository;
        private readonly JsonServices _jsonServices;

        public InitializerTipoCampos(RepositoryCamposTipo tipoCampoRepository, JsonServices jsonServices)
        {
            _jsonServices = jsonServices;
            _tiposCampoRepository = tipoCampoRepository;
        }

        public async Task InitializeAsync()
        {
            string filePath = Path.Combine("FurApp", "Database", "tiposDeCampo.json");

            if (_jsonServices.FileExists(filePath) && (await _jsonServices.ReadFileAsync(filePath))?.Length > 2)
            {
                Console.WriteLine("Tipos de Campo já inicializados no JSON. Pulando a inicialização.");
                return;
            }
            Console.WriteLine("Inicializando Tipos de Campo no JSON...");

            var tiposDeCampo = new List<TipoDeCampo>
            {
                new TipoDeCampo("Clássico", 22),
                new TipoDeCampo("Society", 14),
                new TipoDeCampo("Quadra", 10) ,
                new TipoDeCampo("Areia", 10)
            };

            foreach (var tipo in tiposDeCampo)
            {
                if (await _tiposCampoRepository.SalvarAsync(tipo))
                {
                    Console.WriteLine($"Tipo de Campo '{tipo.Tipo}' inicializado com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Erro ao inicializar Tipo de Campo '{tipo.Tipo}'.");
                }
            }

            Console.WriteLine("Inicialização de Tipos de Campo concluída.");
        }
    }
}