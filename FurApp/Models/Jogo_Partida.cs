using Models.JogosApp;
using Models.JogosApp.PlacarJogo;
using Models.TimesApp;

namespace Models.JogosApp.Partidas
{

    public class Partida
    {
        public Placar Placar { get; set; }
        public List<Time> Times { get; set; }

        public Partida()
        {

        }
    }
}
