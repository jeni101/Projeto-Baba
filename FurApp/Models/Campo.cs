using System;
using Models.CamposApp.Tipo;
using System.Text.Json.Serialization;

namespace Models.CamposApp
{
    public class Campo : AModel
    {
        public string Nome { get; set; }
        public string Local { get; set; }
        public int Capacidade { get; set; }
        public TipoDeCampo TipoDeCampo { get; set; }
        public bool Deletado { get; set; }
        public DateTime? DataDelecao { get; set; }
        public string? QuemDeletou { get; set; }

        public Campo()
        {
            Nome = string.Empty;
            Local = string.Empty;
            Capacidade = 0;
            TipoDeCampo = new TipoDeCampo(); 
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        public Campo(string nome, string localizacao, int capacidade, TipoDeCampo tipoDeCampo)
        {
            Id = Guid.NewGuid();
            Nome = nome.Trim();
            Local = localizacao.Trim();
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo ?? throw new ArgumentNullException(nameof(tipoDeCampo), "Tipo de campo não pode ser nulo.");
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        public Campo(Guid id, string nome, string local, int capacidade, TipoDeCampo tipoDeCampo,
                     bool deletado, DateTime? dataDelecao, string? quemDeletou)
        {
            Id = id;
            Nome = nome.Trim();
            Local = local.Trim();
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo ?? throw new ArgumentNullException(nameof(tipoDeCampo), "Tipo de campo não pode ser nulo.");
            Deletado = deletado;
            DataDelecao = dataDelecao;
            QuemDeletou = quemDeletou;
        }

        public void AtualizarDados(string nome, string local, int capacidade, TipoDeCampo tipoDeCampo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome do campo não pode ser vazio ou nulo.", nameof(nome));
            if (string.IsNullOrWhiteSpace(local))
                throw new ArgumentException("Local do campo não pode ser vazio ou nulo.", nameof(local));
            if (capacidade <= 0)
                throw new ArgumentException("Capacidade do campo deve ser um número positivo.", nameof(capacidade));
            if (tipoDeCampo == null)
                throw new ArgumentNullException(nameof(tipoDeCampo), "Tipo de campo não pode ser nulo.");

            Nome = nome.Trim();
            Local = local.Trim();
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo;
        }

        public void MarcarComoDeletado(string quemDeletou)
        {
            Deletado = true;
            DataDelecao = DateTime.Now;
            QuemDeletou = quemDeletou;
        }

        public void MarcarComoAtivo()
        {
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        public override string ToString() =>
            $"{Nome} | {Local} | Capacidade: {Capacidade} | Tipo: {TipoDeCampo.Tipo}";
    }
}