using Models.ContaApp;
namespace Interfaces.IAutenticacao;

interface IAutenticacao
{
    bool Login(Conta conta, string senha);
    void Logout(Conta conta);
    string PegarNomeConta();

}