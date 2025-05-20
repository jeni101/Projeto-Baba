using Models.ContaApp;
namespace Interfaces.IAutenticacao;

interface IAutenticacao
{
    Task<bool> LoginAsync();
    Task<bool> LoginAsync(string nome, string senha);
    void Logout();
    string? PegarNomeConta();
    Conta? PegarContaLogada();

}