using Controle_de_execoesApp;
using Conta_Jogador = Models.ContaApp.Usuario.Jogador.Conta_Jogador;
using Views.Campos;

public class DisplayViewCamposSeguro
{
    private Views_De_Campos utils;

    public DisplayViewCamposSeguro(Conta_Jogador conta)
    {
        utils = new Views_De_Campos(conta);
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
