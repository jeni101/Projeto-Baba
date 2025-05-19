using System;

namespace Models.PosicaoApp
{
    public class Posicao
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public string Abreviacao { get; set; }

        public Posicao(string nome, string categoria, string abreviacao)
        {
            Nome = nome;
            Categoria = categoria;
            Abreviacao = abreviacao;
        }
    }
}