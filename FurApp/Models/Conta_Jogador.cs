using Interfaces.IJogador;
using Models.JogosApp;
using Models.PosicaoApp;
using Models.TimesApp;

namespace Models.ContaApp.Usuario.Jogador
{
    public class Conta_Jogador : Conta_Usuario, IJogador
    {
        public string Posicao { get; set; }
        public Time? Time { get; private set; }
        public List<string> Partidas { get; private set; }

        //Construtor padrão
        public Conta_Jogador(
            string nome,
            string senha,
            int idade,
            string posicao)
            : base(nome, senha, idade)
        {
            Time = null;
            Posicao = posicao;
            Partidas = new List<string>();
        }

        //Construtor db
        public Conta_Jogador(
            Guid id, string nome, string senhaHash, int idade, string posicao, Time? time,
            List<string> interesses, List<string> partidas, bool tornouSeJogador, bool tornouSeTecnico, DateTime dataCriacao,
            bool deletado, DateTime? dataDelecao, string? quemDeletou)
            : base (id, nome, senhaHash, idade, interesses, tornouSeJogador, tornouSeTecnico, dataCriacao, deletado, dataDelecao, quemDeletou)
        {
            Posicao = posicao;
            Time = time;
            Partidas = partidas ?? new List<string>();
        }

        //Interfaces
        void IJogador.Escolher_Posicao(List<Posicao> posicoesDisponiveis)
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
                Console.WriteLine($"Time: {Time} - {Time.Abreviacao}");
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

        //Interesses
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