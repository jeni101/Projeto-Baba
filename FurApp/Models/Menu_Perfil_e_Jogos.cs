using System;
using ContaJogadorApp;
using TimesApp;

namespace MenuPerfilApp
{
    public class MenuPerfilJogador
    {
        private ContaJogador contaLogada;

        public MenuPerfilJogador(ContaJogador conta)
        {
            contaLogada = conta;
        }
        public void DisplayMenu()
        {

            Console.WriteLine("====== MENU ======");
            Console.WriteLine("|PERFIL.........|1|");
            Console.WriteLine("|JOGOS..........|2|");
            Console.WriteLine("|SAIR...........|3|");
            Console.WriteLine("===================");
            string? escolha = Console.ReadLine();
            
            switch (escolha)
            {
                case "1":
                
                    Console.WriteLine($"Bem-vindo ao seu perfil, {contaLogada.Nome}!\n");
                    Console.WriteLine("====== MENU PERFIL ======");
                    Console.WriteLine("|TIMES................|1|");
                    Console.WriteLine("|MENSAGENS............|2|");
                    Console.WriteLine("|ESTATISTICAS.........|3|");
                    Console.WriteLine("|VOLTAR...............|4|");
                    Console.WriteLine("=========================");

                    string? subEscolha1 = Console.ReadLine();

                    switch (subEscolha1)
                    {
                        case "1":
                            // chamar funcao p times
                            Times times = new Times();
                            times.ListarTimes(contaLogada.Nome);

                            break;
                        
                        case "2":
                            // chamar funcao p mensagens
                            break;
                        
                        case "3":
                            // estatistica
                            break;

                        case "4":

                            Console.WriteLine("Voltando ao menu principal...");
                            DisplayMenu();
                            return;
                    }

                    break;

                case "2":

                    Console.WriteLine($"Bem-vindo ao seu perfil, {contaLogada.Nome}!\n");
                    Console.WriteLine("====== MENU JOGOS ======");
                    Console.WriteLine("|PARTIDAS.............|1|");
                    Console.WriteLine("|JOGOS................|2|");
                    Console.WriteLine("|VOLTAR...............|3|");
                    Console.WriteLine("=========================");
                    

                    string? subEscolha2 = Console.ReadLine();

                    switch (subEscolha2)
                    {
                        case "1":

                            // chamar funcao p partidas
                            break;


                        case "2":
                            // chamar funcao jogos
                            break;

                        case "3":

                            Console.WriteLine("Voltando ao menu principal...");
                            return;
                    }
                    break;


                case "3":
                    Console.WriteLine("Saindo .............");
                    return;
                
                    

            }
        
        }
    }
}