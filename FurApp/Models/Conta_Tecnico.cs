using Interfaces.ITecnico;
using Models.ContaApp.Usuario;
using TimesApp;

namespace Models.ContaApp.Usuario.Tecnico
{
    public class Conta_Tecnico : Conta_Usuario, ITecnico
    {
        //sobre o tecnico
        public string Time {get; set;}
        public List<string> Eventos {get; set;}
        public List<string> Jogos {get; set;}
        public List<string> Partidas {get; set;}

        //Construtor
        public Conta_Tecnico(string nome, 
                            string senha, 
                            int idade,
                            string time)
                            : base (nome, senha, idade)
            {
                Time = time ?? string.Empty;
                Eventos = new List<string>();  
                Jogos = new List<string>();    
                Partidas = new List<string>();
            }

        //time
        void ITecnico.CriarTime()
        {
            Console.WriteLine("Nome do Time: ");  //LUIS VERIFICA O OUTPUT
            string? nomeTime = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeTime))
            {
                Console.WriteLine("Nome vazio"); //LUIS VERIFICA O OUTPUT
                return;
            }

            Times.CriarTime(nomeTime, this);
            Time = nomeTime;
        }

        //jogos
        void ITecnico.CriarJogo()
        {
            throw new NotImplementedException();
        }
        void ITecnico.EntrarJogo()
        {
            throw new NotImplementedException();
        }

        //treino
        void ITecnico.CriarTreino()
        {
            throw new NotImplementedException();
        }

        //perfil
        public void ExibirPerfil()
        {
            Console.WriteLine($"""
            === PERFIL DO TÉCNICO ===
            ID: {Id}
            Nome: {Nome}
            Idade: {Idade}
            Saldo: R$ {Saldo:F2}
            Interesses: {Interesses}
            Amistosos: {Amistosos}
            Time: {Time}
            """); //LUIS VERIFICA O OUTPUT
        }
    }
}