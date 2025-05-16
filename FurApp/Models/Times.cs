using Models.ContaApp.Usuario;
using Models.ContaApp.Usuario.Jogador;
using Models.ContaApp.Usuario.Tecnico;

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
                throw new ArgumentException("Nome não pode ser vazio", nameof(nomeTime)); //LUIS VERIFICA O OUTPUT
            
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
                Console.WriteLine("Criador invalido"); //LUIS VERIFICA O OUTPUT
                return;
            }

            if (string.IsNullOrWhiteSpace(nomeTime))
            {
                Console.WriteLine("Nome não pode zer vazio"); //LUIS VERIFICA O OUTPUT
                return;
            }

            if (listaDeTimes.Any(t => t.NomeTime.Equals(nomeTime, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Nome já existe"); //LUIS VERIFICA O OUTPUT
                return;
            }

            var novoTime = new Times(nomeTime, tecnico);
            listaDeTimes.Add(novoTime);
            Console.WriteLine($"Time '{nomeTime}' criado por tecnico '{tecnico.Nome}'"); //LUIS VERIFICA O OUTPUT
        }

        public static void VerificarTimes()
        {
            if (listaDeTimes.Count == 0)
            {
                Console.WriteLine("Nenhum time"); //LUIS VERIFICA O OUTPUT
                return;
            }

            Console.WriteLine("Times disponíveis"); //LUIS VERIFICA O OUTPUT
            foreach (var time in listaDeTimes)
            {
                Console.WriteLine($"-{time.NomeTime} (criado por: {time.Criador.Nome})"); //LUIS VERIFICA O OUTPUT
            }
        }
    }
}