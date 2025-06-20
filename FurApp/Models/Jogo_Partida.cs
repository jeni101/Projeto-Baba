using System;
using System.Collections.Generic;
using Models.ContaApp.Usuario.Jogador;
using Models.TimesApp;
using Models.JogosApp;
using Models.JogosApp.PlacarJogo;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Repository.Database.Initializer.Posicoes;
using Repository.PersistenciaApp.Posicoes;
using Repository.PersistenciaApp.Jogos;
using Models.PosicaoApp;

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
        private readonly RepositoryPosicao _repoPosicao;
        private readonly RepositoryJogos _repoJogos;

        //Construtor padrão
        public Partida(Guid jogoId, string timeA, string timeB, DateOnly data, TimeOnly hora, string local, RepositoryPosicao repoPosicao, RepositoryJogos repoJogos)
        {
            Id = Guid.NewGuid();
            _repoPosicao = repoPosicao;
            _repoJogos = repoJogos;
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

        public async Task Entrar_jogo_com_possicao()
        {
            List<Jogo> jogosDisponiveis = await _repoJogos.GetAll();
            if (!jogosDisponiveis.Any())
            {
                Console.WriteLine("Nenhum jogo disponível para entrar. Crie um jogo primeiro.");
                return;
            }

            Jogo? jogoSelecionado = null;
            while (jogoSelecionado == null)
            {
                Console.WriteLine("\nEscolha um jogo para entrar digitando o número correspondente:");
                for (int i = 0; i < jogosDisponiveis.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {jogosDisponiveis[i].Nome} - Local: {jogosDisponiveis[i].LocalDisplay}");
                }
                Console.Write("Sua escolha de jogo: ");

                string? entradaJogo = Console.ReadLine();
                if (int.TryParse(entradaJogo, out int escolhaNumericaJogo))
                {
                    if (escolhaNumericaJogo > 0 && escolhaNumericaJogo <= jogosDisponiveis.Count)
                    {
                        jogoSelecionado = jogosDisponiveis[escolhaNumericaJogo - 1];
                        Console.WriteLine($"Você escolheu o jogo: {jogoSelecionado.Nome}");
                    }
                    else
                    {
                        Console.WriteLine("Número de jogo inválido. Por favor, digite um número da lista.");
                    }
                }
                else
                {
                    string entradaJogoFormatada = entradaJogo?.ToLower().Trim() ?? string.Empty;
                    jogoSelecionado = jogosDisponiveis.FirstOrDefault(j => j.Nome.ToLower().Contains(entradaJogoFormatada));
                    if (jogoSelecionado != null)
                    {
                         Console.WriteLine($"Você escolheu o jogo: {jogoSelecionado.Nome}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite o número do jogo ou parte do nome.");
                    }
                }
            }

            var jogoAtual = jogoSelecionado;

            List<Posicao> posicoesExistentes = await _repoPosicao.GetAll();

            if (!posicoesExistentes.Any())
            {
                Console.WriteLine("Nenhuma posição disponível para escolha. Verifique o repositório de posições.");
                return; 
            }

            Posicao? posicaoSelecionada = null;
            while (posicaoSelecionada == null)
            {
                Console.WriteLine("\nEscolha a posição desejada digitando o número correspondente:");
                for (int i = 0; i < posicoesExistentes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {posicoesExistentes[i].Nome}");
                }
                Console.Write("Sua escolha de posição: ");

                string? entradaPosicao = Console.ReadLine();
                if (int.TryParse(entradaPosicao, out int escolhaNumericaPosicao))
                {
                    if (escolhaNumericaPosicao > 0 && escolhaNumericaPosicao <= posicoesExistentes.Count)
                    {
                        posicaoSelecionada = posicoesExistentes[escolhaNumericaPosicao - 1];
                    }
                    else
                    {
                        Console.WriteLine("Número de posição inválido. Por favor, digite um número da lista.");
                    }
                }
                else
                {
                    string entradaTextoFormatada = entradaPosicao?.ToLower().Trim() ?? string.Empty;
                    posicaoSelecionada = posicoesExistentes.FirstOrDefault(p => p.Nome.ToLower() == entradaTextoFormatada);
                    if (posicaoSelecionada == null)
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite o número ou o nome exato da posição.");
                    }
                }
            }


            Console.WriteLine($"Você escolheu jogar como {posicaoSelecionada.Nome} no jogo {jogoAtual.Nome}.");
            Console.WriteLine("Entrando na partida... ");

            var jogador = new Conta_Jogador(nome: "Novo Jogador Teste", senha: "senhaSegura", idade: 27, posicao: posicaoSelecionada.Nome);

            if (jogoAtual.AdicionarInteressado(jogador))
            {
                Console.WriteLine("Jogador adicionado com sucesso ao jogo!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o jogador (talvez já esteja interessado ou o jogo esteja fechado).");
            }
        }

        public async Task Entrar_jogo_sem_posicao()
        {
           Console.WriteLine("\n--- Entrar em um Jogo sem Posição Definida (Escolha por Categoria) ---");

            List<Jogo> jogosDisponiveis = await _repoJogos.GetAll();

            if (!jogosDisponiveis.Any())
            {
                Console.WriteLine("Nenhum jogo disponível para entrar. Crie um jogo primeiro.");
                return;
            }

            Jogo? jogoSelecionado = null;
            while (jogoSelecionado == null)
            {
                Console.WriteLine("\nEscolha um jogo para entrar digitando o número correspondente:");
                for (int i = 0; i < jogosDisponiveis.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {jogosDisponiveis[i].Nome} - Local: {jogosDisponiveis[i].LocalDisplay}");
                }
                Console.Write("Sua escolha de jogo: ");

                string? entradaJogo = Console.ReadLine();
                if (int.TryParse(entradaJogo, out int escolhaNumericaJogo))
                {
                    if (escolhaNumericaJogo > 0 && escolhaNumericaJogo <= jogosDisponiveis.Count)
                    {
                        jogoSelecionado = jogosDisponiveis[escolhaNumericaJogo - 1];
                        Console.WriteLine($"Você escolheu o jogo: {jogoSelecionado.Nome}");
                    }
                    else
                    {
                        Console.WriteLine("Número de jogo inválido. Por favor, digite um número da lista.");
                    }
                }
                else
                {
                    string entradaJogoFormatada = entradaJogo?.ToLower().Trim() ?? string.Empty;
                    jogoSelecionado = jogosDisponiveis.FirstOrDefault(j => j.Nome.ToLower().Contains(entradaJogoFormatada));
                    if (jogoSelecionado != null)
                    {
                         Console.WriteLine($"Você escolheu o jogo: {jogoSelecionado.Nome}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite o número do jogo ou parte do nome.");
                    }
                }
            }

            var jogoAtual = jogoSelecionado;

            List<Posicao> todasAsPosicoes = await _repoPosicao.GetAll();

            List<string> categoriasExistentes = todasAsPosicoes
                .Select(p => p.Categoria)
                .Distinct() 
                .OrderBy(c => c)
                .ToList();

            if (!categoriasExistentes.Any())
            {
                Console.WriteLine("Nenhuma categoria de posição disponível. Verifique o repositório de posições e suas categorias.");
                return;
            }

            string? categoriaSelecionadaNome = null;
            while (categoriaSelecionadaNome == null)
            {
                Console.WriteLine("\nEscolha uma categoria de posição para jogar (digitando o número ou nome):");
                for (int i = 0; i < categoriasExistentes.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {categoriasExistentes[i]}");
                }
                Console.Write("Sua escolha de categoria: ");

                string? entradaCategoria = Console.ReadLine();
                if (int.TryParse(entradaCategoria, out int escolhaNumericaCategoria))
                {
                    if (escolhaNumericaCategoria > 0 && escolhaNumericaCategoria <= categoriasExistentes.Count)
                    {
                        categoriaSelecionadaNome = categoriasExistentes[escolhaNumericaCategoria - 1];
                    }
                    else
                    {
                        Console.WriteLine("Número de categoria inválido. Por favor, digite um número da lista.");
                    }
                }
                else
                {
                    string entradaTextoFormatada = entradaCategoria?.ToLower().Trim() ?? string.Empty;
                    categoriaSelecionadaNome = categoriasExistentes.FirstOrDefault(c => c.ToLower() == entradaTextoFormatada);
                    if (categoriaSelecionadaNome == null)
                    {
                        Console.WriteLine("Entrada inválida. Por favor, digite o número ou o nome exato da categoria.");
                    }
                }
            }

            List<Posicao> posicoesNaCategoria = todasAsPosicoes
                .Where(p => p.Categoria.Equals(categoriaSelecionadaNome, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (!posicoesNaCategoria.Any())
            {
                Console.WriteLine($"Erro: Nenhuma posição encontrada para a categoria '{categoriaSelecionadaNome}'.");
                return;
            }

            Random rnd = new Random();
            Posicao posicaoAtribuida = posicoesNaCategoria[rnd.Next(posicoesNaCategoria.Count)];

            Console.WriteLine($"Você escolheu a categoria '{categoriaSelecionadaNome}'. Sua posição atribuída será: {posicaoAtribuida.Nome}.");
            Console.WriteLine("Entrando na partida... ");

            var jogador = new Conta_Jogador(nome: "Jogador Categoria", senha: "senhaAleatoria", idade: 25, posicao: posicaoAtribuida.Nome);

            if (jogoAtual.AdicionarInteressado(jogador))
            {
                Console.WriteLine("Jogador adicionado com sucesso ao jogo!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar o jogador (talvez já esteja interessado ou o jogo esteja fechado).");
            }
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
