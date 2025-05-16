using Models.ContaApp;
using Models.ContaApp.Usuario;

namespace Services.Login
{
    public class Login
    {
        public bool Logar(Conta conta, string senha)
        {
            if (conta == null || string.IsNullOrWhiteSpace(senha))
                return false;

            bool logado = conta.Autenticar(senha);

            Console.WriteLine(logado
                ? $"Bem vindo, {conta.Nome}!"
                : "Falha de login");
            return logado;
        }

        public void Logout(Conta conta)
        {
            if (conta == null)
            {
                Console.WriteLine("Nenhuma conta para dar logout");
                return;
            }
            Console.WriteLine($"Logout realizado para conta {conta.Nome}");
        }
    }
}