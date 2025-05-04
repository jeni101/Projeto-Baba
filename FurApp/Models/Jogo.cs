namespace JogosApp
{
    public class Jogos
    {
        public DateOnly Data { get; private set; }
        public TimeOnly Hora { get; private set; }
        public string Local { get; private set;}
        public string TipoDeCampo { get; private set; }
        public List<string> Interessados { get; private set; }
        public int QuantidadeDeJogadores { get; private set; }

        //construtores
        public Jogos(DateOnly data,
                    TimeOnly hora,
                    string local,
                    string tipoDeCampo,
                    int quantidadeDeJogadores)
        {
            Data = data;
            Hora = hora;
            Local = local;
            Interessados = new List<string>();
            TipoDeCampo = tipoDeCampo;
            QuantidadeDeJogadores = quantidadeDeJogadores;
        }

        //funcionalidades
        public void Alterar_Data()
        {
            string entrada = Console.ReadLine() ?? "0";

            if (DateOnly.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly novaData))
            {
                Data = novaData;
            }
        }
        public void Alterar_Hora()
        {
            string entrada = Console.ReadLine() ?? "0";

            if (TimeOnly.TryParseExact(entrada, "hh:mm", null, System.Globalization.DateTimeStyles.None, out TimeOnly novaHora))
            {
                Hora = novaHora;
            }
        }
        public void Alterar_Local()
        {
            string novoLocal = Console.ReadLine() ?? "0";
            Local = novoLocal;
        }
        public void Alterar_Tipo_De_Campo()
        {
            string novoTipoDeCampo = Console.ReadLine() ?? "0";
            TipoDeCampo = novoTipoDeCampo;
        }
        public void Alterar_Quantidade_De_Jogadores()
        {
            int novaQuantidadeDeJogadores = Int32.Parse(Console.ReadLine() ?? "0");
            QuantidadeDeJogadores = novaQuantidadeDeJogadores;
        }
    }
}