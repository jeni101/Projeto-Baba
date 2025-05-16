using Controle_de_execoesApp;
using Util_Campos;
using ContaJogadorApp;

public class DisplayViewCamposSeguro
{
    private Utils_De_Campos utils;

    public DisplayViewCamposSeguro(Conta_Jogador conta)
    {
        utils = new Utils_De_Campos(conta);
    }

    public void Display_Campos()
    {
        var controle = new ControleDeExecoes();
        ControleDeExecoes.ExecutarComTratamento(() =>
        {
            utils.DisplayMenu();
        });
    }
}
