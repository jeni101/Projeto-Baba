using ContaApp;
using ContaJogadorApp;
using PersistenciaApp;

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
                            string amistosos)
                            : base(nome, senha, idade)
        {
            Saldo = saldo;
            Interesses = interesses;
            Amistosos = amistosos;
            TornouSeJogador = false;
            DataCriacao = DateTime.Now;
        }
        
        //Login
        public override bool Login(string nome, string senha)
        {
            bool sucesso = base.Login(nome, senha);
            if (sucesso)
            {
                Console.WriteLine($"Bem vindo(a), {Nome}!");
            }
            return sucesso;
        }

        //Register
        public override void Register()
        {
            try
            {
                List<Conta_Jogador> contas = PersistenciaDeJogador.CarregarJogadores();

                if (contas.Any(c=>c.Nome == Nome))
                {
                    Console.WriteLine("Erro: Nome de usuário já registrado");
                    return;
                }

                string senhaValida = Definir_Senha(3);

                var contaJogador = new Conta_Jogador(
                    Nome,
                    senhaValida,
                    Idade,
                    "Não definida",
                    Saldo,
                    Interesses,
                    Amistosos
                );
                
                contas.Add(contaJogador);

                PersistenciaDeJogador.SalvarJogador(contaJogador);

                Console.WriteLine("Conta registrada com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro {ex.Message}");
            }
        }

        //Senha
        private string Definir_Senha(int maxTentativas = 3)
        {
            for (int i = 0; i < maxTentativas; i++)
            {
                Console.WriteLine("Defina sua senha (min. 6 char.): ");
                string senha = Console.ReadLine() ?? "";

                if (senha.Length < 6)
                {
                    Console.WriteLine("Senha muito curta");
                    continue;
                }

                Console.WriteLine("Confirme sua senha: ");
                string confirmacaoSenha = Console.ReadLine() ?? "";

                if (senha == confirmacaoSenha)
                {
                    return senha;
                }

                Console.WriteLine("Senhas não coicidem");
            }
            throw new InvalidOperationException("Número máximo de tentativas atingido");
        }

        //amistoso
        public void CriarAmistosos() { }

        //grana
        public void ExibirSaldo() 
        {
            Console.WriteLine($"Saldo: {Saldo:F2}");
        }
        public void Apostar(float valor) 
        {
            if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para essa aposta");
                return;
            }
            Saldo -= valor;
            Console.WriteLine($"Aposta de R$ {valor:F2} realizada com sucesso");
        }

        //perfil
        public void Exibir_Perfil() 
        {
            Console.WriteLine($"""
            === PERFIL DE {Nome} ===
            ID: {Id}
            Idade: {Idade}
            Saldo: R$ {Saldo:F2}
            Data de Criação: {DataCriacao:dd/MM/yyyy}
            Interesses: {Interesses}
            Amistosos: {Amistosos}
            """);
        }
        protected void DefinirId(Guid id)
        {
            this.Id = Guid.NewGuid();
        }
        public void Editar_Perfil() { }
        public void Deletar_Conta() { }
        public void Exibir_Interesses() { }
        public void Deletar_Interesses() { }

        // funcionalidade
        public void Inscrever_Em_Eventos() { }
        public void Participar_De_Eventos() { }
        public void Sair_De_Eventos() { }
    }
}

