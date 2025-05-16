/*
using System;
using ContaJogadorApp;
using TimesApp;
using ContaJogadorApp;


namespace MenuPerfilApp
{
    public class MenuPerfilJogador
    {
        private Conta_Jogador contaLogada;

        public MenuPerfilJogador(Conta_Jogador conta)
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
                            
                            // opcoes: criar time ou entrar em um time

                            // criar time: vc pode adicionar seus amigos ate bater a quantidade maxima
                            //porem vai ter uma verivicacao na conta da pessoa chamada perguntando 
                            // se ela aceita ou n participar - parte de mensagens (txt simples com 200 caracteres p mensagem de convite)
                            // caso n bata a quantidade maxima vc pode ver a lista de jogadores disponiveis e invita los
                            // criar uma variavel de disponibilidade q se torna indisponivel a partir do momento q  vc entra em um time?
                            Console.WriteLine("====== MENU Times =========");
                            Console.WriteLine("|Criar Time..............|1|");
                            Console.WriteLine("|ENTRAR EM TIME..........|2|");
                            Console.WriteLine("|SAIR....................|3|");
                            Console.WriteLine("===========================");
                            string? escolha_time = Console.ReadLine();
                            switch (escolha_time)
                            {
                                case "1":

                                    // Times times = new Times();
                                    // times.ListarTimes(contaLogada.Nome);


                                break;

                                case "2":
                                // jogador pode receber uma mensagem de convite na sua conta

                                break;

                                case "3":
                                // estatisticas suas - gols assistencias etc
                                // estatisticas do time/geral - rank/ pontuacao geral

                                return;


                            }

                            
                            


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
*/