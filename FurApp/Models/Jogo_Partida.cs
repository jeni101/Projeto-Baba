using System;
using System.Collections.Generic;
using Models.JogosApp;
using Models.JogosApp.PlacarJogo;

namespace Models.JogosApp.Partidas
{

    public class Partida : AModel
    {
        public string Nome { get; private set; }
        public Guid JogoId { get; private set; }
        public string TimeA { get; private set; }
        public string TimeB { get; private set; }
        public Placar Placar { get; private set; }
        public DateOnly Data { get; private set; }
        public TimeOnly Hora { get; private set; }
        public string Local { get; private set; }
        public PartidaStatus Status { get; private set; }

        //Construtor padrão
        public Partida(Guid jogoId, string timeA, string timeB, DateOnly data, TimeOnly hora, string local)
        {
            Id = Guid.NewGuid();
            JogoId = jogoId;
            TimeA = timeA ?? throw new ArgumentNullException(nameof(timeA));
            TimeB = timeB ?? throw new ArgumentNullException(nameof(timeB));
            Placar = new Placar();
            Data = data;
            Hora = hora;
            Local = local ?? throw new ArgumentNullException(nameof(local));
            Status = PartidaStatus.Agendada;
            Nome = GerarNomePartida();
        }

        //Banco
        public Partida(Guid id, Guid jogoId, string nome, string timeA, string timeB, int GolsA, int GolsB, DateOnly data, TimeOnly hora, string local, PartidaStatus status)
        {
            Id = id;
            JogoId = jogoId;
            Nome = nome;
            TimeA = timeA;
            TimeB = timeB;
            Placar = new Placar(GolsA, GolsB);
            Hora = hora;
            Local = local;
            Status = status;
        }
        private string GerarNomePartida()
        {
            return $"Partida: {TimeA} vs {TimeB} em {Data:dd/MM/yyyy} às {Hora:HH:mm}";
        }

        public void AtualizarNomePartida()
        {
            Nome = $"Partida: {TimeA} vs {TimeB} em {Data:dd/MM/yyyy} às {Hora:HH:mm}";
        }

        public void IniciarPartida()
        {
            if (Status == PartidaStatus.Agendada)
            {
                Status = PartidaStatus.EmAndamento;
                Console.WriteLine($"Partida {TimeA} vs {TimeB} iniciada!");
            }
            else
            {
                Console.WriteLine("Não é possível iniciar uma partida que não está Agendada.");
            }
        }

        public void ConcluirPartida()
        {
            if (Status == PartidaStatus.EmAndamento)
            {
                Status = PartidaStatus.Concluida;
                Console.WriteLine($"Partida {TimeA} vs {TimeB} concluída! Placar final: {Placar.GolsA} x {Placar.GolsB}");
            }
            else
            {
                Console.WriteLine("Não é possível concluir uma partida que não está Em Andamento.");
            }
        }

        public void CancelarPartida()
        {
            if (Status == PartidaStatus.Agendada || Status == PartidaStatus.EmAndamento)
            {
                Status = PartidaStatus.Cancelada;
                Console.WriteLine($"Partida {TimeA} vs {TimeB} cancelada.");
            }
            else
            {
                Console.WriteLine("Não é possível cancelar uma partida que já foi concluída ou já está cancelada.");
            }
        }

        public void AdicionarPontoTimeA()
        {
            if (Status == PartidaStatus.EmAndamento)
            {
                Placar.AdicionarGolsA();
                Console.WriteLine($"Ponto para {TimeA}! Placar atual: {Placar}");
            }
            else
            {
                Console.WriteLine("Não é possível adicionar pontos a uma partida que não está Em Andamento.");
            }
        }

        public void AdicionarPontoTimeB()
        {
            if (Status == PartidaStatus.EmAndamento)
            {
                Placar.AdicionarGolsB();
                Console.WriteLine($"Ponto para {TimeB}! Placar atual: {Placar}");
            }
            else
            {
                Console.WriteLine("Não é possível adicionar pontos a uma partida que não está Em Andamento.");
            }
        }

        public override string ToString()
        {
            return $"{Nome} - Status: {Status} - Placar: {Placar}";            Placar = new Placar(timeA: "Time A", golsA: 0, timeB: "Time B", golsB: 0);
            Times = new List<Time>();
        }

        public void Entrar_jogo_com_possicao()
        {
            while (true)
            {

                List<string> Posicao = new List<string>()
                {
                    "goleiro",
                    "zagueiro",
                    "lateral direito",
                    "lateral esquerdo ",
                    "volante",
                    "meia",
                    "atacante"

                };
                Console.WriteLine("digite a possicao q deseja jogar: ");
                Console.WriteLine("goleiro, zagueiro, lateral direito, lateral esquerdo, volante, meia, atacante");
                string? posicaoEscolhida = Console.ReadLine();
                if (posicaoEscolhida != null)
                {
                    posicaoEscolhida = posicaoEscolhida.ToLower();
                }
                if (posicaoEscolhida != null && Posicao.Contains(posicaoEscolhida))
                {
                    Console.WriteLine($"Você escolheu jogar como {posicaoEscolhida}.");
                    Console.WriteLine("entando na partida... ");
                    var jogador = new Conta_Jogador(nome: "Jogador1", senha: "123", idade: 25, posicao: posicaoEscolhida);
                    var jogo = new Jogo(data: DateOnly.FromDateTime(DateTime.Now),
                                        hora: TimeOnly.FromDateTime(DateTime.Now),
                                        local: "Estádio Central",
                                        tipoDeCampo: "Grama",
                                        quantidadeDeJogadores: 11)

                                        ;
                    var AdicionarInteressado = jogo.AdicionarInteressado(jogador, ref posicaoEscolhida);

                }
                else
                {
                    Console.WriteLine("Posição inválida. Por favor, escolha uma posição válida.");
                }
            }
        }

        public void Entrar_jogo_sem_posicao()
        {
            List<string> PosicaoGenerica = new List<string>()
            {
                "goleiro",
                "defesa",
                "atacante"
            };
            Random rnd = new Random();
            string PosicaoSorteada = PosicaoGenerica[rnd.Next(PosicaoGenerica.Count)];
            var jogador = new Conta_Jogador(nome: "Jogador2", senha: "456", idade: 22, posicao: "genérica");
            var jogo = new Jogo(data: DateOnly.FromDateTime(DateTime.Now),
                                hora: TimeOnly.FromDateTime(DateTime.Now),
                                local: "Estádio Central",
                                tipoDeCampo: "Grama",
                                quantidadeDeJogadores: 11); // teste deve ser tirado dps
            var AdicionarInteressado = jogo.AdicionarInteressado(jogador, ref PosicaoSorteada);
        }


        public void SepararTimes(Jogo jogo, List<Conta_Jogador> todosJogadoresCadastrados)
        {
            if (jogo.Interessados.Count < jogo.QuantidadeDeJogadores)
            {
                Console.WriteLine("Jogadores insuficientes para formar times.");
                return;
            }

            // Pega os objetos Jogador a partir dos nomes em jogo.Interessados
            var jogadoresCompletos = todosJogadoresCadastrados
                .Where(j => jogo.Interessados.Contains(j.Nome))
                .ToList();

            var goleiros = jogadoresCompletos
                .Where(j => j.Posicao.ToLower() == "goleiro")
                .ToList();

            var outros = jogadoresCompletos
                .Where(j => j.Posicao.ToLower() != "goleiro")
                .ToList();

            if (goleiros.Count < 2)
            {
                Console.WriteLine("Não há goleiros suficientes (mínimo 2) para formar os times.");
                return;
            }

            // Monta os times
            var timeA = new List<Conta_Jogador> { goleiros[0] };
            var timeB = new List<Conta_Jogador> { goleiros[1] };

            var restantes = outros.Take(jogo.QuantidadeDeJogadores - 2).ToList();
            int metade = restantes.Count / 2;

            timeA.AddRange(restantes.Take(metade));
            timeB.AddRange(restantes.Skip(metade));

            Console.WriteLine("\n--- TIME A ---");
            foreach (var jogador in timeA)
                Console.WriteLine($"{jogador.Nome} ({jogador.Posicao})");

            Console.WriteLine("\n--- TIME B ---");
            foreach (var jogador in timeB)
                Console.WriteLine($"{jogador.Nome} ({jogador.Posicao})");
        }

                        
     }
}
