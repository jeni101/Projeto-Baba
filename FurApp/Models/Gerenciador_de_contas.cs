/*
using System;
using ContaApp;
using ContaJogadorApp;
using ContaTecnicoApp;
using ContaArbitroApp;
using ContaUsuarioApp;



namespace GerenciadorApp
{
    public class GerenciadorDeConta
    {
        private List<Conta> contas = new List<Conta>();

        public void CadastrarConta()
        {
            Console.WriteLine("Bem vindo ao FuraoApp! \n Insira as seguintes informacoes para concluir o cadastro: \n");

            Console.Write("Nome: ");
            string? nome = Console.ReadLine();

            Console.Write("\nIdade: ");
            int idade = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nSenha: ");
            string? senha = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Agora defina o tipo da sua conta: ");
            Console.WriteLine("1- Conta de Jogador.");
            Console.WriteLine("2- Conta de Tecnico.");
            Console.WriteLine("3- Conta de Arbitro.");

            int tipoDeConta = Convert.ToInt32(Console.ReadLine());

            Conta? novaConta = null;

            if (tipoDeConta ==1 )
            {
                Console.Clear();
                Console.WriteLine("Voce selecionou a conta de 'Jogador' por favor informe sua possicao: \n");
                Console.WriteLine("1- Goleiro.");
                Console.WriteLine("2- Defesa.");
                Console.WriteLine("3- Ataque.");

                int posicao = Convert.ToInt32(Console.ReadLine());

                if (posicao == 1) // talvez colocar uma confirmacao final com todos os dados antes de salvar.
                {
                    string posicao1 = "Goleiro";
                    novaConta = new ContaJogador(nome ?? "", senha ?? "", idade, posicao1);
                }

                else if (posicao == 2)
                {
                    string posicao2 = "Defesa";
                    novaConta = new ContaJogador(nome ?? "", senha ?? "", idade, posicao2);
                }

                else if (posicao == 3)
                {
                    string posicao3 = "Ataque";
                    novaConta = new ContaJogador(nome ?? "", senha ?? "", idade, posicao3);
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("opcao invalida");
                }
            

            }
                

                
            else if (tipoDeConta == 2 )
            {
                novaConta = CriarContaTecnico(nome ?? "", idade, senha ?? "");
                
            }

            else if (tipoDeConta == 3 )
            {
                novaConta = CriarContaArbitro(nome ?? "", idade, senha ?? "");
            }


            if (novaConta != null)
            {
                contas.Add(novaConta);
                PersistenciaDeContas.SalvarContas(contas); // salva no json 
                Console.WriteLine("Conta criada com sucesso!");
            }
        }
        public ContaTecnico CriarContaTecnico(string nome, int idade, string senha)
        {
            Console.Clear();
            Console.WriteLine("Voce selecionou a conta 'Tecnico'.");
            return new ContaTecnico(nome, senha, idade);
        }



        public ContaArbitro CriarContaArbitro(string nome, int idade, string senha)
        {
            Console.Clear();
            Console.WriteLine("Voce selecionou a conta 'Arbitro'.");
            return new ContaArbitro(nome, senha, idade);
        }



    }

}
*/