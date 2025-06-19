using Interfaces.IRepository;
using Models.ContaApp.Usuario.Tecnico;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Tecnico
{
    public class RepositoryTecnico : ARepository<Conta_Tecnico>
    {
        public RepositoryTecnico(JsonServices jsonServices)
            : base(jsonServices, "tecnicos.json")
        {
        }
            public async Task<Conta_Tecnico?> GetByNomeAsync(string nome)
        {
            var jogadores = await GetAll();
            return jogadores.FirstOrDefault(j => j.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}