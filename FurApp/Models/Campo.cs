using System;

namespace Models.CamposApp
{
    public class Campo
    {
        public Guid Id { get; set; }
        public string Nome { get; private set; }
        public string Local { get; private set; }
        public int Capacidade { get; private set; }
        public string TipoDeCampo { get; private set; }

        public Campo(string nome, string localizacao, int capacidade, string tipoDeCampo)
        {
            Nome = nome;
            Local = localizacao;
            Capacidade = capacidade;
            TipoDeCampo = tipoDeCampo;
        }

        public void AtualizarCampo(int novaCapacidade, string novoTipoDeCampo)
        {
            Capacidade = novaCapacidade;
            TipoDeCampo = novoTipoDeCampo;
        }

        public void MostrarDetalhes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Localização: {Local}");
            Console.WriteLine($"Capacidade: {Capacidade}");
            Console.WriteLine($"Tipo de Campo: {TipoDeCampo}");
        }

        public static class TipoDeQuadra
        {
            public static (string tipoDeCampo, int quantidadeJogadores) ObterInfo(int opcao)
            {
                return opcao switch
                {
                    1 => ("Campo Oficial", 22),
                    2 => ("Campo Sintético", 14),
                    3 => ("Futsal", 10),
                    4 => ("Futebol de Areia", 10),
                    5 => ("Improvisado", 6),
                    _ => ("Indefinido", 0),
                };
            }
        
            public static void Verificar_Disponibilidade()
            {
                // usuario digita a data e o sistema faz a verificacao do dia escolhido e mostras todas as quadras e horarios reservados e livres

            }

            public static void ReservarCampo()
            {
                //verificacao se ha campo nesse dia e horario disponivel 
                // se tiver tipos de campo diferentes e horarios iguais pode reservar o campo
            }

           
            

        }
    }
}

       

