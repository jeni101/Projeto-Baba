/*
using Models.ContaApp.Usuario.Jogador;
using Utils.Controle_de_execoesApp;
using Utils.Confirmacao_de_saida;

namespace Views_Campos
{
    public class Views_De_Campos
    {
        private Conta_Jogador contaLogada;
        private int contador_de_erros = 0;

        public Views_De_Campos(Conta_Jogador conta)
        {
            contaLogada = conta;
            

        }

        public void DisplayMenu()
        {
            int[] validos = { 1, 2, 3, 4, 5 };
            bool sair = false;

            while (!sair)
            {
                Console.Clear();

                Console.WriteLine($"Vamos lá, {contaLogada.Nome}!\n");
                Console.WriteLine(".______________________________________."); //Verificar Oque Vai Fazer com isso....
                Console.WriteLine("|  -=- Selecione o Tipo da Quadra -=-  |");
                Console.WriteLine("|======================================|");
                Console.WriteLine("|Campo Oficial . . . . . . . . . |  1  |");
                Console.WriteLine("|Campo Sintético . . . . . . . . |  2  |");
                Console.WriteLine("|Quadra de Futsal. . . . . . . . |  3  |");
                Console.WriteLine("|Quadra de Areia . . . . . . . . |  4  |");
                Console.WriteLine("|Quadra Improvisada. . . . . . . |  5  |");
                Console.WriteLine("|________________________________|_____|");
                Console.WriteLine("|VOLTAR. . . . . . . . . . . . . |  0  |");
                Console.WriteLine("|======================================|");
                Console.Write(" \nEscolha: ");
                string? escolha = Console.ReadLine();

                string tipo_quadra = "";
                int quantidade_jogadores = 0;

                var HouveErro = ControleDeExecoes.ExecutarComTratamento(async () =>
                {
                    await Task.Delay(0);
                    
                    int opcao = int.Parse(escolha ?? "");

                    switch (opcao)
                    {
                        case 1:
                            tipo_quadra = "Campo Oficial";
                            quantidade_jogadores = 22;
                            break;

                        case 2:
                            tipo_quadra = "Campo Sintético";
                            quantidade_jogadores = 14;
                            break;

                        case 3:
                            tipo_quadra = "Futsal";
                            quantidade_jogadores = 10;
                            break;

                        case 4:
                            tipo_quadra = "Futebol de Areia";
                            quantidade_jogadores = 10;
                            break;

                        case 5:
                            tipo_quadra = "Improvisado";
                            quantidade_jogadores = 6;
                            break;

                        case 0:
                            Confirmacao.ExibirMensagemSaida(ref opcao);
                            sair = true;  // Sai do loop
                            break;

                        default:
                            throw new ArgumentOutOfRangeException(); // Força exceção se inválido
                    }

                }, escolha ?? "", contador_de_erros);
            }
        }
    }
}
*/