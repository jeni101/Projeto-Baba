using Models.ContaApp.Usuario;
using Interfaces.IJogador;

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
            string posicao,
            float? saldo = null,
            string? interesses = null,
            string? amistosos = null,
            string? time = null,
            int? gols = null,
            int? assistencias = null)
            : base(nome, senha, idade, saldo ?? 0f, interesses ?? string.Empty, amistosos ?? string.Empty)
        {
            Posicao = posicao;
            Time = time ?? string.Empty;
            Gols = gols ?? 0;
            Assistencias = assistencias ?? 0;
            Eventos = new List<string>();  // Inicializando a lista
            Jogos = new List<string>();    // Inicializando a lista
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
        void IJogador.Escolher_Posicao()
        {
            // Implementação futura
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
    }
}