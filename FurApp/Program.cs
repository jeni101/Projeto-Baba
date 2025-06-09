using Repository.PersistenciaApp.ADM;
using Repository.Database.Initializer.ADM;

class Program
{
  static async Task Main(string[] args)
  {
    var repoADM = new RepositoryADM();
    await InitializerADM.Inicializar(repoADM);
    Console.WriteLine(":D");

    var viewsContas = new Views.Contas.Views_De_Contas();
    await viewsContas.DisplayMenu_LoginInicial();

    Console.WriteLine("Fim do programa. Pressione uma tecla para sair...");
    Console.Read();
  }
}