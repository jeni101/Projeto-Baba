using Interfaces.IRepository;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp;
using Services.Json;

namespace Repository.PersistenciaApp.Campos.Tipo
{
    public class RepositoryCamposTipo : ARepository<TipoDeCampo>
    {
        public RepositoryCamposTipo(JsonServices jsonServices)
            : base(jsonServices, "camposTipo.json")
        { 
            
        }
    }
}