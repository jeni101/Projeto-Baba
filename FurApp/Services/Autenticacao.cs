using Interfaces.IAutenticacao;
using Models.ContaApp;
using Models.ContaApp.Usuario;

namespace Services.Autenticacao
{
    public class Autenticador : IAutenticacao
    {
        //Instaciador
        public static Autenticador Instancia { get; } = new Autenticador();

        //Atributos
        private Conta? _contaLogada;

        //Login
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

        //Logout
        public void Logout(Conta? conta)
        {
            if (conta == null || _contaLogada == null)
            {
                Console.WriteLine("Não está logado");
                return;
            }

            Console.WriteLine($"Logout realizado, tchau {conta.Nome}!");
            _contaLogada = null;
        }

        //Pegar nome
        public string PegarNomeConta() => _contaLogada?.Nome ?? "Nenhum usuário logado";
    }
}
