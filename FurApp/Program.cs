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
using Repository.PersistenciaApp.Partidas; 
using Services.Autenticacao;
using Services.Register;
using Services.Jogos;
using Services.Times;
using Services.Partidas;
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
            // JsonServices é a base para todos os repositórios baseados em arquivo JSON
            // Ajustado para criar o caminho correto para a pasta Database
            .AddSingleton<JsonServices>(sp =>
            {
                var databasePath = Path.Combine(AppContext.BaseDirectory, "Database");
                Directory.CreateDirectory(databasePath); // Garante que a pasta Database exista
                return new JsonServices(databasePath);
            })

            // Registrar Repositórios JSON. Eles precisam do JsonServices.
            // A forma correta de registrar com dependências é usando uma lambda.
            .AddSingleton<RepositoryADM>(sp => new RepositoryADM(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryJogador>(sp => new RepositoryJogador(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryTecnico>(sp => new RepositoryTecnico(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryTimes>(sp => new RepositoryTimes(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryCamposTipo>(sp => new RepositoryCamposTipo(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryCampos>(sp => new RepositoryCampos(
                sp.GetRequiredService<JsonServices>(), 
                sp.GetRequiredService<RepositoryCamposTipo>()))
            .AddSingleton<RepositoryPosicao>(sp => new RepositoryPosicao(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryJogos>(sp => new RepositoryJogos(sp.GetRequiredService<JsonServices>()))
            .AddSingleton<RepositoryPartidas>(sp => new RepositoryPartidas(sp.GetRequiredService<JsonServices>())) 

            // Registrar os Initializers (Transient, pois são usados uma vez na inicialização)
            // Eles também precisam de seus respectivos repositórios
            .AddTransient<InitializerAdministrador>()
            .AddTransient<InitializerPosicoes>()
            .AddTransient<InitializerTipoCampos>()
            .AddTransient<InitializerCampos>()

            // Registrar Serviços de Autenticação e Registro
            .AddSingleton<Autenticador>(sp => new Autenticador(
                sp.GetRequiredService<RepositoryJogador>(),
                sp.GetRequiredService<RepositoryTecnico>(),
                sp.GetRequiredService<RepositoryADM>()))
            .AddSingleton<Registro>(sp => new Registro(
                sp.GetRequiredService<RepositoryJogador>(),
                sp.GetRequiredService<RepositoryTecnico>(),
                sp.GetRequiredService<RepositoryADM>()))

            // Adicionado: Registrar outros Serviços
            .AddSingleton<TimesServices>(sp => new TimesServices(
                sp.GetRequiredService<RepositoryTimes>(),
                sp.GetRequiredService<RepositoryJogador>()))
            .AddSingleton<JogosServices>(sp => new JogosServices(
                sp.GetRequiredService<RepositoryCampos>(),
                sp.GetRequiredService<RepositoryJogos>(), 
                sp.GetRequiredService<RepositoryPartidas>(),
                sp.GetRequiredService<RepositoryPosicao>()
            ))

            // Registrar Views
            // As Views precisam dos Services corretos
            .AddSingleton<Views_Administrador>(sp => new Views_Administrador(
                sp.GetRequiredService<Autenticador>()
            ))
            .AddSingleton<Views_Usuarios>(sp => new Views_Usuarios(
                sp.GetRequiredService<Autenticador>(),
                sp.GetRequiredService<JogosServices>() 
            ))
            .AddSingleton<Views_De_OpcoesContas>(sp => new Views_De_OpcoesContas(
                sp.GetRequiredService<Autenticador>(),
                sp.GetRequiredService<Views_Administrador>(),
                sp.GetRequiredService<Views_Usuarios>(),
                sp.GetRequiredService<TimesServices>(), 
                sp.GetRequiredService<JogosServices>()
            ))
            .AddSingleton<Views_De_Contas>(sp => new Views_De_Contas(
                sp.GetRequiredService<Autenticador>(),
                sp.GetRequiredService<Registro>(),
                sp.GetRequiredService<Views_De_OpcoesContas>()
            ))
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
            // Em caso de erro na inicialização, talvez você queira sair ou logar mais detalhes
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