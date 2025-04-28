using System;
using ContaUsuarioApp;
using TimesApp;


namespace ContaTecnicoApp
{
    public class ContaTecnico : ContaUsuario, ITecnico
    {
        //sobre o tecnico
        public string Time {get; set;}
        public List<string> Eventos {get; set;}
        public List<string> Jogos {get; set;}
        public List<string> Partidas {get; set;}

    
        //Construtor
        public ContaTecnico(string nome, 
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
        void ITecnico.criarTime()
        {
            Console.WriteLine("Nome do Time: ");
            string? nomeTime = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeTime))
            {
                Console.WriteLine("Nome vazio");
                return;
            }

            Times.CriarTime(nomeTime, this);
            Time = nomeTime;
        }

        //jogos
        void ITecnico.criarJogo()
        {
            throw new NotImplementedException();
        }
        void ITecnico.entrarJogo()
        {
            throw new NotImplementedException();
        }

        //treino
        void ITecnico.criarTreino()
        {
            throw new NotImplementedException();
        }


    }
}