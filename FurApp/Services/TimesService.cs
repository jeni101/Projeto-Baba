using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq; // Importar para usar LINQ (Where, ToList)
using Models.TimesApp;
using Models.ContaApp.Usuario.Tecnico;
using Models.ContaApp.Usuario.Jogador; 
using Repository.PersistenciaApp.Times;
using Repository.PersistenciaApp.Jogador; 

namespace Services.Times
{
    public class TimesServices
    {
        private readonly RepositoryTimes _repoTimes;
        private readonly RepositoryJogador _repoJogador;

        public TimesServices(RepositoryTimes repoTimes, RepositoryJogador repoJogador)
        {
            _repoTimes = repoTimes ?? throw new ArgumentNullException(nameof(repoTimes));
            _repoJogador = repoJogador ?? throw new ArgumentNullException(nameof(repoJogador));
        }

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

            var timeExistentePorAbreviacao = await _repoTimes.GetByAbreviacaoAsync(abreviacaoTime);
            if (timeExistentePorAbreviacao != null)
            {
                Console.WriteLine($"Erro: Já existe um time com a abreviação '{abreviacaoTime}'.");
                return null;
            }

            var novoTime = new Time(
                nomeTime,
                abreviacaoTime,
                tecnicoCriador.Id
            );

            bool sucesso = await _repoTimes.SalvarAsync(novoTime);

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

        public async Task<List<Time>> GetTimesByTecnico(Guid tecnicoId)
        {
            var todosOsTimes = await _repoTimes.GetAll();
            return todosOsTimes.Where(t => t.TecnicoId == tecnicoId).ToList();
        }

        public async Task<bool> AdicionarJogadorAoTime(Guid timeId, Guid jogadorId)
        {
            var time = await _repoTimes.GetByIdAsync(timeId);
            var jogador = await _repoJogador.GetByIdAsync(jogadorId);

            if (time == null || jogador == null)
            {
                Console.WriteLine("Time ou jogador não encontrado.");
                return false;
            }

            if (time.JogadoresId.Contains(jogadorId))
            {
                Console.WriteLine("Jogador já está no time.");
                return false;
            }

            time.JogadoresId.Add(jogadorId);
            bool sucesso = await _repoTimes.AtualizarAsync(time);

            if (sucesso)
            {
                Console.WriteLine($"Jogador '{jogador.Nome}' adicionado ao time '{time.Nome}'.");
            }
            else
            {
                Console.WriteLine($"Falha ao adicionar jogador '{jogador.Nome}' ao time '{time.Nome}'.");
            }
            return sucesso;
        }

        public async Task<bool> RemoverJogadorDoTime(Guid timeId, Guid jogadorId)
        {
            var time = await _repoTimes.GetByIdAsync(timeId);
            var jogador = await _repoJogador.GetByIdAsync(jogadorId);

            if (time == null || jogador == null)
            {
                Console.WriteLine("Time ou jogador não encontrado.");
                return false;
            }

            if (!time.JogadoresId.Contains(jogadorId))
            {
                Console.WriteLine("Jogador não está no time.");
                return false;
            }

            time.JogadoresId.Remove(jogadorId);
            bool sucesso = await _repoTimes.AtualizarAsync(time);

            if (sucesso)
            {
                Console.WriteLine($"Jogador '{jogador.Nome}' removido do time '{time.Nome}'.");
            }
            else
            {
                Console.WriteLine($"Falha ao remover jogador '{jogador.Nome}' do time '{time.Nome}'.");
            }
            return sucesso;
        }

        public async Task ExibirTodosTimes()
        {
            Console.WriteLine("\n--- Times Registrados ---");
            var times = await _repoTimes.GetAll();

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
                

                Console.WriteLine($"Jogadores (IDs): {(time.JogadoresId != null ? string.Join(", ", time.JogadoresId) : "Nenhum")}");

                Console.WriteLine("-----------------------------");
            }
        }
    }
}