using Interfaces.IRepository;
using Models.TimesApp;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Times
{
    public class RepositoryTimes : ARepository<Time>
    {
        public RepositoryTimes(JsonServices jsonServices)
            : base(jsonServices, "times.json")
        {

        }
        
        public async Task<Time?> GetByNameAsync(string nome)
        {
            var todosOsTimes = await GetAll();
            return todosOsTimes.FirstOrDefault(t => t.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
        public async Task<Time?> GetByAbreviacaoAsync(string abreviacao)
        {
            var todosOsTimes = await GetAll();
            return todosOsTimes.FirstOrDefault(t => t.Abreviacao.Equals(abreviacao, StringComparison.OrdinalIgnoreCase));
        }
    }
}