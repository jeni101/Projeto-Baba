namespace Models.JogosApp.PlacarJogo
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

        public void pontuacao(int golsA, int golsB)
        {
            // como fariamos partidas equilibradas  - puntucao de serie A, B e C 
            //randon entre dimes da mesma patente 

            int pontos_golsA = golsA * 5;
            int pontos_golsB = golsB * 5;
            if (golsA> golsB)
            {
                // se cada gol vc ganha 5 pontos o time perdedor sera descontado esses pontos ao perder
                //obs ele perdera menos pontos se tiver feito gols
                int pontuacao_atualizada_golsB = golsB - golsA;
            }
            
            else if (golsB > golsA) 
            {

                int pontuacao_atualizada_golsA = golsA - golsB;
            }
            
            // else 
            // {
            //     int pontuacao_atualizada_golsA = 0;
            //     int pontuacao_atualizada_golsB = 0;
            // }
        } 
    }   
}

// 50 = c
// 50 -100 = b
// 100+ = a

// posso criar um database txt simples p junto com o da mensagem q tenha um campo para pontuacao geral/rank 