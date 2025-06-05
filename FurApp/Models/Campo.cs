using System;
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
        public string TipoDeCampo { get; private set; }

        //Construtor
        public Campo(string nome, string localizacao, int capacidade, string tipoDeCampo)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Local = localizacao;
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo;
        }

        //Atualizar
        public void AtualizarDados(string nome, string local, int capacidade, string tipoDeCampo)
        {
            Nome = string.IsNullOrWhiteSpace(nome) ?
                throw new ArgumentException("Nome inválido") : nome.Trim();

            Local = string.IsNullOrWhiteSpace(local) ?
                throw new ArgumentException("Local inválido") : local.Trim();

            Capacidade = capacidade > 0 ?
                capacidade : throw new ArgumentException("Capacidade deve ser positiva");

            TipoDeCampo = string.IsNullOrWhiteSpace(tipoDeCampo) ?
                throw new ArgumentException("Tipo inválido") : tipoDeCampo.Trim();
        }

        //String-lizador
        public override string ToString() => 
            $"{Nome} | {Local} | Capacidade: {Capacidade} | Tipo: {TipoDeCampo}";
    }
}