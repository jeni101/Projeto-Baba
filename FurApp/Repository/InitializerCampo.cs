using System;
using System.Collections.Generic;
using System.Linq;
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

            var tipoClassico = tiposDeCampo.FirstOrDefault(t => t.Tipo == "Clássico");
            var tipoSociety = tiposDeCampo.FirstOrDefault(t => t.Tipo == "Society");
            var tipoQuadra = tiposDeCampo.FirstOrDefault(t => t.Tipo == "Quadra");
            var tipoAreia = tiposDeCampo.FirstOrDefault(t => t.Tipo == "Areia");

            if (tipoClassico == null || tipoSociety == null || tipoQuadra == null || tipoAreia == null)
            {
                throw new Exception(" !  Erro: Nem todos os campos padrão foram encontrados ! ");
            }

            var camposUnasp = new List<Campo>
            {
                new Campo("Campão", "Ao lado do complexo esportivo", 22, tipoClassico),
                new Campo("Quadra A", "Quadra interna, à esquerda, complexo esportivo", 10, tipoQuadra),
                new Campo("Quadra B", "Quadra interna, à direita, complexo esportivo", 10, tipoQuadra),
                new Campo("Quadra C", "Quadra externa, à esquerda, complexo esportivo", 10, tipoQuadra),
                new Campo("Quadra D", "Quadra externa, à esquerda, complexo esportivo", 10, tipoQuadra),
                new Campo("Quadra da Portaria", "Quadra próxima a portaria", 10, tipoQuadra),
                new Campo("Quadra de Areia", "Campo de areia próximo ao complexo esportivo", 10, tipoAreia),
                new Campo("Pista de Atletismo", "Campinho no meio da pista de atletismo", 22, tipoClassico),
            };

            foreach (var campo in camposUnasp)
            {
                await repoCampo.SalvarCampo(campo);
            }
        }
    }
}