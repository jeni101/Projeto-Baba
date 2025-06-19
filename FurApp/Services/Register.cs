using System;
using System.Linq;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Tecnico;
using Models.ContaApp.Usuario.Jogador;
using System.Reflection.Metadata; 
using Services.Senha;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Views.OpcoesMascara;
using Repository.PersistenciaApp.ADM;
using System.Threading.Tasks; 

namespace Services.Register
{
    public class Registro
    {
        // Atributos
        private readonly RepositoryJogador _repoJogador;
        private readonly RepositoryTecnico _repoTecnico;
        private readonly RepositoryADM _repoADM;

        // Construtor: Remova 'string connStr'
        public Registro(RepositoryJogador repoJogador, RepositoryTecnico repoTecnico, RepositoryADM repoADM)
        {
            _repoJogador = repoJogador ?? throw new ArgumentNullException(nameof(repoJogador));
            _repoTecnico = repoTecnico ?? throw new ArgumentNullException(nameof(repoTecnico));
            _repoADM = repoADM ?? throw new ArgumentNullException(nameof(repoADM));
        }

        // Registro geral
        public async Task RegistrarAsync()
        {
            Console.Clear();
            View_Inicial.Display_Mascara01();
            Console.WriteLine(" .____________________________________.");
            Console.WriteLine(" |  -=-     Criação de Conta     -=-  |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine(" |- Nome:                              |");
            Console.WriteLine(" |____________________________________|");
            Console.WriteLine(" |- Idade:                             |");
            Console.WriteLine(" |                                      |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine(" • Insira seu Nome :");
            string nome = Console.ReadLine()?.Trim() ?? "";

            Console.Clear();
            View_Inicial.Display_Mascara01();
            Console.WriteLine(" .____________________________________.");
            Console.WriteLine(" |  -=-     Criação de Conta     -=-  |");
            Console.WriteLine(" |====================================|");
            Console.WriteLine($" |- Nome: {nome.PadRight(27)} |");
            Console.WriteLine(" |____________________________________|");
            Console.WriteLine(" |- Idade:                             |");
            Console.WriteLine(" |                                      |");
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
                Console.WriteLine(" .____________________________________.");
                Console.WriteLine(" |  -=-     Criação de Conta     -=-  |");
                Console.WriteLine(" |====================================|");
                Console.WriteLine($" |- Nome: {nome.PadRight(27)} |");
                Console.WriteLine(" |____________________________________|");
                Console.WriteLine($" |- Idade: {idade,-26} |");
                Console.WriteLine(" |                                      |");
                Console.WriteLine(" |====================================|");

                Console.WriteLine(" • Escolha o tipo de conta:");
                Console.WriteLine(" .______________________________.");
                Console.WriteLine(" |  -=-   Selecione Abaixo   -=-  |");
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
            string senha;
            try
            {
                Console.Clear();
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

        // Registrar Jogador
        private async Task RegistrarJogadorAsync(string nome, string senha, int idade)
        {
            var jogador = new Conta_Jogador(
                nome,
                senha,
                idade,
                "Não definida" // Posição padrão
            );

            await _repoJogador.SalvarAsync(jogador);
            Console.WriteLine(" • Conta jogador criada com sucesso");
        }

        // Registrar Tecnico
        private async Task RegistrarTecnicoAsync(string nome, string senha, int idade)
        {
            var tecnico = new Conta_Tecnico(
                nome,
                senha,
                idade
            );

            await _repoTecnico.SalvarAsync(tecnico);
            Console.WriteLine(" • Conta tecnico criada com sucesso");
        }
    }
}