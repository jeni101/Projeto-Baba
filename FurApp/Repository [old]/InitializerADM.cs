/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.ADM;
using Repository.PersistenciaApp.ADM;

namespace Repository.Database.Initializer.ADM
{
    public class InitializerADM
    {
        public static async Task Inicializar(RepositoryADM repoADM)
        {
            var admPadrao = await repoADM.CarregarTodos();
            if (admPadrao.Count > 0) return;

            var administador = new List<Conta_Administrador>
            {
                new Conta_Administrador("adm", "adm", 18)
            };

            foreach (var adm in administador)
            {
                await repoADM.SalvarADM(adm);
            }
        }
    }
}
*/