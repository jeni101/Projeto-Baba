using Interfaces.IJogador;
using Interfaces.ITecnico;
using Models.ContaApp;
using Repository.PersistenciaApp;

namespace Models.ContaApp.Usuario
{
    public class Conta_Usuario : Conta
    {
        //Atributos
        public float Saldo { get; private set; }
        public List<string> Interesses { get; set; }
        public List<string> Amistosos { get; set; }
        public bool TornouSeJogador { get; private set; }
        public bool TornouSeTecnico { get; private set;}
        public DateTime DataCriacao { get; private set; }

        //Construtor
        public Conta_Usuario(string nome, 
                            string senha, 
                            int idade, 
                            bool querSerJogador = true,
                            bool querSerTecnico = false) 
                    : base (nome, senha, idade)
        {
            Saldo = 10f;
            Interesses = new List<string>();
            Amistosos = new List<string>();
            TornouSeJogador = querSerJogador;
            TornouSeTecnico = querSerTecnico;
            DataCriacao = DateTime.Now;
        }

        //Senha
        private string Definir_Senha(int maxTentativas = 3)
        {
            for (int i = 0; i < maxTentativas; i++)
            {
                Console.WriteLine("Defina sua senha (min. 6 char.): "); //LUIS VERIFICA O OUTPUT
                string senha = Console.ReadLine() ?? "";

                if (senha.Length < 6)
                {
                    Console.WriteLine("Senha muito curta"); //LUIS VERIFICA O OUTPUT
                    continue;
                }

                Console.WriteLine("Confirme sua senha: "); //LUIS VERIFICA O OUTPUT
                string confirmacaoSenha = Console.ReadLine() ?? "";

                if (senha == confirmacaoSenha)
                {
                    return senha;
                }

                Console.WriteLine("Senhas não coicidem"); //LUIS VERIFICA O OUTPUT
            }
            throw new InvalidOperationException("Número máximo de tentativas atingido"); //LUIS VERIFICA O OUTPUT
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
                Console.WriteLine("Saldo insuficiente para essa aposta"); //LUIS VERIFICA O OUTPUT
                return;
            }
            Saldo -= valor;
            Console.WriteLine($"Aposta de R$ {valor:F2} realizada com sucesso"); //LUIS VERIFICA O OUTPUT
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
            """); //LUIS VERIFICA O OUTPUT
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

