using System;
using System.Text.Json.Serialization;

namespace Models.PosicaoApp
{
    public class Posicao : AModel
    {
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Abreviacao { get; set; }

        public Posicao() 
                : base ()
        {
            Nome = string.Empty;
            Categoria = string.Empty;
            Abreviacao = string.Empty;
        }

        public Posicao(string nome, string categoria, string abreviacao) : this()
        {
            Nome = nome;
            Categoria = categoria;
            Abreviacao = abreviacao;
        }

        public Posicao(Guid id, string nome, string categoria, string abreviacao) : this(nome, categoria, abreviacao)
        {
            Id = id;
        }
    }
}