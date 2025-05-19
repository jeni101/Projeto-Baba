using Interfaces.IAutenticacao;
using Models.ContaApp;
using Models.ContaApp.Usuario;

namespace Services.Autenticacao
{
    public class Autenticador : IAutenticacao
    {
        public static Autenticador Instancia { get; } = new Autenticador();
        private Conta _contaLogada;
        public bool Login(Conta conta, string senha)
        {
            if (conta == null || string.IsNullOrWhiteSpace(senha))
                return false;

            bool logado = conta.Autenticar(senha);

            if (logado)
            {
                _contaLogada = conta;
                Console.WriteLine($"Bem vindo, {conta.Nome}!");
            }
            else
            {
                Console.WriteLine("Falha login");
            }
            return logado;
        }

        public void Logout(Conta conta)
        {
            if (conta == null || _contaLogada == null)
            {
                Console.WriteLine("Não está logado");
                return;
            }

            Console.WriteLine($"Logout realizado, tchau {conta.Nome}!");
            _contaLogada = null;
        }

        public string PegarNomeConta()
        {
            return _contaLogada?.Nome ?? "Nenhum usuário logado";
        }
    }
}
