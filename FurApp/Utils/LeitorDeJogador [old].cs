/*
using System;
using MySqlConnector;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.TimesApp;
using Repository.PersistenciaApp.Times;

namespace Utils.Pelase.Leitor.Jogador
{
    public class LeitorDeJogador
    {
        private readonly RepositoryTimes _timesRepository;

        public LeitorDeJogador(RepositoryTimes timesRepository)
        {
            _timesRepository = timesRepository;
        }
        public async Task<Conta_Jogador> LerJogador(MySqlDataReader reader)
        {
            Guid id = Guid.Parse(reader.GetString("Id"));
            string nome = reader.GetString("Nome");
            string senhaHash = reader.GetString("SenhaHash");
            int idade = reader.GetInt32("Idade");

            List<string> interesses = reader.IsDBNull(reader.GetOrdinal("Interesses"))
                                        ? new List<string>()
                                        : reader.GetString("Interesses")
                                                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(s => s.Trim())
                                                .ToList();

            string posicao = reader.GetString("Posicao");
            Time? jogadorTime = null;

            if (!reader.IsDBNull(reader.GetOrdinal("TimeId")))
            {
                string timeIdString = reader.GetString("TimeId");
                if (Guid.TryParse(timeIdString, out Guid timeId))
                {
                    jogadorTime = await _timesRepository.GetById(timeId);

                    if (jogadorTime == null)
                    {
                        Console.WriteLine($"Aviso: Time com ID {timeId} não encontrado para o jogador {nome}.");
                    }
                }
                else
                {
                    Console.WriteLine($"Aviso: Coluna 'TimeId' para o jogador {nome} contém um GUID inválido: '{timeIdString}'.");
                }
            }

            List<string> partidas = reader.IsDBNull(reader.GetOrdinal("Partidas"))
                                        ? new List<string>()
                                        : reader.GetString("Partidas")
                                                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                                                .Select(s => s.Trim())
                                                .ToList();

            bool tornouSeJogador = reader.GetBoolean("TornouSeJogador");
            bool tornouSeTecnico = reader.GetBoolean("TornouSeTecnico");
            DateTime dataCriacao = reader.GetDateTime("DataCriacao");
            bool deletado = reader.GetBoolean("Deletado");

            DateTime? dataDelecao = reader.IsDBNull(reader.GetOrdinal("DataDelecao"))
                                            ? (DateTime?)null
                                            : reader.GetDateTime("DataDelecao");

            string? quemDeletou = reader.IsDBNull(reader.GetOrdinal("QuemDeletou"))
                                            ? null
                                            : reader.GetString("QuemDeletou");

            return new Conta_Jogador(
                id, nome, senhaHash, idade, posicao, jogadorTime,
                interesses, partidas, tornouSeJogador, tornouSeTecnico, dataCriacao,
                deletado, dataDelecao, quemDeletou
            );
        }
    }
}
*/