using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Models.TimesApp;
using Models.ContaApp.Usuario.Tecnico;
using Repository.PersistenciaApp.Times;

namespace Services.Times
{
    public class TimesServices
    {
        private readonly RepositoryTimes _repoTimes = new RepositoryTimes();

        public async Task<Time?> CriarTime(string nomeTime, string abreviacaoTime, Conta_Tecnico tecnicoCriador)
        {
            if (tecnicoCriador == null)
            {
                Console.WriteLine("Erro: Técnico não pode ser nulo");
                return null;
            }

            if (string.IsNullOrWhiteSpace(nomeTime) || string.IsNullOrWhiteSpace(abreviacaoTime))
            {
                Console.WriteLine("Erro: Nome e abreviação do time não podem ser vazios.");
                return null;
            }

            var timeExistentePorNome = await _repoTimes.GetByNameAsync(nomeTime);
            if (timeExistentePorNome != null)
            {
                Console.WriteLine($"Erro: Já existe um time com o nome '{nomeTime}'.");
                return null;
            }

            var timeExistentePorAbreviacao = await _repoTimes.GetByAbreviacoes(abreviacaoTime);
            if (timeExistentePorAbreviacao != null)
            {
                Console.WriteLine($"Erro: Já existe um time com a abreviação '{abreviacaoTime}'.");
                return null;
            }

            var novoTime = new Time(
                nomeTime,
                abreviacaoTime,
                tecnicoCriador.Nome
            );

            bool sucesso = await _repoTimes.SalvarTime(novoTime);

            if (sucesso)
            {
                Console.WriteLine($"Time '{nomeTime}' criado com sucesso pelo técnico '{tecnicoCriador.Nome}'.");
                return novoTime;
            }
            else
            {
                Console.WriteLine($"Falha ao criar o time '{nomeTime}'.");
                return null;
            }
        }
        
        public async Task ExibirTodosTimes()
        {
            Console.WriteLine("\n--- Times Registrados ---");
            var times = await _repoTimes.CarregarTodos();

            if (times.Count == 0)
            {
                Console.WriteLine("Nenhum time registrado.");
                return;
            }

            foreach (var time in times)
            {
                Console.WriteLine($"ID: {time.Id}");
                Console.WriteLine($"Nome: {time.Nome}");
                Console.WriteLine($"Abreviação: {time.Abreviacao}");
                Console.WriteLine($"Técnico: {time.Tecnico}");
                Console.WriteLine($"Jogadores: {(time.Jogadores != null ? string.Join(", ", time.Jogadores) : "Nenhum")}");
                Console.WriteLine($"Jogos: {(time.Jogos != null ? string.Join(", ", time.Jogos) : "Nenhum")}");
                Console.WriteLine($"Partidas: {(time.Partidas != null ? string.Join(", ", time.Partidas) : "Nenhum")}");
            }
        }
    }
}