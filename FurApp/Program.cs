using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Autenticacao;
using Services.Register;
using Repository.PersistenciaApp;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Repository.PersistenciaApp.ADM;
using Repository.Database.Initializer.ADM;

class Program
{
  static async Task Main(string[] args)
  {
    var builder = new ConfigurationBuilder()
        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

    IConfiguration configuration = builder.Build();

    string mariaDbConnStr = configuration.GetConnectionString("MariaDB");

    Autenticador autenticador = new Autenticador(mariaDbConnStr);
    Registro registro = new Registro(mariaDbConnStr);

    var repoJogador = new RepositoryJogador(mariaDbConnStr);
    var repoTecnico = new RepositoryTecnico(mariaDbConnStr);
    var repoADM = new RepositoryADM(mariaDbConnStr);
    await InitializerADM.Inicializar(repoADM);
    Console.WriteLine(":D");

    var viewsContas = new Views.Contas.Views_De_Contas(autenticador, registro);
    await viewsContas.DisplayMenu_LoginInicial();

    Console.WriteLine("Fim do programa. Pressione uma tecla para sair...");
    Console.Read();
  }
}