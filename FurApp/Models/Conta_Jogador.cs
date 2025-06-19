using Interfaces.IJogador;
using Models.JogosApp;
using Models.PosicaoApp;
using Models.TimesApp;
using System; // Para Guid
using System.Collections.Generic; // Para List
using System.Text.Json.Serialization; // Necessário para [JsonConstructor]

namespace Models.ContaApp.Usuario.Jogador
{
    public class Conta_Jogador : Conta_Usuario, IJogador
    {
        public string Posicao { get; set; }
        public Time? Time { get; set; } // Mudado de private set para public set
        public List<string> Partidas { get; set; } // Mudado de private set para public set

        // Construtor sem parâmetros (ESSENCIAL para System.Text.Json)
        public Conta_Jogador() : base() // Chama o construtor sem parâmetros de Conta_Usuario
        {
            Posicao = string.Empty;
            Time = null; // Pode ser null se o jogador não estiver em um time
            Partidas = new List<string>();
        }

        // Construtor padrão (para criação manual de objetos)
        public Conta_Jogador(
            string nome,
            string senha,
            int idade,
            string posicao)
            : base(nome, senha, idade) // Chama o construtor de Conta_Usuario
        {
            Posicao = posicao;
            Time = null;
            Partidas = new List<string>(); // Garante que a lista é inicializada
        }

        // Construtor de desserialização (o MAIS IMPORTANTE, e marcado com [JsonConstructor])
        // Este construtor deve ter parâmetros para TODAS as propriedades que serão desserializadas,
        // tanto as próprias de Conta_Jogador quanto as herdadas de Conta_Usuario e Conta.
        [JsonConstructor]
        public Conta_Jogador(
            // Propriedades herdadas de AModel:
            Guid id,
            // Propriedades herdadas de Conta:
            string nome, string senhaHash, int idade,
            // Propriedades herdadas de Conta_Usuario:
            List<string> interesses, bool tornouSeJogador, bool tornouSeTecnico, DateTime dataCriacao,
            bool deletado, DateTime? dataDelecao, string? quemDeletou,
            // Propriedades próprias de Conta_Jogador:
            string posicao, Time? time, List<string> partidas)
            // Chama o construtor DB da classe base Conta_Usuario com seus parâmetros
            : base(id, nome, senhaHash, idade, interesses, tornouSeJogador, tornouSeTecnico, dataCriacao, deletado, dataDelecao, quemDeletou)
        {
            // Atribua as propriedades próprias da Conta_Jogador
            Posicao = posicao;
            Time = time;
            Partidas = partidas ?? new List<string>(); // Garante que a lista não é nula
        }

        // Implementações das Interfaces (IJogador)
        void IJogador.Escolher_Posicao(List<PosicaoApp.Posicao> posicoesDisponiveis)
        {
            if (posicoesDisponiveis == null || posicoesDisponiveis.Count == 0)
            {
                Console.WriteLine("Nenuma posição disponível");
                return;
            }

            Console.WriteLine("Escolha sua posição");
            for (int i = 0; i < posicoesDisponiveis.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {posicoesDisponiveis[i].Nome} ({posicoesDisponiveis[i].Abreviacao})");
            }

            Console.WriteLine("Digite o número da posicao que deseja ser");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= posicoesDisponiveis.Count)
            {
                Posicao = posicoesDisponiveis[escolha - 1].Nome;
                Console.WriteLine($"Posição definida como: {Posicao}");
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente");
            }
        }

        void IJogador.Exibir_Time()
        {
            if (Time != null)
            {
                Console.WriteLine($"Time: {Time.Nome} - {Time.Abreviacao}");
            }
            else
            {
                Console.WriteLine("Você não está em nenhum time");
            }
        }

        public void SairDoTime()
        {
            this.Time = null;
        }

        void IJogador.Exibir_Jogos()
        {
            if (Interesses.Count > 0)
            {
                Console.WriteLine("Jogos de Interesses: ");
                foreach (var jogoNome in Interesses)
                {
                    Console.WriteLine($"- {jogoNome}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum jogo de interesse registrado");
            }
        }

        void IJogador.Exibir_Partidas()
        {
            if (Partidas.Count > 0)
            {
                Console.WriteLine("Partidas jogadas: ");
                foreach (var partidaId in Partidas)
                {
                    Console.WriteLine($"- {partidaId}");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma partida jogada registrada");
            }
        }

        void IJogador.Entrar_Time()
        {
            // Implementação futura
        }

        // Métodos de Interesses
        public void EntrarComoInteressado(Jogo interesse)
        {
            if (interesse == null)
            {
                Console.WriteLine("Jogo inválido.");
                return;
            }

            if (interesse.AdicionarInteressado(this))
            {
                string nomeDoJogoParaLista = interesse.GerarNome();

                if (!this.Interesses.Contains(nomeDoJogoParaLista))
                {
                    this.Interesses.Add(nomeDoJogoParaLista);
                    Console.WriteLine($"Você demonstrou interesse no jogo: {nomeDoJogoParaLista}");
                }
                else
                {
                    Console.WriteLine("Você já demonstrou interesse neste jogo (lista do jogador já contém).");
                }
            }
            else
            {
                Console.WriteLine("Não foi possível demonstrar interesse neste jogo (provavelmente já interessado ou erro no Jogo).");
            }
        }

        public void SairComoInteressado(Jogo interesse)
        {
            if (interesse == null)
            {
                Console.WriteLine("Jogo inválido.");
                return;
            }

            if (interesse.RemoverInteressado(this))
            {
                string nomeDoJogoParaLista = interesse.GerarNome();

                if (this.Interesses.Remove(nomeDoJogoParaLista))
                {
                    Console.WriteLine($"Você não está mais interessado no jogo: {nomeDoJogoParaLista}");
                }
                else
                {
                    Console.WriteLine("Você não estava interessado neste jogo (lista do jogador não continha).");
                }
            }
            else
            {
                Console.WriteLine("Não foi possível remover o interesse neste jogo (provavelmente não estava interessado ou erro no Jogo).");
            }
        }
    }
}