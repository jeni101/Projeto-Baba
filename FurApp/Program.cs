using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Autenticacao;
using Services.Register;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Repository.PersistenciaApp.ADM;
using Repository.Database.Initializer.ADM;
using Utils.Pelase.Leitor.Jogador;
using Utils.Pelase.Leitor.Tecnico;
using Repository.PersistenciaApp.Times;
using Utils.Pelase.Leitor.Times;

class Program
{
    static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        string mariaDbConnStr = configuration.GetConnectionString("MariaDB");

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
        var autenticador = new Autenticador(mariaDbConnStr, leitorDeJogador, leitorDeTecnico);
        var registro = new Registro(mariaDbConnStr, leitorDeJogador, leitorDeTecnico);

        // 6. Instanciar Views_De_Contas com os serviços corretos.
        var viewsContas = new Views.Contas.Views_De_Contas(autenticador, registro);
        await viewsContas.DisplayMenu_LoginInicial();

        Console.WriteLine("Fim do programa. Pressione uma tecla para sair...");
        Console.Read();
    }
}