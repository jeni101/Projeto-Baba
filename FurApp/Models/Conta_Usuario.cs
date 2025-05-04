using ContaApp;
using ContaJogadorApp;

namespace ContaUsuarioApp
{
    public class Conta_Usuario : Conta
    {
        public float Saldo { get; private set; }
        public string Interesses { get; set; }
        public string Amistosos { get; set; }
        public bool TornouSeJogador { get; private set; }
        public DateTime DataCriacao { get; private set; }

        //Construtor
        public Conta_Usuario(string nome, 
                            string senha, 
                            int idade, 
                            float saldo, 
                            string interesses, 
                            string amistosos,
                            bool tornouSeJogador = false)
                            : base(nome, senha, idade)
        {
            Saldo = saldo;
            Interesses = interesses;
            Amistosos = amistosos;
            TornouSeJogador = tornouSeJogador;
            DataCriacao = DateTime.Now;
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
                List<Conta_Usuario> contas = Persistencia_De_Contas.Carregar_Contas();

                if (contas.Any(c=>c.Nome == Nome))
                {
                    Console.WriteLine("Erro: Nome de usuário já registrado");
                    return;
                }

                string senhaValida = Definir_Senha();

                var jogadoresExistentes = contas
                    .OfType<Conta_Jogador>()
                    .ToList();

                var codigosExistentes = new HashSet<string>(jogadoresExistentes.Select(j => j.Codigo_RA));

                TornouSeJogador = true;

                var contaJogador = new Conta_Jogador(
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
                Console.WriteLine(contaJogador.Codigo_RA);

                Persistencia_De_Contas.Salvar_Contas(contas);

                Console.WriteLine("Conta registrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro {ex.Message}");
            }
        }

        //Senha
        private string Definir_Senha()
        {
            while (true)
            {
                Console.WriteLine("Defina sua senha (min. 6 char.): ");
                string senha = Console.ReadLine() ?? "0";

                if (senha.Length < 6)
                {
                    Console.WriteLine("Senha muito curta");
                    continue;
                }

                Console.WriteLine("Confirme sua senha: ");
                string confirmacaoSenha = Console.ReadLine() ?? "0";

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
        public void Exibir_Perfil() { }
        public void Editar_Perfil() { }
        public void Deletar_Conta() { }
        public void Adicionar_Interesses() { }
        public void Exibir_Interesses() { }
        public void Deletar_Interesses() { }

        // funcionalidade
        public void Inscrever_Em_Eventos() { }
        public void Participar_De_Eventos() { }
        public void Sair_De_Eventos() { }
    }
}

