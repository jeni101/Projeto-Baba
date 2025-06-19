using Interfaces.IRepository;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp;
using Repository.PersistenciaApp.Campos.Tipo;
using Services.Json;

namespace Repository.PersistenciaApp.Campos
{
    public class RepositoryCampos : ARepository<Campo>
    {
        private readonly RepositoryCamposTipo _repoCamposTipo;
        public RepositoryCampos(JsonServices jsonServices, RepositoryCamposTipo repoCamposTipo)
            : base(jsonServices, "campos.json")
        {
            _repoCamposTipo = repoCamposTipo;
        }

        public async Task<List<Campo>> GetCamposFiltradosAsync(string? nomeCampo = null, string? tipoDeCampoNome = null, string? localizacao = null)
        {
            var todosOsCampos = await GetAll();
            var camposFiltrados = todosOsCampos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nomeCampo))
            {
                camposFiltrados = camposFiltrados.Where(c => c.Nome.Contains(nomeCampo, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.IsNullOrWhiteSpace(tipoDeCampoNome))
            {
                var todosOsTiposDeCampo = await _repoCamposTipo.GetAll();
                var tipoDeCampoId = todosOsTiposDeCampo.FirstOrDefault(t => t.Tipo.Equals(tipoDeCampoNome, StringComparison.OrdinalIgnoreCase))?.Id;

                if (tipoDeCampoId.HasValue)
                {
                    camposFiltrados = camposFiltrados.Where(c => c.TipoDeCampo.Id == tipoDeCampoId.Value);
                }
                else
                {
                    return new List<Campo>();
                }
            }

            if (!string.IsNullOrWhiteSpace(localizacao))
            {
                camposFiltrados = camposFiltrados.Where(c => c.Local.Contains(localizacao, StringComparison.OrdinalIgnoreCase));
            }

            return camposFiltrados.ToList();
        }
    }
}