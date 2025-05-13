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
        public Times(string nomeTime, Conta_Tecnico criador)
        {
            if (string.IsNullOrWhiteSpace(nomeTime))
                throw new ArgumentException("Nome não pode ser vazio", nameof(nomeTime));
            
            if (criador == null)
                throw new ArgumentNullException(nameof(criador));

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

            if (string.IsNullOrWhiteSpace(nomeTime))
            {
                Console.WriteLine("Nome não pode zer vazio");
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
    }
}