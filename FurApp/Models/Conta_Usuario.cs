using System;
using System.Text;
using System.Collections.Generic;
using Interfaces.IJogador;
using Interfaces.ITecnico;
using Models.ContaApp;

namespace Models.ContaApp.Usuario
{
    public class Conta_Usuario : Conta
    {
        //Atributos
        public List<string> Interesses { get; set; }
        public bool TornouSeJogador { get; private set; }
        public bool TornouSeTecnico { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool Deletado { get; private set; }
        public DateTime? DataDelecao { get; private set; }
        public string? QuemDeletou { get; set; }

        //Construtor
        public Conta_Usuario(string nome,
                            string senha,
                            int idade,
                            bool querSerJogador = true,
                            bool querSerTecnico = false)
                    : base(nome, senha, idade)
        {
            Interesses = new List<string>();
            TornouSeJogador = querSerJogador;
            TornouSeTecnico = querSerTecnico;
            DataCriacao = DateTime.Now;
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        //Construtor db
        public Conta_Usuario(Guid id, string nome, string senhaHash, int idade, List<string> interesses, bool tornouSeJogador, bool tornouSeTecnico, DateTime dataCriacao, bool deletado, DateTime? dataDelecao, string? quemDeletou)
            : base(id, nome, senhaHash, idade)
        {
            Interesses = interesses;
            TornouSeJogador = tornouSeJogador;
            TornouSeTecnico = tornouSeTecnico;
            DataCriacao = dataCriacao;
            Deletado = deletado;
            DataDelecao = dataDelecao;
            QuemDeletou = quemDeletou;
        }

        //perfil
        public void Editar_Perfil(string escolha)
        {
            // tipo de conta: 1- jogador 
            Console.WriteLine(""" 
            -=-=-=- opcoes de edicao  conta jogador -=-=-=-=-
            1. Nome/Nick
            2. Interesses
            3. time 
            0. voltar
            """); //LUIS VERIFICA O OUTPUT
        }

        public void Editar_Perfil_Nome()
        {
            string novoNome;
            while (true)
            {
                Console.WriteLine("Digite o novo Nome: ");
                novoNome = Console.ReadLine() ?? "";

                if (string.IsNullOrWhiteSpace(novoNome) || novoNome.Length < 3)
                {
                    Console.WriteLine("Nome inválido. Deve ter pelo menos 3 caracteres.");
                    continue;
                }

                base.Nome = novoNome;
                Console.WriteLine("Nome alterado com sucesso!");
                break;
            }
        }

        public void Deletar_Conta(string quemDeletou)
        {
            Deletado = true;
            DataDelecao = DateTime.Now;
            QuemDeletou = quemDeletou;
        }

        public void Exibir_Interesses() { }
        public void Deletar_Interesses() { }

        // funcionalidade
        public void Inscrever_Em_Eventos() { }
        public void Participar_De_Eventos() { }
        public void Sair_De_Eventos() { }
    }
}

