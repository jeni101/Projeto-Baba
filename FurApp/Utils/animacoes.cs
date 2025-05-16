using System;
using System.Threading;

namespace AnimacaoApp
{
    public class SaindoAnimado
    {
        public static void ExibirMensagemSaida()
        {
            Console.Write("Saindo ");
            

            for (int i = 0; i < 7; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000); // Pausa de 1 segundo
            }
            Console.Clear();
            Console.WriteLine("\nObrigado por usar o FurApp!\n");
        }
    }

    public class SairAnimado
    {
        public static void ExibirMensagemSaida2() // saindo mais eleborado
        {
            foreach (char letra in "Saindo") 
            {
                Console.Write(letra);
                System.Threading.Thread.Sleep(100); // Pausa de 0.1 segundo
            }
            
            

            for (int i = 0; i < 7; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000); // Pausa de 1 segundo
            }
            Console.Clear();
            Console.WriteLine("\nObrigado por usar o FurApp!\n");
        }
    }

     public class VoltandoAnimado
    {
        public static void ExibirMensagemVoltando()
        {
            Console.Write("Voltando ");
            

            for (int i = 0; i < 10; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(100); // Pausa de 1 segundo
            }
            Console.Clear();
            
        }
    }

    public class SairContaAnimado
    {
        public static void ExibirMensagemSairConta()
        {
            Console.Write("Saindo da Conta");
            

            for (int i = 0; i < 7; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000); // Pausa de 1 segundo
            }
            Console.Clear();
            
        }
    }



public class SairAnimados
{
    public static void ExibirMensagemSaida2() // saída mais elaborada
    {
        string borda = "|-------------------------------|";
        string mensagemBase = "Saindo ";

        // Mostra o retângulo antes de começar
        Console.WriteLine(borda);
        Console.Write("| "); // Começa a linha do meio
        Console.Write(new string(' ', 29)); // Espaço onde a animação vai rolar
        Console.WriteLine(" |");
        Console.WriteLine(borda);

        // Volta o cursor para a posição onde a animação vai acontecer
        Console.SetCursorPosition(2, Console.CursorTop - 2); // Linha do meio, após "| "

        // Anima "Saindo"
        foreach (char letra in mensagemBase)
        {
            Console.Write(letra);
            Thread.Sleep(100);
        }

        // Anima os pontinhos após "Saindo"
        for (int i = 0; i < 29 - mensagemBase.Length; i++)
        {
            Console.Write(".");
            Thread.Sleep(100);
        }

        // Espera o usuário pressionar Enter
        Console.SetCursorPosition(0, Console.CursorTop + 2); // Vai pra baixo do retângulo
        Console.WriteLine("\nObrigado por usar o FurApp!\n");
    }
}



    

    

}