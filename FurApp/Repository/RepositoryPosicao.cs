using Interfaces.IRepository;
using Models.PosicaoApp;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Posicoes
{
    public class RepositoryPosicao : ARepository<Posicao>
    {
        public RepositoryPosicao(JsonServices jsonServices)
            : base(jsonServices, "posicoes.json")
        { 
            
        }
    }
}