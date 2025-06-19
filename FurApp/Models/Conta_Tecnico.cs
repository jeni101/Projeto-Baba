using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Interfaces.ITecnico;
using Models.ContaApp.Usuario;
using Models.TimesApp;
using Services.Times;

namespace Models.ContaApp.Usuario.Tecnico
{
    public class Conta_Tecnico : Conta_Usuario, ITecnico
    {
        private readonly TimesServices _timesServices;
        //sobre o tecnico
        public Time? TimeTecnico { get; set; }
        public List<string> Partidas {get; set;}

        //Construtor
        public Conta_Tecnico(string nome,
                            string senha,
                            int idade)
                            : base(nome, senha, idade)
        {
            TimeTecnico = null;
            Partidas = new List<string>();
        }

        //Construtor db
        public Conta_Tecnico(Guid id, string nome, string senhaHash, int idade,
                            List<string> interesses, bool tornouSeJogador, bool tornouSeTecnico,
                            DateTime dataCriacao, bool deletado, DateTime? dataDelecao,
                            string? quemDeletou, Time? timeAssociado, List<string> partidas)
                            : base(id, nome, senhaHash, idade, interesses, tornouSeJogador,
                                    tornouSeTecnico, dataCriacao, deletado, dataDelecao, quemDeletou)
        {
            TimeTecnico = timeAssociado;
            Partidas = partidas;
        }

        //time
        public async Task CriarTime()
        {
            Console.WriteLine("Criação de Time");
            Console.WriteLine("Digite o nome que deseja para o seu time:");
            string? nomeTime = Console.ReadLine();

            Console.WriteLine("Qual será a abreviação do seu time?");
            string? abreviacaoTime = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeTime) || string.IsNullOrWhiteSpace(abreviacaoTime))
            {
                Console.WriteLine("Nome ou abreviação não podem estar vazios.");
                return;
            }

            var timeCriado = await _timesServices.CriarTime(nomeTime, abreviacaoTime, this);

            if (timeCriado != null)
            {
                // Agora você atribui o objeto Time completo
                this.TimeTecnico = timeCriado;
                Console.WriteLine($"O técnico '{Nome}' agora está associado ao time '{this.TimeTecnico.Nome}'");
            }
            else
            {
                Console.WriteLine("Não foi possível criar o time. Verifique os dados ou o serviço de times.");
            }
        }

        //jogos
        void ITecnico.CriarJogo()
        {
            throw new NotImplementedException();
        }
        void ITecnico.EntrarJogo()
        {
            throw new NotImplementedException();
        }
    }
}