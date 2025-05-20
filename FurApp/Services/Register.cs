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
            Console.WriteLine("Nome :");
            string nome = Console.ReadLine()?.Trim() ?? "";

            Console.WriteLine("Idade: ");
            if (!int.TryParse(Console.ReadLine(), out int idade) || idade <= 0)
            {
                Console.WriteLine("Idade inválida");
                return;
            }

            int escolha;
            do
            {
                Console.WriteLine("Escolha o tipo de conta:"); //LUIS VERIFICA O OUTPUT
                Console.WriteLine("1 - Jogador");
                Console.WriteLine("2 - Técnico");
                Console.WriteLine("3 - Ambos");
                Console.Write("Opção: ");
            }
            while (!int.TryParse(Console.ReadLine(), out escolha) || escolha < 1 || escolha > 3);

            string senha;
            try
            {
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
                Console.WriteLine("Registro concluido");
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
            Console.WriteLine("Conta jogador criada  com sucesso");
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
            Console.WriteLine("Conta tecnico criada com sucesso");
        }
    }
}

