using Interfaces.IAutenticacao;
using Models.ContaApp;
using Models.ContaApp.Usuario;
using Repository.PersistenciaApp.Jogador;
using Repository.PersistenciaApp.Tecnico;
using Repository.PersistenciaApp.ADM;

namespace Services.Autenticacao
{
    public class Autenticador : IAutenticacao
    {
        //Atributos
        private readonly RepositoryJogador _repoJogador;
        private readonly RepositoryTecnico _repoTecnico;
        private readonly RepositoryADM _repoADM;
        private Conta? _contaLogada;

        public Autenticador(string connStr)
        {
            _repoJogador = new RepositoryJogador(connStr);
            _repoTecnico = new RepositoryTecnico(connStr);
            _repoADM = new RepositoryADM(connStr);
        }

        //Login
        public async Task<bool> LoginAsync()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine()?.Trim() ?? "";
    
            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine()?.Trim() ?? "";
    
            return await LoginAsync(nome, senha);
        }
        
        public async Task<bool> LoginAsync(string nome, string senha)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
                {
                    Console.WriteLine("Nome e senha são obrigatórios");
                    return false;
                }

                var jogador = await _repoJogador.GetByNameAsync(nome);
                var tecnico = await _repoTecnico.GetByNameAsync(nome);
                var adm = await _repoADM.GetByNameAsync(nome);

                Conta? conta = null;
                if (adm != null)
                {
                    conta = adm;
                }
                else if (jogador != null)
                {
                    conta = jogador;
                }
                else if (tecnico != null)
                {
                    conta = tecnico;
                }

                if (conta == null || !conta.Autenticar(senha))
                {
                    Console.WriteLine(" ! Credenciais inválidas ! ");
                    return false;
                }

                _contaLogada = conta;
                Console.WriteLine($"Bem-vindo, {conta.Nome}!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
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
