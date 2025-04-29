using System;

namespace PlacarApp
{
    public class Placar
    {
        public string TimeA { get; set; }
        public int GolsA { get; set; }
        public string TimeB { get; set; }
        public int GolsB { get; set; }

        //Construtor
        public Placar(string timeA, int golsA, string timeB, int golsB)
        {
            if (string.IsNullOrWhiteSpace(timeA) || string.IsNullOrWhiteSpace(timeB))
            {
                throw new ArgumentException("Times inválidos");
            }
            if (golsA < 0 || golsB < 0)
            {
            throw new ArgumentException("Gols não podem ser negativos");
            }

            TimeA = timeA;
            TimeB = timeB;
            GolsA = golsA;
            GolsB = golsB;
        }

        //Adicionar Gols
        public void AdicionarGolA()
        {
            GolsA++;
        }
        public void AdicionarGolsB()
        {
            GolsB++;
        }

        //resetar placar
        public void ResetarPlacar()
        {
            GolsA = 0;
            GolsB = 0;
        }
    
        //placar - vitória
        public override string ToString()
        {
           return $"{TimeA} {GolsA} x {GolsB} {TimeB}";
        }

        public string Resultado()
        {
            if (GolsA > GolsB)
            {
                return $"Vitória {TimeA}";
            }
            else if (GolsB > GolsA)
            {
                return $"Vitória {TimeB}";
            }
            else 
            {
                return "Empate";
            }
        } 
    }   
}