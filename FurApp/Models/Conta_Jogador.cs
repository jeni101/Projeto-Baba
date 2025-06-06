using Models.ContaApp.Usuario;
using Interfaces.IJogador;
using Models.JogosApp;
using Models.PosicaoApp;

namespace Models.ContaApp.Usuario.Jogador
{
    public class Conta_Jogador : Conta_Usuario, IJogador
    {
        public string Posicao { get; set; }
        public string Time { get; private set; }
        public int Gols { get; private set; }
        public int Assistencias { get; private set; }
        public List<string> Eventos { get; private set; }
        public List<string> Jogos { get; private set; }
        public List<string> Partidas { get; private set; }

        //Construtor padrão
        public Conta_Jogador(
            string nome,
            string senha,
            int idade,
            string posicao)
            : base(nome, senha, idade)
        {
            Time = string.Empty;
            Posicao = posicao;
            Eventos = new List<string>();
            Jogos = new List<string>();
            Partidas = new List<string>();
        }

        //Interface
        void IJogador.Exibir_Gols()
        {
            Console.WriteLine($"Gols: {Gols}");
        }
        void IJogador.Exibir_Assistencias()
        {
            Console.WriteLine($"Assistências: {Assistencias}");
        }
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
            if (!string.IsNullOrEmpty(Time))
            {
                Console.WriteLine(Time);
            }
            else
            {
                Console.WriteLine("Sem time"); //LUIS VERIFICA O OUTPUT
            }
        }
        void IJogador.Exibir_Jogos()
        {
            if (Jogos.Count > 0)
            {
                Console.WriteLine("Jogos:"); //LUIS VERIFICA O OUTPUT
                foreach (var jogo in Jogos)
                {
                    Console.WriteLine(jogo);
                }
            }
            else
            {
                Console.WriteLine("Nenhum jogo registrado"); //LUIS VERIFICA O OUTPUT
            }
        }

        void IJogador.Exibir_Partidas()
        {
            if (Partidas.Count > 0)
            {
                Console.WriteLine("Partidas:"); //LUIS VERIFICA O OUTPUT
                foreach (var partida in Partidas)
                {
                    Console.WriteLine(partida);
                }
            }
            else
            {
                Console.WriteLine("Nenhuma partida registrada"); //LUIS VERIFICA O OUTPUT
            }
        }

        void IJogador.Entrar_Time()
        {
            // Implementação futura
        }

        // Adicionar estatísticas
        public void Adicionar_Gols()
        {
            Gols++;
        }

        public void Adicionar_Assistencia()
        {
            Assistencias++;
        }

        //Interesses
        public void EntrarComoInteressado(Jogo interesse)
        {
            if (interesse == null)
            {
                Console.WriteLine("Jogo inválido");
                return;
            }

            if (interesse.AdicionarInteressado(this))
            {
                Console.WriteLine($"Você está interessado no jogo em {interesse.Data}");
            }
            else
            {
                Console.WriteLine("Você já demonstrou interesse");
            }
        }

        public void SairComoInteressado(Jogo interesse)
        {
            if (interesse == null)
            {
                Console.WriteLine("Jogo inválido");
                return;
            }

            if (interesse.AdicionarInteressado(this))
            {
                Console.WriteLine($"Você não está mais interessado no jogo em {interesse.Data}");
            }
            else
            {
                Console.WriteLine("Você não estava interessado");
            }
        }
    }
}