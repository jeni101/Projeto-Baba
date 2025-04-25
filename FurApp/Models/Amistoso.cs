using System;
using PlacarApp;

namespace AmistosoApp
{
    public class Amistoso
    {
        //esta lista poderia estar linkada diretamente com os jogadores cadastrados, 
        // dependendo do quanto de jogadores tiver da p fazer um random p completar time.
        // mas e se o cara q entrar no time n quiser jg ou n tiver disponivel? criar uma verificacao?
        public List<string> Participantes {get; set;}
        public Placar Placar { get; set; }

        public Amistoso(List<string> participantes, Placar placar)
        {
            Participantes = participantes;
            Placar = placar;
        }

        public void ExibirAmistoso(){}
        public void EditarAmistoso(){}
        public void ConvidarParticipante(){}
    }
}