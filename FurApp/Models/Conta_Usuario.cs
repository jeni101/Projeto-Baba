using System;
using System.Collections.Generic;
using System.IO;
using ContaApp;
using System.Linq;
using System.Text.Json;
using ContaJogadorApp;
using PosicoesApp;


namespace ContaUsuarioApp
{
    public class ContaUsuario : Conta
    {
        public float Saldo { get; private set; }
        public string Interesses { get; set; }
        public string Amistosos { get; set; }
        public bool TournouSeJogador { get; private set; }

        //Construtor
        public ContaUsuario(string nome, 
                            string senha, 
                            int idade, 
                            float saldo, 
                            string interesses, 
                            string amistosos,
                            bool tournouSeJogador = false)
                            : base(nome, senha, idade)
        {
            Saldo = saldo;
            Interesses = interesses;
            Amistosos = amistosos;
            TournouSeJogador = tournouSeJogador;
        }
        
        //Login
        public override bool Login(string nome, string senha)
        {
            return base.Login(nome, senha);
        }

        //Register
        public override void Register()
        {
            try
            {
                List<ContaUsuario> contas = PersistenciaDeContas.CarregarContas();

                if (contas.Any(c=>c.Nome == Nome))
                {
                    Console.WriteLine("Erro: Nome de usuário já registrado");
                    return;
                }

                string senhaValida = DefinirSenha();

                var jogadoresExistentes = contas
                    .OfType<ContaJogador>()
                    .ToList();

                var codigosExistentes = new HashSet<string>(jogadoresExistentes.Select(j => j.Codigo));

                TournouSeJogador = true;

                var contaJogador = new ContaJogador(
                    Nome,
                    senhaValida,
                    Idade,
                    posicao: "Não definida",
                    saldo : Saldo,
                    interesses : Interesses,
                    amistosos : Amistosos,
                    jogadores : codigosExistentes
                );
                
                contas.Add(contaJogador);
                Console.WriteLine(contaJogador.Codigo);

                PersistenciaDeContas.SalvarContas(contas);

                Console.WriteLine("Conta registrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro {ex.Message}");
            }
        }

        //Senha
        private string DefinirSenha()
        {
            while (true)
            {
                Console.WriteLine("Defina sua senha (min. 6 char.): ");
                string senha = Console.ReadLine();

                if (senha.Length < 6)
                {
                    Console.WriteLine("Senha muito curta");
                    continue;
                }

                Console.WriteLine("Confirme sua senha: ");
                string confirmacaoSenha = Console.ReadLine();

                if (senha == confirmacaoSenha)
                {
                    return senha;
                }

                Console.WriteLine("Senhas não coicidem");
            }
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
        //Temos que rever coisas relacionadas ao perfil
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

