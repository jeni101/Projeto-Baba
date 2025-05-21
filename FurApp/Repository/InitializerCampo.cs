using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.CamposApp;
using Repository.PersistenciaApp.Campos;
using Repository.PersistenciaApp.CamposTipo;
using Repository.Database.Initializer.Campos.Tipo;

namespace Repository.Database.Initializer.Campos
{
    public static class InitializerCampos
    {
        public static async Task Inicializar(RepositoryCampos repoCampo, RepositoryCamposTipos repoTipoCampo)
        {
            var camposExistentes = await repoCampo.CarregarTodos();
            if (camposExistentes.Count > 0) return;

            var tiposDeCampo = await repoTipoCampo.CarregarTodos();
            if (tiposDeCampo.Count == 0)
                throw new Exception("Não inicializado");

            var camposUnasp = new List<Campo>
            {
                new Campo("Campão", "Ao lado do complexo esportivo", 22, tiposDeCampo[0].Id.ToString()),
                new Campo("Quadra A", "Quadra interna, à esquerda, complexo esportivo", 10, tiposDeCampo[2].Id.ToString()),
                new Campo("Quadra B", "Quadra interna, à direita, complexo esportivo", 10, tiposDeCampo[2].Id.ToString()),
                new Campo("Quadra C", "Quadra externa, à esquerda, complexo esportivo", 10, tiposDeCampo[2].Id.ToString()),
                new Campo("Quadra D", "Quadra externa, à esquerda, complexo esportivo", 10, tiposDeCampo[2].Id.ToString()),
                new Campo("Quadra da Portaria", "Quadra próxima a portaria", 10, tiposDeCampo[2].Id.ToString()),
                new Campo("Quadra de Areia", "Campo de areia próximo ao complexo esportivo", 10, tiposDeCampo[3].Id.ToString()),
            };

            foreach (var campo in camposUnasp)
            {
                campo.Id = Guid.NewGuid();
                await repoCampo.SalvarCampo(campo);
            }
        }
    }
}