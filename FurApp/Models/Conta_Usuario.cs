using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using PersistenciaApp;

namespace ContaUsuarioApp
{
    public class Conta_Usuario : Conta
    {
        public float Saldo { get; private set; }
        public string Interesses { get; set; }
        public string Amistosos { get; set; }
        public bool TornouSeJogador { get; private set; }
        public bool TornouSeTecnico { get; private set;}
        public DateTime DataCriacao { get; private set; }

        //Construtor
        public Conta_Usuario(string nome, 
                            string senha, 
                            int idade, 
                            float saldo, 
                            string interesses, 
                            string amistosos,
                            bool querSerJogador = true,
                            bool querSerTecnico = false)
                            : base(nome, senha, idade)
        {
            Saldo = saldo;
            Interesses = interesses;
            Amistosos = amistosos;
            TornouSeJogador = querSerJogador;
            TornouSeTecnico = querSerTecnico;
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
                Console.WriteLine("Quer ser jogador, tecnico ou ambos?");
                Console.WriteLine("1 - Jogador");
                Console.WriteLine("2 - Tecnico");
                Console.WriteLine("3 - Ambos");
                
                var escolha  = Console.ReadLine();
                bool serJogador = false, serTecnico = false;

                switch (escolha)
                {
                    case "1":
                        serJogador = true;
                        break;
                    case "2":
                        serTecnico = true;
                        break;
                    case "3":
                        serJogador = true;
                        serTecnico = true;
                        break;
                    default:
                        serJogador = true;
                        break;
                }

                string senhaValida = Definir_Senha(3);

                if (serJogador)
                {
                    RegistrarComoJogador(senhaValida);
                }

                if (serTecnico)
                {
                    RegistrarComoTecnico(senhaValida);
                }

                Console.WriteLine("Registro feito");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void RegistrarComoJogador(string senha)
        {
            var contasJogador = PersistenciaDeJogador.CarregarJogadores();

            if (contasJogador.Any(c => c.Nome == Nome))
            {
                Console.WriteLine("Nome já registrado");
                return;
            }

            var contaJogador = new Conta_Jogador(
                Nome,
                senha,
                Idade,
                "Não definida",
                Saldo,
                Interesses,
                Amistosos
            );

            PersistenciaDeJogador.SalvarJogador(contaJogador);
            TornouSeJogador = true;
        }

        private void RegistrarComoTecnico(string senha)
        {
            var tecnicos = PersistenciaDeTecnico.CarregarTecnicos();

            if (tecnicos.Any(t => t.Nome == Nome))
            {
                Console.WriteLine("Nome já resgistrado");
                return;
            }

            var contaTecnico = new Conta_Tecnico(
                Nome,
                senha,
                Idade,
                Saldo,
                Interesses,
                Amistosos
            );

            PersistenciaDeTecnico.SalvarTecnico(contaTecnico);
            TornouSeTecnico = true;
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
            string tiposConta = "";
            if (TornouSeJogador) tiposConta += "Jogador";
            if (TornouSeTecnico) tiposConta += (tiposConta != "" ? " e " : "") + "Tecnico";
            if (tiposConta == "") tiposConta = "Nenhu tipo definido";

            Console.WriteLine($"""
            === Perfil De {Nome} ===
            ID: {Id}
            Tipo: {tiposConta}
            Idade: {Idade}
            Saldo: {Saldo:F2}
            Data de criação: {DataCriacao:dd/MM/yyyy}
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

