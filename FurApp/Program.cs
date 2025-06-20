using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using System.IO;
using Services.Json;
using Repository.Database.Initializer.ADM;
using Repository.Database.Initializer.Campos;
using Repository.Database.Initializer.Campos.Tipo;
using Repository.Database.Initializer.Posicoes;
using Repository.PersistenciaApp.ADM;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Repository.PersistenciaApp.Times;
using Repository.PersistenciaApp.Campos;
using Repository.PersistenciaApp.Campos.Tipo;
using Repository.PersistenciaApp.Posicoes;
using Repository.PersistenciaApp.Jogos;
using Services.Autenticacao;
using Services.Register;
using Services.Jogos;
using Utils.Pelase.Leitor.DataHora;
using Views.Contas;
using Views.OpcoesContas;
using Views.OpcoesUsuarios;
using Views.OpcoesAdministrador;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Configuração (ainda pode ler appsettings.json se precisar de outras configs)
        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        IConfiguration configuration = builder.Build();

        // 2. Configuração da Injeção de Dependências
        var serviceProvider = new ServiceCollection()
            .AddSingleton<JsonServices>(sp =>
                new JsonServices(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Database")))


            // Registrar Repositórios JSON
            .AddSingleton<RepositoryADM>()
            .AddSingleton<RepositoryJogador>()
            .AddSingleton<RepositoryTecnico>()
            .AddSingleton<RepositoryTimes>()
            .AddSingleton<RepositoryCamposTipo>() 
            .AddSingleton<RepositoryCampos>()
            .AddSingleton<RepositoryPosicao>()
            .AddSingleton<RepositoryJogos>()

            // Registrar os Initializers (Transient, pois são usados uma vez na inicialização)
            .AddTransient<InitializerAdministrador>()
            .AddTransient<InitializerPosicoes>()
            .AddTransient<InitializerTipoCampos>()
            .AddTransient<InitializerCampos>()

            // Registrar Serviços de Autenticação e Registro
            .AddSingleton<Autenticador>()
            .AddSingleton<Registro>()

            // Registrar Views
            .AddSingleton<Views_Administrador>()
            .AddSingleton<Views_Usuarios>()
            .AddSingleton<Views_De_OpcoesContas>()
            .AddSingleton<Views_De_Contas>()
            .BuildServiceProvider();

        // 3. Executar Initializers para popular os JSONs, se necessário
        Console.WriteLine("Iniciando a inicialização de dados (se arquivos JSON vazios)...");
        try
        {
            await serviceProvider.GetRequiredService<InitializerPosicoes>().InitializeAsync();
            await serviceProvider.GetRequiredService<InitializerTipoCampos>().InitializeAsync();
            await serviceProvider.GetRequiredService<InitializerCampos>().InitializeAsync();
            await serviceProvider.GetRequiredService<InitializerAdministrador>().InitializeAsync();

            Console.WriteLine("Inicialização de dados concluída.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro durante a inicialização de dados: {ex.Message}");
            return;
        }


        // 4. Iniciar a aplicação principal (Views_De_Contas)
        Console.WriteLine("\nIniciando o sistema FurApp...");
        var viewsContas = serviceProvider.GetRequiredService<Views_De_Contas>();
        await viewsContas.DisplayMenu_LoginInicial();

        Console.WriteLine("Fim do programa. Pressione uma tecla para sair...");
        Console.Read();
    }
}