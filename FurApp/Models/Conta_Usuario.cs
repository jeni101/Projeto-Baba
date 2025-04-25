using System;
using ContaApp;

namespace ContaUsuarioApp
{
    public class ContaUsuario : Conta
    {
        // rever se os atibutos e metodos continuarao publicos
        public float Saldo { get; set; }
        public string Interesses { get; set; }
        public string Amistosos { get; set; }

        public ContaUsuario(string nome, string senha, int idade, float saldo, string interesses, string amistosos)
            : base(nome, senha, idade)
        {
            Saldo = saldo;
            Interesses = interesses;
            Amistosos = amistosos;
        }

        //amistoso
        public void CriarAmistosos() { }
        public void EntrarAmistoso() { }
        public void SairAmistoso() { }

        //grana
        public void ExibirSaldo() { }
        public void Apostar() { }

        // perfil 
        public void ExibirPerfil() { }
        public void EditarPerfil() { }
        public void DeletarConta() { }
        public void AdicionarInteresses() { }
        public void ExibirInteresses() { }
        public void DeletarInteresses() { }

        // funcionalidade
        public void InscreverEmEventos() { }
        public void ParticiparDeEventos() { }
        public void SairDeEventos() { }




    }
}

