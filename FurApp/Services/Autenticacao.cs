using Interfaces.IAutenticacao;
using Models.ContaApp;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Repository.PersistenciaApp.ADM;

namespace Services.Autenticacao
{
    public class Autenticador : IAutenticacao
    {
        //Atributos
        private readonly string _connStr;
        private readonly RepositoryJogador _repoJogador;
        private readonly RepositoryTecnico _repoTecnico;
        private readonly RepositoryADM _repoADM;
        private Conta? _contaLogada;

        public Autenticador(string connStr, RepositoryJogador repoJogador, RepositoryTecnico repoTecnico, RepositoryADM repoADM)
        {
            _connStr = connStr;
            _repoJogador = repoJogador;
            _repoTecnico = repoTecnico;
            _repoADM = repoADM;
        }

        //Login
        public async Task<Conta?> LoginAsync()
        {
            Console.Clear();
            Console.WriteLine("--- Login ---");
            Console.Write("Nome de usuário: ");
            string? nome = Console.ReadLine();
            Console.Write("Senha: ");
            string? senha = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                Console.WriteLine("Nome de usuário ou senha não podem ser vazios.");
                await Task.Delay(1500);
                return null;
            }

            var adm = await _repoADM.GetByNameAsync(nome);
            if (adm != null && adm.Autenticar(senha))
            {
                _contaLogada = adm;
                Console.WriteLine("Login de ADM bem-sucedido!");
                await Task.Delay(1000);
                return adm;
            }

            var jogador = await _repoJogador.GetByNameAsync(nome);
            if (jogador != null && jogador.Autenticar(senha))
            {
                _contaLogada = jogador;
                Console.WriteLine("Login de Jogador bem-sucedido!");
                await Task.Delay(1000);
                return jogador; 
            }

            var tecnico = await _repoTecnico.GetByNameAsync(nome);
            if (tecnico != null && tecnico.Autenticar(senha))
            {
                _contaLogada = tecnico;
                Console.WriteLine("Login de Técnico bem-sucedido!");
                await Task.Delay(1000);
                return tecnico;
            }

            Console.WriteLine("Usuário ou senha inválidos.");
            await Task.Delay(1500);
            _contaLogada = null;
            return null;
        }
        
        //Logout
        public void Logout()
        {
            if (_contaLogada == null)
            {
                Console.WriteLine("Nenhuma conta logada");
                return;
            }

            Console.WriteLine($"Até logo, {_contaLogada.Nome}!");
            _contaLogada = null;
        }

        //Pegar nome
        public string? PegarNomeConta() => _contaLogada?.Nome ?? "Nenhum usuário logado";
        public Conta? PegarContaLogada() => _contaLogada;
    }
}
