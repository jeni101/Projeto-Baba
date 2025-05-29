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
        //sobre o tecnico
        public string Time {get; set;}
        public List<string> Jogos {get; set;}
        public List<string> Partidas {get; set;}

        //Construtor
        public Conta_Tecnico(string nome, 
                            string senha, 
                            int idade,
                            string time)
                            : base (nome, senha, idade)
            {
                Time = time ?? string.Empty;
                Jogos = new List<string>();    
                Partidas = new List<string>();
            }

        //time
        async void ITecnico.CriarTime()
        {
            Console.WriteLine("Criação de Time");
            Console.WriteLine("Digite o nome que deseja para o seu time");
            string? nomeTime = Console.ReadLine();

            Console.WriteLine("Qual será a abreviação do seu time?");
            string? abreviacaoTime = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nomeTime) || string.IsNullOrWhiteSpace(abreviacaoTime))
            {
                Console.WriteLine("Nome ou abreviação não podem estar vazios");
                return;
            }

            TimesServices timesServices = new TimesServices();

            var timeCriado = await timesServices.CriarTime(nomeTime, abreviacaoTime, this);

            if (timeCriado != null)
            {
                this.Time = timeCriado.Nome;
                Console.WriteLine($"O técnico '{Nome}' agora está associado ao time '{this.Time}'");
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