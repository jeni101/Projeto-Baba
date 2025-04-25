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

    
        public ContaTecnico(string nome, string senha, int idade, float saldo, string interesses, string amistosos, string time, string eventos, string jogos, string partidas)
            : base (nome, senha, idade, saldo, interesses, amistosos)
            {
                Time = time;
                Eventos = eventos;
                Jogos = jogos;
                Partidas = partidas;
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