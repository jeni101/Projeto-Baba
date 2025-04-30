using System;


namespace ContaJogadorApp
{
    public class Jogos
    {
        public DateTime Data { get; private set; }
        public string Local { get; private set;}
        public string TipoDeCampo { get; private set; }
        public List<string> Interessados { get; private set; }
        public int QuantidadeDeJogadores { get; private set; }

        //construtores
        public Jogos(DateTime data,
                    string local,
                    string tipoDeCampo,
                    int quantidadeDeJogadores)
        {
            Data = data;
            Local = local;
            Interessados = new List<string>();
            TipoDeCampo = tipoDeCampo;
            QuantidadeDeJogadores = quantidadeDeJogadores;
        }

        //funcionalidades
        public void AlterarData()
        {
            string entrada = Console.ReadLine();

            if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime novaData))
            {
                Data = novaData;
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