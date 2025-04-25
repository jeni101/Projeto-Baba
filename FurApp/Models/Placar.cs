using System;

namespace PlacarApp
{
    public class Placar
    {
        public string TimeA { get; set; }
        public int GolsA { get; set; }
        public string TimeB { get; set; }
        public int GolsB { get; set; }

        public Placar(string timeA, int golsA, string timeB, int golsB)
        {
            TimeA = timeA;
            TimeB = timeB;
            GolsA = golsA;
            GolsB = golsB;
        }
    
        public override string ToString()
        {
           return $"{TimeA} {GolsA} x {GolsB} {TimeB}";
        }
    }   
}