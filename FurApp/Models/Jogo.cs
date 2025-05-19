using Models.ContaApp.Usuario.Jogador;

namespace Models.JogosApp
{
    public class Jogo
    {
        public Guid Id { get; protected set; }
        public DateOnly Data { get; private set; }
        public TimeOnly Hora { get; private set; }
        public string Local { get; private set; }
        public string TipoDeCampo { get; private set; }
        public List<string> Interessados { get; private set; }
        public int QuantidadeDeJogadores { get; private set; }

        //construtores
        public Jogo(DateOnly data,
                    TimeOnly hora,
                    string local,
                    string tipoDeCampo,
                    int quantidadeDeJogadores)
        {
            Data = data;
            Hora = hora;
            Local = local ?? throw new ArgumentNullException(nameof(local));
            TipoDeCampo = tipoDeCampo ?? throw new ArgumentNullException(nameof(tipoDeCampo));
            QuantidadeDeJogadores = quantidadeDeJogadores > 0
                ? quantidadeDeJogadores
                : throw new ArgumentException("A quantidade de jogadores deve ser positiva");
            Interessados = new List<string>();
            Id = Guid.NewGuid();
        }

        //funcoes
        public void Alterar_Data()
        {
            string entrada = Console.ReadLine() ?? string.Empty;

            if (DateOnly.TryParseExact(entrada, "dd/MM/yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateOnly novaData))
            {
                Data = novaData;
            }
        }

        public void Alterar_Hora()
        {
            string entrada = Console.ReadLine() ?? "0";

            if (TimeOnly.TryParseExact(entrada, "HH:mm", null,
                System.Globalization.DateTimeStyles.None, out TimeOnly novaHora))
            {
                Hora = novaHora;
            }
        }

        public void Alterar_Local()
        {
            string novoLocal = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoLocal))
            {
                Local = novoLocal;
            }
        }

        public void Alterar_Tipo_De_Campo()
        {
            string novoTipo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoTipo))
            {
                TipoDeCampo = novoTipo;
            }
        }

        public void Alterar_Quantidade_De_Jogadores()
        {
            string entrada = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entrada, out int novaQuantidade) && novaQuantidade > 0)
            {
                QuantidadeDeJogadores = novaQuantidade;
            }
        }

        public void AdicionarInteressado(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
            {
                Interessados.Add(nome);
            }
        }

        public bool AdicionarInteressado(Conta_Jogador jogador)
        {
            if (jogador == null) return false;

            string indentificacao = $"Jogador {jogador.Nome} ({jogador.Posicao})";

            if (!Interessados.Contains(indentificacao))
            {
                Interessados.Add(indentificacao);
                jogador.Interesses.Add($"Jogo em {Data} às {Hora} no {Local}");
                return true;
            }

            return false;
        }

        public bool RemoverInteressado(Conta_Jogador jogador)
        {
            if (jogador == null) return false;

            string indentificacao = $"{jogador.Nome} ({jogador.Posicao})";
            bool removido = Interessados.Remove(indentificacao);

            if (removido)
            {
                jogador.Interesses.Remove($"Jogo em {Data} às {Hora} no {Local}");
            }

            return removido;
        }
    }
}