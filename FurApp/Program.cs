using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using Services.Autenticacao;
using Services.Register;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Repository.PersistenciaApp.ADM;
using Repository.Database.Initializer.ADM;
using Repository.Database.Initializer.Campos;
using Repository.Database.Initializer.Posicoes;
using Utils.Pelase.Leitor.Jogador;
using Utils.Pelase.Leitor.Tecnico;
using Repository.PersistenciaApp.Times;
using Utils.Pelase.Leitor.Times;
using Views.Contas;
using Views.OpcoesContas;
using Views.OpcoesUsuarios;
using Views.OpcoesAdministrador;
using Repository.Database.ADM;
using Repository.Database.Campos;
using Repository.Database.Gerenciamento;
using Repository.Database.Jogadores;
using Repository.Database.Jogos;
using Repository.Database.Partidas;
using Repository.Database.Posicoes;
using Repository.Database.Tecnicos;
using Repository.Database.Times;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        string mariaDbConnStr = configuration.GetConnectionString("MariaDB");

        try
        {
            using (var connection = new MySqlConnection(mariaDbConnStr))
            {
                await connection.OpenAsync();
                Console.WriteLine("Conexão com o banco de dados estabelecida.");

                var dbADM = new DatabaseADM(); 
                await dbADM.GarantirExistenciaTabelaAsync(connection);

                var dbTecnicos = new DatabaseTecnicos();
                await dbTecnicos.GarantirExistenciaTabelaAsync(connection);

                var dbTimes = new DatabaseTimes();
                await dbTimes.GarantirExistenciaTabelaAsync(connection);

                var dbJogadores = new DatabaseJogadores();
                await dbJogadores.GarantirExistenciaTabelaAsync(connection);

                Console.WriteLine("Todas as tabelas verificadas/criadas com sucesso!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro crítico ao inicializar o banco de dados: {ex.Message}");
            return; 
        }
        Console.WriteLine(":D");

        // 1. Instanciar RepositoryTimes primeiro, pois LeitorDeJogador e LeitorDeTecnico dependem dele.
        var repoTimes = new RepositoryTimes(mariaDbConnStr, new LeitorDeTimes()); // LeitorDeTimes agora não precisa de repositório no construtor

        // 2. Instanciar LeitorDeJogador e LeitorDeTecnico passando a dependência de RepositoryTimes.
        var leitorDeJogador = new LeitorDeJogador(repoTimes);
        var leitorDeTecnico = new LeitorDeTecnico(repoTimes);

        // 3. Instanciar os Repositórios de Jogador, Técnico e ADM, passando seus respectivos leitores.
        var repoJogador = new RepositoryJogador(mariaDbConnStr, leitorDeJogador);
        var repoTecnico = new RepositoryTecnico(mariaDbConnStr, leitorDeTecnico);
        var repoADM = new RepositoryADM(mariaDbConnStr); // LeitorDeADM é estático, não precisa ser passado aqui.

        // 4. Inicializar o ADM.
        await InitializerADM.Inicializar(repoADM);
        Console.WriteLine(":D");

        // 5. Instanciar Autenticador e Registro, passando todas as suas dependências.
        var autenticador = new Autenticador(mariaDbConnStr, repoJogador, repoTecnico, repoADM);
        var registro = new Registro(mariaDbConnStr, repoJogador, repoTecnico, repoADM);

        // 6. Instanciar Views de Usuarios e Views de Administrador
        var viewsAdministrador = new Views_Administrador(autenticador);
        var viewsUsuarios = new Views_Usuarios(autenticador);

        // 7. Instanciar menu de contas para funcionanmento de viewsContas
        var menuContas = new Views_De_OpcoesContas(autenticador, viewsAdministrador, viewsUsuarios);

        // 8. Instanciar Views_De_Contas com os serviços corretos.
        var viewsContas = new Views_De_Contas(autenticador, registro, menuContas);
        await viewsContas.DisplayMenu_LoginInicial();

        Console.WriteLine("Fim do programa. Pressione uma tecla para sair...");
        Console.Read();
    }
}