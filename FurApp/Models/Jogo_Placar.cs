namespace Models.JogosApp.PlacarJogo
{
    public class Placar
    {
        public int GolsA { get; private set; }
        public int GolsB { get; private set; }

        //Construtor
        public Placar(int golsA = 0, int golsB = 0)
        {
            GolsA = golsA;
            GolsB = golsB; 
        }

        //Adicionar Gols para time A
        public void AdicionarGolsA()
        {
            GolsA++;
        }
        public void AtualizarGolA(int gols)
        {
            if (gols >= 0)
            {
                GolsA = gols;
            }
        }

        //Adicionar Gols para time B
        public void AdicionarGolsB()
        {
            GolsB++;
        }
        public void AtualizarGolsB(int gols)
        {
            if (gols >= 0)
            {
                GolsB = gols;
            }
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
           return $"{GolsA} x {GolsB}";
        } 
    }   
}