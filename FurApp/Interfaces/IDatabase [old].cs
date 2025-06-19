using MySqlConnector;
namespace Interfaces.old.IDatabase;

interface IDatabase
{
    string NomeTabela { get; }
    string ScriptCriacao { get; }
    Task CriarTabelaAsync(MySqlConnection conn);
}