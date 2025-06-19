using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Models.PosicaoApp;
using Repository.PersistenciaApp.Posicoes;
using Services.Json; 

namespace Repository.Database.Initializer.Posicoes
{
    public class InitializerPosicoes
    {
        private readonly RepositoryPosicao _repoPosicao;
        private readonly JsonServices _jsonService;

        public InitializerPosicoes(RepositoryPosicao posicaoRepository, JsonServices jsonServices)
        {
            _repoPosicao = posicaoRepository ?? throw new ArgumentNullException(nameof(posicaoRepository));
            _jsonService = jsonServices ?? throw new ArgumentNullException(nameof(jsonServices));
        }

        public async Task InitializeAsync()
        {
            string filePath = Path.Combine("FurApp", "Database", "posicoes.json");

            if (_jsonService.FileExists(filePath) && (await _jsonService.ReadFileAsync(filePath))?.Length > 2)
            {
                Console.WriteLine("Posições já inicializadas no JSON. Pulando a inicialização.");
                return;
            }

            Console.WriteLine("Inicializando Posições no JSON...");

            var posicoes = new List<Posicao>
            {
                new Posicao("Goleiro", "Goleiro", "GOL"),
                new Posicao("Zagueiro", "Defesa", "ZAG"),
                new Posicao("Lateral Direito", "Defesa", "LD"),
                new Posicao("Lateral Esquerdo", "Defesa", "LE"),
                new Posicao("Volante", "Defesa", "VOL"),
                new Posicao("Meia Central", "Defesa", "MC"),
                new Posicao("Meia Atacante", "Defesa", "MA"),
                new Posicao("Ponta Direita", "Defesa", "PD"),
                new Posicao("Ponta Esquerda", "Defesa", "PE"),
                new Posicao("Centroavante", "Defesa", "CA")
            };

            foreach (var posicao in posicoes)
            {
                if (await _repoPosicao.SalvarAsync(posicao))
                {
                    Console.WriteLine($"Posição '{posicao.Nome}' inicializada com sucesso.");
                }
                else
                {
                    Console.WriteLine($"Erro ao inicializar Posição '{posicao.Nome}'.");
                }
            }

            Console.WriteLine("Inicialização de Posições concluída.");
        }
    }
}