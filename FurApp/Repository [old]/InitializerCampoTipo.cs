using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp.CamposTipo;

namespace Repository.Database.Initializer.Campos.Tipo
{
    public static class InitializerTipoCampos
    {
        private static readonly List<TipoDeCampo> TiposPadrao = new List<TipoDeCampo>
        {
            new TipoDeCampo("Clássico", 22),
            new TipoDeCampo("Society", 14),
            new TipoDeCampo("Quadra", 10),
            new TipoDeCampo("Areia", 10)
        };

        public static async Task Inicializar(RepositoryCamposTipos repoTipoCampo)
        {
            var tiposExistentes = await repoTipoCampo.CarregarTodos();
            if (tiposExistentes.Count == 0)
            {
                foreach (var tipo in TiposPadrao)
                {
                    tipo.Id = Guid.NewGuid();
                    await repoTipoCampo.SalvarTipo(tipo);
                } 
            }
        }
    }
}