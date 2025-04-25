public class Jogo
{
    //Atributos
    protected DateTime Data { get; set;}
    protected string Local { get; set; }
    protected string TipoDeCampo { get; set;}
    protected List<string> Interessados { get; set; }
    protected int QuantidadeDeJogadores { get; set;}
    protected string Times { get; set; }


    //Funções
    protected void alterarData() 
    {
        string entrada = Console.ReadLine();

        if (DateTime.TryParseExact(entrada, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime novaData))
        {
            Data = novaData;
        }
        else 
        {

        }
    }
    protected void alterarLocal()
    {
        string novoLocal = Console.ReadLine();
        Local = novoLocal;
    }
    protected void alterarTipoDeCampo()
    {
        string novoTipoDeCampo = Console.ReadLine();
        TipoDeCampo = novoTipoDeCampo;
    }
    protected void alterarQuantidadeDeJogadores()
    {
        int novaQuantidadeDeJogadores = Int32.Parse(Console.ReadLine());
        QuantidadeDeJogadores = novaQuantidadeDeJogadores;
    }
    protected void adicionarTimes()
    {

    }
    //Construtores
    public void ExibirData() 
    {

    }
}