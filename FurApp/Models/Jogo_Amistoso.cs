using PlacarApp;

namespace AmistosoApp
{
    public class Jogo_Amistoso
    {
        //esta lista poderia estar linkada diretamente com os jogadores cadastrados, 
        // dependendo do quanto de jogadores tiver da p fazer um random p completar time.
        // mas e se o cara q entrar no time n quiser jg ou n tiver disponivel? criar uma verificacao?
        public List<string> Participantes {get; set;}
        public DateTime Data { get; set; } // estrutura q representa data e hora expecifica p amistoso
        public string Local { get; set; }
        public Placar Placar { get; set; }

        public Jogo_Amistoso(List<string> participantes, DateTime data , string local, Placar placar)
        {
            Participantes = participantes;
            Data = data;
            Local = local;
            Placar = placar;
        }

        public void Exibir_Jogo_Amistoso(){}
        public void Editar_Jogo_Amistoso(){}
        public void Convidar_Participante(){}
    }
}