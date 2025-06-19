/*
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySqlConnector;
using Models.PosicaoApp;
using Repository.PersistenciaApp.Posicoes;

namespace Repository.Database.Initializer.Posicoes
{
    public static class InitializerPosicoes
    {
        private static readonly List<Posicao> PosicoesPadrao = new List<Posicao>
        {
            new Posicao("Goleiro", "Defesa", "GOL"),
            new Posicao("Zagueiro", "Defesa", "ZAG"),
            new Posicao("Lateral", "Defesa", "LAT"),
            new Posicao("Volante", "Meio-Campo", "VOL"),
            new Posicao("Meia Central", "Meio-Campo", "MCC"),
            new Posicao("Meia Atacante", "Meio-Campo", "MCA"),
            new Posicao("Ponta", "Ataque", "PON"),
            new Posicao("Centroavante", "Ataque", "CAT"),
            new Posicao("Segundo Atacante", "Ataque", "SA")
        };

        public static async Task Inicializar(RepositoryPosicao repoPosi)
        {
            var posicoesExistentes = await repoPosi.CarregarTodas();
            if (posicoesExistentes.Count == 0)
            {
                foreach (var posicao in PosicoesPadrao)
                {
                    posicao.Id = Guid.NewGuid();
                    await repoPosi.SalvarPosicao(posicao);
                }
            }
        }
    }
}
*/