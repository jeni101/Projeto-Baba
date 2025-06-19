using Interfaces.IRepository;
using Models.JogosApp;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Jogos
{
    public class RepositoryJogos : ARepository<Jogo>
    {
        public RepositoryJogos(JsonServices jsonServices)
            : base(jsonServices, "jogos.json")
        {

        }
        
        public async Task<List<Jogo>> GetJogosByDataHoraAsync(DateOnly dataAlvo, TimeOnly horaAlvo)
        {
            var todosOsJogos = await GetAll();

            return todosOsJogos
                .Where(j => j.Data == dataAlvo && j.Hora == horaAlvo)
                .ToList();
        }

        public async Task<List<Jogo>> GetJogosByNomeAsync(string nomeJogo)
        {
            var todosOsJogos = await GetAll();
            return todosOsJogos.Where(j => j.Nome.Contains(nomeJogo, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}