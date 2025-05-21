using System;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using Views.Contas;
using Views_Campos;
using Conta_Jogador = Models.ContaApp.Usuario.Jogador.Conta_Jogador;
using Controle_de_execoesApp;
using Views.OpcoesContas;


class Program
{
    static async Task Main(string[] args)
    // teste 
       {
        var viewsDeContas = new Views_De_Contas();
        await viewsDeContas.DisplayMenu_LoginInicial();


        Console.WriteLine("Fim do programa. Pressione uma tecla para sair...");
        Console.ReadKey();
  }
}
    














//     {

       






    
//         var configuration = new ConfigurationBuilder()
//             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
//             .AddJsonFile("appsettings.json")
//             .Build();

//         var connectionString = configuration.GetConnectionString("MariaDB");

//         Console.WriteLine("Tentando conectar ao MariaDB...");
        
//         using var connection = new MySqlConnection(connectionString);

//         try
//         {
//             connection.Open();
//             Console.WriteLine("Conectado ao MariaDB com sucesso!");

//             // Testar a conexão
//             var command = new MySqlCommand("SELECT DATABASE()", connection);
//             var dbName = command.ExecuteScalar()?.ToString();
//             Console.WriteLine($" Banco de dados conectado: {dbName}");
            
//             // Mostrar tabelas (opcional)
//             command.CommandText = "SHOW TABLES";
//             using var reader = command.ExecuteReader();
//             Console.WriteLine("\n Tabelas disponíveis:");
//             while (reader.Read())
//             {
//                 Console.WriteLine($"- {reader.GetString(0)}");
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine("Erro ao conectar:");
//             Console.WriteLine(ex.Message);
//             Console.WriteLine("\n Verifique:");
//             Console.WriteLine("1. O container está rodando? (docker ps)");
//             Console.WriteLine($"2. A porta 18046 está liberada?");
//             Console.WriteLine("3. As credenciais no appsettings.json estão corretas?");
//         }

//         Console.WriteLine("\nPressione qualquer tecla para sair...");
//         Console.ReadKey();
//     }
// }



