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

        //Construtor
        public Campo(string nome, string localizacao, int capacidade, TipoDeCampo tipoDeCampo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Local = localizacao;
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo;
        }

        //Atualizar
        public void AtualizarDados(string nome, string local, int capacidade, TipoDeCampo tipoDeCampo)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ?
                throw new ArgumentException("Nome inválido") : nome.Trim();

            Local = string.IsNullOrWhiteSpace(local) ?
                throw new ArgumentException("Local inválido") : local.Trim();

            Capacidade = capacidade > 0 ?
                capacidade : throw new ArgumentException("Capacidade deve ser positiva");

            TipoDeCampo = tipoDeCampo ?? throw new ArgumentNullException(nameof(tipoDeCampo), "Tipo de campo não pode ser nulo");
        }

        //String-lizador
        public override string ToString() => 
            $"{Nome} | {Local} | Capacidade: {Capacidade} | Tipo: {TipoDeCampo.Tipo}";
    }
}