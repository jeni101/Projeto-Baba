using System;

namespace Controle_de_execoesApp
{
    public class ControleDeExecoes
    {
        public static void ExecutarComTratamento(Action acao)
        {
            try
            {
                acao();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}