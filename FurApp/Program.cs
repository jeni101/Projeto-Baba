using System;
using MySqlConnector;

class Program
{
    static void Main()
    {
        string connectionString = "Server=localhost;" +
                                  "Port=18046;" +
                                  "Database=furapp;" +
                                  "User ID=root;" +
                                  "Password=qhG171U4;" +
                                  "Connection Timeout=30;";

        using var connection = new MySqlConnection(connectionString);

        try
        {
            connection.Open();
            Console.WriteLine("Conectado ao MariaDB com sucesso!");

            var command = new MySqlCommand("SELECT VERSION()", connection);
            var result = command.ExecuteScalar();

            string version = result?.ToString() ?? "Desconhecida";
            Console.WriteLine("Versão do MariaDB: " + version);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao conectar:");
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine("Pressione qualquer tecla para sair...");
        Console.ReadKey();
    }
}