using Interfaces.IRepository;
using Models.ContaApp.ADM;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.ADM
{
    public class RepositoryADM : ARepository<Conta_Administrador>
    {
        public RepositoryADM(JsonServices jsonServices)
            : base(jsonServices, "adm.json")
        {

        }
        
        public async Task<Conta_Administrador?> GetByNomeAsync(string nome)
        {
            var jogadores = await GetAll();
            return jogadores.FirstOrDefault(j => j.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}