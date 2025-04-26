using System;
using ContaUsuarioApp;

// rever atibutos como eventos ou jogos, pois falta informacao por si so, como: local, horario, dia etc. a menos q trasforme em uma lista
namespace ContaTecnicoApp
{
    public class ContaTecnico : ContaUsuario
    {
        public string Time {get; set;}
        public string Eventos {get; set;}
        public string Jogos {get; set;}
        //partidas vai continuar como string? 
        public string Partidas {get; set;}

    
        public ContaTecnico(string nome, string senha, int idade, float? saldo = null, string? interesses = null, string? amistosos = null, string? time = null, string? eventos = null, string? jogos = null, string? partidas = null)
            : base (nome, senha, idade, saldo ?? 0, interesses ?? string.Empty, amistosos ?? string.Empty)
            {
                Time = time ?? string.Empty;
                Eventos = eventos ?? string.Empty;
                Jogos = jogos ?? string.Empty;
                Partidas = partidas ?? string.Empty;
            }
        
        // eventos
        public void CriarEventos(){}
        public void ExibirEventos(){}
        public void EditarEventos(){}
        public void DeletarEventos(){}

        public void EntrarJogo(){}
        public void SairJoga(){}

        //time
        public void CriarTime(){}
        public void ExibirTime(){}
        public void EditarTime(){}
        public void DeletarTime(){}
        public void AdicionarJogadorDoTime(){}
        public void RemoverJogadorDoTime(){}

        //partidas
        public void  EntrarEmPartidas(){}
        public void ExibirPartidas(){}
        public void SairPartidas(){}


    }
}