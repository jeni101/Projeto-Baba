using ContaJogadorApp;
using ContaTecnicoApp;
using ContaUsuarioApp;

namespace TimesApp
{
    public class Times
    {
        public string NomeTime { get; set; }
        public Conta_Tecnico Criador { get; set; }
        //Lista dos times
        private static readonly List<Times> listaDeTimes = new List<Times>();
        //Construtor privado
        private Times(string nomeTime, Conta_Tecnico criador)
        {
            NomeTime = nomeTime;
            Criador = criador;
        }
        
        //construtor
        public static void CriarTime(string nomeTime, Conta_Tecnico tecnico)
        {
            if (tecnico == null)
            {
                Console.WriteLine("Criador invalido");
                return;
            }

            if (listaDeTimes.Any(t => t.NomeTime.Equals(nomeTime, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Nome já existe");
                return;
            }

            var novoTime = new Times(nomeTime, tecnico);
            listaDeTimes.Add(novoTime);
            Console.WriteLine($"Time '{nomeTime}' criado por tecnico '{tecnico.Nome}'");
        }

        public static void VerificarTimes()
        {
            if (listaDeTimes.Count == 0)
            {
                Console.WriteLine("Nenhum time");
                return;
            }

            Console.WriteLine("Times disponíveis");
            foreach (var time in listaDeTimes)
            {
                Console.WriteLine($"-{time.NomeTime} (criado por: {time.Criador.Nome})");
            }
        }

        //Temos que recriar tal função abaixo
        public void ListarTimes(string nomeJogador)
        {
            var contas = Persistencia_De_Contas.Carregar_Contas();

            // Verifica se tem jogadores
            var listaContas = contas.Where(c => c.Tipo == "Jogador").ToList();
            if (listaContas.Any())
            {
                // Procura o jogador pelo nome
                var jogadorBase = listaContas.FirstOrDefault(c => c.Nome == nomeJogador);

                // Faz o cast para ContaJogador - ou seja converter o objeto de conta p contaJOgador p acesar oq tem la, no caso a variavel time q so existe em contaJOgador
                if (jogadorBase is Conta_Jogador jogador)
                {
                    Console.WriteLine($"{jogador.Nome} está inscrito nos seguintes times:");

                    // Percorre a lista de times, print de cada item mas e se for 1 so vai prentar letra por letra
                    foreach (var time in jogador.Time)
                    {
                        Console.WriteLine(time);
                        
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Jogador não encontrado ou não é do tipo esperado.");
                }
            }
            else
            {
                Console.WriteLine("Nenhuma conta de jogador foi encontrada.");
            }
        }
    }
}
