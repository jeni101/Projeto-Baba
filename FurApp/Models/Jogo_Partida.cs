using System;
using System.Collections.Generic;
using Models.JogosApp;
using Models.JogosApp.PlacarJogo;

namespace Models.JogosApp.Partidas
{

    public class Partida
    {
        public Guid Id { get; protected set; }
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
            return $"{Nome} - Status: {Status} - Placar: {Placar}";
        }
    }
}
