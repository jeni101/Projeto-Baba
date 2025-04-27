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
        

        public override void Login(string tipoConta, string nome, string senha)
        {

            string tipo =  tipoConta switch
            {
                // converte a escolha
                "1" => "Jogador",
                "2" => "Tecnico",
                "3" => "Arbitro",
                _ => ""
            };
            var contas = PersistenciaDeContas.CarregarContasAgrupadas(); // le oq tem no json

            if (contas.TryGetValue(tipo, out var listaContas)) // procura pelo tipo de conta no caso seria as proprias chaves do json, se n achar a chave ele vai p else pq sem chave n tem conta
            {
                var contaEncontrada = listaContas.FirstOrDefault(c => c.Nome == nome && c.Senha == senha); // vai voltar a primeira conta q bater nome e senha dentro do tipo se n volta null
                if (contaEncontrada != null)
                {
                    Console.Clear();
                    Console.WriteLine($"loguin bem sucedido, Bem vindo! {contaEncontrada.Nome}");
                    Console.ReadLine(); // ver a mensagem
                    
                   if (contaEncontrada is ContaJogador contaJogador)
                    {   
                        // Agora contaJogador é do tipo correto p menu de jogador
                        MenuPerfilJogador menu = new MenuPerfilJogador(contaJogador);
                        menu.DisplayMenu();
                    }
                    else
                    {
                       Console.Write("em construcao p esse tipo de conta.");
                       Console.ReadLine();
                        // aqui chamar o outro menu generico p outras contas 
                    }

                }
                else
                {

                    Console.WriteLine("Login falhou, verifique seu nome e senha.");
                }
            }

            else
            {

                Console.WriteLine("Tipo de conta inválido.");
            }

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

