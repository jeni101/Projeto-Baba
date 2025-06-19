using System;
using System.IO;
using System.Threading.Tasks;
using Models.ContaApp.ADM;
using Repository.PersistenciaApp.ADM;
using Services.Json;
using Utils.Pelase.CensuradorDeSenha;

namespace Repository.Database.Initializer.ADM
{
    public class InitializerAdministrador
    {
        private readonly RepositoryADM _repoADM;
        private readonly JsonServices _jsonService;

        public InitializerAdministrador(RepositoryADM repoADM, JsonServices jsonService)
        {
            _repoADM = repoADM ?? throw new ArgumentNullException(nameof(repoADM));
            _jsonService = jsonService ?? throw new ArgumentNullException(nameof(jsonService));
        }

        public async Task InitializeAsync()
        {
            string filePath = Path.Combine("FurApp", "Database", "adm.json");

            if (_jsonService.FileExists(filePath) && (await _jsonService.ReadFileAsync(filePath))?.Length > 2)
            {
                Console.WriteLine("Administradores já inicializados no JSON. Pulando a inicialização.");
                return;
            }

            Console.WriteLine("Inicializando Administrador no JSON...");

            var admin = new Conta_Administrador("admin", "admin", 21);
            

            if (await _repoADM.SalvarAsync(admin))
            {
                Console.WriteLine($"Administrador '{admin.Nome}' inicializado com sucesso. ID: {admin.Id}");
            }
            else
            {
                Console.WriteLine($"Erro ao inicializar Administrador '{admin.Nome}'.");
            }

            Console.WriteLine("Inicialização de Administrador concluída.");
        }
    }
}