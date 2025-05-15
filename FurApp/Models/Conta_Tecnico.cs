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
                            float? saldo = null, 
                            string? interesses = null, 
                            string? amistosos = null, 
                            string? time = null, 
                            List<string>? eventos = null, 
                            List<string>? jogos = null, 
                            List<string>? partidas = null)
                            : base (nome, senha, idade, saldo ?? 0, interesses ?? string.Empty, amistosos ?? string.Empty)
            {
                Time = time ?? string.Empty;
                Eventos = eventos ?? new List<string>();
                Jogos = jogos ?? new List<string>();
                Partidas = partidas ?? new List<string>();
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