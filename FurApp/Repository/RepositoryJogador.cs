using Interfaces.IRepository;
using Models.ContaApp.Usuario.Jogador;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Jogador
{
    public class RepositoryJogador : ARepository<Conta_Jogador>
    {
        public RepositoryJogador(JsonServices jsonServices)
            : base(jsonServices, "jogadores.json")
        {

        }
        
        public async Task<Conta_Jogador?> GetByNomeAsync(string nome)
        {
            var jogadores = await GetAll();
            return jogadores.FirstOrDefault(j => j.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase));
        }
    }
}