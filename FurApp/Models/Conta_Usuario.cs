using System;
using ContaApp;
using System.Linq;
using PersistenciaApp;
using MenuPerfilApp;
using ContaJogadorApp;


namespace ContaUsuarioApp
{
    public class ContaUsuario : Conta
    {
        // rever se os atibutos e metodos continuarao publicos
        public float Saldo { get; private set; }
        public string Interesses { get; set; }
        public string Amistosos { get; set; }

        public ContaUsuario(string nome, 
                            string senha, 
                            int idade, 
                            float saldo, 
                            string interesses, 
                            string amistosos)
                            : base(nome, senha, idade)
        {
            Saldo = saldo;
            Interesses = interesses;
            Amistosos = amistosos;
        }
        

        public override bool Login(string nome, string senha)
        {
            return base.Login(nome, senha);
        }


        //amistoso
        public void CriarAmistosos() { }

        //grana
        public void ExibirSaldo() 
        {
            Console.WriteLine($"Saldo: {Saldo:F2}");
        }
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

