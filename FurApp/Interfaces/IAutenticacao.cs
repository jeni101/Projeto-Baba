using Models.ContaApp;
namespace Interfaces.IAutenticacao;

interface IAutenticacao
{
    Task<Conta?> LoginAsync();
    void Logout();
    string? PegarNomeConta();
    Conta? PegarContaLogada();

}