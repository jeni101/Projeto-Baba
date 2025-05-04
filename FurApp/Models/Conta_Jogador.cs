using ContaUsuarioApp;

namespace ContaJogadorApp
{
    public class Conta_Jogador : Conta_Usuario 
    {
        public string Posicao { get; set; }
        public string Time { get; private set; }
        public string Codigo_RA { get; private set; }
        public int Gols { get; private set; }
        public int Assistencias { get; private set; }
        public List<string> Eventos { get; private set; } 
        public List<string> Jogos { get; private set; } 
        public List<string> Partidas { get; private set; } 

        //Construtor padrão
        public Conta_Jogador(string nome, 
                            string senha, 
                            int idade, 
                            string posicao, 
                            float? saldo = null, 
                            string? interesses = null, 
                            string? amistosos = null,
                            string? time = null,
                            int? gols = null, 
                            int? assistencias = null,
                            HashSet<string>? jogadores = null)
            : base(nome, senha, idade, saldo ?? 0f, interesses ?? string.Empty, amistosos ?? string.Empty) // variaveis nulas p criacao de conta 
        {
            Posicao = posicao;
            Time = time ?? string.Empty;
            Codigo_RA = GerarCodigo(jogadores ?? new HashSet<string>());
            Gols = gols ?? 0;
            Assistencias = assistencias ?? 0;
            Eventos = new List<string>();  // Inicializando a lista
            Jogos = new List<string>();    // Inicializando a lista
            Partidas = new List<string>(); 
        }

        //Código
        private string GerarCodigo(HashSet<string> codigosExistentes)
        {
            Random random = new Random();
            string codigo;

            do
            {
                int numeroAleatorio = random.Next(100000, 999999);
                codigo = numeroAleatorio.ToString();

            } while (codigosExistentes.Contains(codigo));
            return codigo;
        }

        public void Exibir_Time()
        {
            if (!string.IsNullOrEmpty(Time))
            {
                Console.WriteLine(Time);
            }
            else
            {
                Console.WriteLine("Sem time");
            }
        }
        //SairTime será parte das funcoes de time
        public void Sair_Time(){}

        public void Exibir_Codigo()
        {
            Console.WriteLine(!string.IsNullOrEmpty(Codigo_RA) ? $"Código do Jogador: {Codigo_RA}" : "Código não definido");
        }
        public void Exibir_Gols()
        {
            Console.WriteLine($"Gols: {Gols}");
        }
        public void Exibir_Assistencias()
        {
            Console.WriteLine($"Assistencias: {Assistencias}");
        }
        public void Exibir_Jogos()
        {
            if (Jogos.Count > 0)
            {
                Console.WriteLine("Jogos:");
                foreach (var jogo in Jogos)
                {
                    Console.WriteLine(jogo);
                }
            }
            
            else
            {
                Console.WriteLine("Nenhum jogo registrado");
            }
        }
        public void Exibir_Partidas()
        {
            if (Partidas.Count > 0)
            {
                Console.WriteLine("Partidas:");
                foreach (var partida in Partidas)
                {
                    Console.WriteLine(partida);
                }
            }

            else
            {
                Console.WriteLine("Nenhuma partida registrada");
            }
        }
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