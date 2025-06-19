using Interfaces.IRepository;
using Models.JogosApp.Partidas;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Partidas
{
    public class RepositoryPartidas : ARepository<Partida>
    {
        public RepositoryPartidas(JsonServices jsonServices)
            : base(jsonServices, "partidas.json")
        { 
            
        }
    }
}