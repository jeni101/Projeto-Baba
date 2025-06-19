using System;
using Models.CamposApp.Tipo;
using Repository.PersistenciaApp.Campos;

namespace Models.CamposApp
{
    public class Campo
    {
        //Atributos
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Local { get; private set; }
        public int Capacidade { get; private set; }
        public TipoDeCampo TipoDeCampo { get; private set; }
        public bool Deletado { get; private set; }
        public DateTime? DataDelecao { get; private set; }
        public string? QuemDeletou { get; private set; }

        //Construtor
        public Campo(string nome, string localizacao, int capacidade, TipoDeCampo tipoDeCampo)
        {
            Id = Guid.NewGuid();
            Nome = nome.Trim();
            Local = localizacao.Trim();
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo ?? throw new ArgumentNullException(nameof(tipoDeCampo), "Tipo de campo Não pode ser nulo");
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        //Construtor db
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

        //Atualizar
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
            DataDelecao = DateTime.Now; // Data e hora atual do sistema
            QuemDeletou = quemDeletou;
        }

        // Método para "restaurar" o campo
        public void MarcarComoAtivo()
        {
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        //String-lizador
        public override string ToString() =>
            $"{Nome} | {Local} | Capacidade: {Capacidade} | Tipo: {TipoDeCampo.Tipo}";
    }
}