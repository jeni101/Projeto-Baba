using System;


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
        public void AlterarData()
        {
            string entrada = Console.ReadLine();

            if (DateOnly.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateOnly novaData))
            {
                Data = novaData;
            }
        }
        public void AlterarHora()
        {
            string entrada = Console.ReadLine();

            if (TimeOnly.TryParseExact(entrada, "hh:mm", null, System.Globalization.DateTimeStyles.None, out TimeOnly novaHora))
            {
                Hora = novaHora;
            }
        }
        public void AlterarLocal()
        {
            string novoLocal = Console.ReadLine();
            Local = novoLocal;
        }
        public void AlterarTipoDeCampo()
        {
            string novoTipoDeCampo = Console.ReadLine();
            TipoDeCampo = novoTipoDeCampo;
        }
        public void AlterarQUantidadeDeJogadores()
        {
            int novaQuantidadeDeJogadores = Int32.Parse(Console.ReadLine());
            QuantidadeDeJogadores = novaQuantidadeDeJogadores;
        }
    }
}