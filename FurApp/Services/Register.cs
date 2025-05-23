using System;
using System.Linq;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Tecnico;
using Models.ContaApp.Usuario.Jogador;
using Repository.PersistenciaApp;
using System.Reflection.Metadata;
using Services.Senha;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Views.OpcoesMascara;

namespace Services.Register
{
    public class Registro
    {
        //Instanciador
        public static Registro Instancia { get; } = new Registro();

        //Atributos
        private readonly RepositoryJogador _repoJogador = new RepositoryJogador();
        private readonly RepositoryTecnico _repoTecnico = new RepositoryTecnico();

        //Registro geral
        public async Task RegistrarAsync()
        {
            Console.Clear();
            View_Inicial.Display_Mascara01();
            Console.WriteLine(" .____________________________________."); //View de Registro Inicial
            Console.WriteLine(" |  -=-     Criação de Conta     -=-  |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine(" |- Nome:                             |");
            Console.WriteLine(" |____________________________________|");
            Console.WriteLine(" |- Idade:                            |");
            Console.WriteLine(" |                                    |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine(" • Insira seu Nome :");
            string nome = Console.ReadLine()?.Trim() ?? "";

            Console.Clear();
            View_Inicial.Display_Mascara01();
            Console.WriteLine(" .____________________________________."); //View de Registro Inicial com Nome Apenas
            Console.WriteLine(" |  -=-     Criação de Conta     -=-  |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine($" |- Nome: {nome.PadRight(27)} |");
            Console.WriteLine(" |____________________________________|");
            Console.WriteLine(" |- Idade:                            |");
            Console.WriteLine(" |                                    |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine(" • Insira sua Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade) || idade <= 0)
            {
                Console.WriteLine(" ! Idade inválida, tente novamente !");
                return;
            }
            
            int escolha;
            do
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine(" .____________________________________."); //View de Registro Inicial com Nome e Idade
                Console.WriteLine(" |  -=-     Criação de Conta     -=-  |");
                Console.WriteLine(" |====================================|");
                Console.WriteLine($" |- Nome: {nome.PadRight(27)} |");
                Console.WriteLine(" |____________________________________|");
                Console.WriteLine($" |- Idade: {idade,-26} |");
                Console.WriteLine(" |                                    |");
                Console.WriteLine(" |====================================|");

                Console.WriteLine(" • Escolha o tipo de conta:");
                Console.WriteLine(" .______________________________."); //View de Opções
                Console.WriteLine(" |  -=-  Selecione Abaixo  -=-  |");
                Console.WriteLine(" |==============================|");
                Console.WriteLine(" |- Jogador . . . . . . . |  1  |");
                Console.WriteLine(" |- Técnico . . . . . . . |  2  |");
                Console.WriteLine(" |- Ambos . . . . . . . . |  3  |");
                Console.WriteLine(" |________________________|_____|");
                Console.WriteLine(" | - VOLTAR . . . . . . . |  0  |");
                Console.WriteLine(" |==============================|");
                Console.WriteLine(" • Digite a Opção Desejada: ");
            }
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 3);
            string opcao = " ";
            switch (escolha) //Pequeno switch que define oque é cada coisa
            {
                case 1:
                    opcao = "Jogador";
                    break;
                case 2:
                    opcao = "Técnico";
                    break;
                case 3:
                    opcao = "Ambos";
                    break;        
            }
            string senha;
            try
            {
                Console.Clear();
                View_Inicial.Display_Mascara01();
                Console.WriteLine(" • Agora Vamos Definir uma senha!");
                Console.WriteLine(" .____________________________________.   .__________."); //view Com Tudo menos a Senha
                Console.WriteLine(" |  -=-     Criação de Conta     -=-  |   |=- Tipo -=|");
                Console.WriteLine(" |====================================|   |==========|");
                Console.WriteLine($" |- Nome: {nome.PadRight(27)} |   |- {opcao,-7} |");
                Console.WriteLine(" |____________________________________|   |__________|");
                Console.WriteLine($" |- Idade: {idade,-26} |");
                Console.WriteLine(" |                                    |");
                Console.WriteLine(" |====================================|");

                senha = ObtencaoSenha.DefinirSenha();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            try
            {
                switch (escolha)
                {
                    case 1:
                        await RegistrarJogadorAsync(nome, senha, idade);
                        break;

                    case 2:
                        await RegistrarTecnicoAsync(nome, senha, idade);
                        break;

                    case 3:
                        await RegistrarJogadorAsync(nome, senha, idade);
                        await RegistrarTecnicoAsync(nome, senha, idade);
                        break;
                }
                Console.WriteLine(" • Registro Concluído Com Sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Registrar Jogador
        private async Task RegistrarJogadorAsync(string nome, string senha, int idade)
        {
            var jogador = new Conta_Jogador(
                nome,
                senha,
                idade,
                "Não definida"
            );

            await _repoJogador.SalvarJogador(jogador);
            Console.WriteLine(" • Conta jogador criada  com sucesso");
        }

        //Registrar Tecnico
        private async Task RegistrarTecnicoAsync(string nome, string senha, int idade)
        {
            var tecnico = new Conta_Tecnico(
                nome,
                senha,
                idade,
                "Sem time"
            );

            await _repoTecnico.SalvarTecnico(tecnico);
            Console.WriteLine(" • Conta tecnico criada com sucesso");
        }
    }
}

