using System;
using System.Collections.Generic;
using System.Text.Json.Serialization; // Necessário para [JsonConstructor]
using Models.ContaApp; // Garante que a classe base Conta está neste namespace

namespace Models.ContaApp.Usuario
{
    public class Conta_Usuario : Conta
    {
        // Atributos
        public List<string> Interesses { get; set; }
        public bool TornouSeJogador { get; set; } // Mudado de private set para public set
        public bool TornouSeTecnico { get; set; } // Mudado de private set para public set
        public DateTime DataCriacao { get; set; } // Mudado de private set para public set
        public bool Deletado { get; set; }        // Mudado de private set para public set
        public DateTime? DataDelecao { get; set; } // Mudado de private set para public set
        public string? QuemDeletou { get; set; }

        // Construtor sem parâmetros (ESSENCIAL para System.Text.Json)
        public Conta_Usuario() : base() // Chama o construtor sem parâmetros da classe base Conta
        {
            // Inicialize coleções e valores padrão para evitar nulls
            Interesses = new List<string>();
            TornouSeJogador = false;
            TornouSeTecnico = false;
            DataCriacao = DateTime.MinValue; // Valor padrão para DateTime
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        // Construtor principal (para criação de novas contas de usuário via código)
        public Conta_Usuario(string nome,
                             string senha,
                             int idade,
                             bool querSerJogador = true,
                             bool querSerTecnico = false)
            : base(nome, senha, idade) // Chama o construtor apropriado de Conta
        {
            Interesses = new List<string>();
            TornouSeJogador = querSerJogador;
            TornouSeTecnico = querSerTecnico;
            DataCriacao = DateTime.Now; // Data de criação definida na hora da criação
            Deletado = false;
            DataDelecao = null;
            QuemDeletou = null;
        }

        // Construtor de desserialização (marcado com [JsonConstructor])
        // Este construtor é usado pelo System.Text.Json para recriar o objeto a partir do JSON.
        // Seus parâmetros devem corresponder a TODAS as propriedades que serão lidas do JSON.
        [JsonConstructor]
        public Conta_Usuario(Guid id, string nome, string senhaHash, int idade,
                             List<string> interesses, bool tornouSeJogador, bool tornouSeTecnico,
                             DateTime dataCriacao, bool deletado, DateTime? dataDelecao, string? quemDeletou)
            : base(id, nome, senhaHash, idade) // Chama o construtor DB de Conta
        {
            Interesses = interesses ?? new List<string>(); // Garante que a lista não seja nula
            TornouSeJogador = tornouSeJogador;
            TornouSeTecnico = tornouSeTecnico;
            DataCriacao = dataCriacao;
            Deletado = deletado;
            DataDelecao = dataDelecao;
            QuemDeletou = quemDeletou;
        }

        // Métodos da classe
        public void Editar_Perfil(string escolha)
        {
            Console.WriteLine("""
            -=-=-=- opcoes de edicao  conta jogador -=-=-=-=-
            1. Nome/Nick
            2. Interesses
            3. time
            0. voltar
            """);
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

        public void Exibir_Interesses() { /* ... */ }
        public void Deletar_Interesses() { /* ... */ }
        public void Inscrever_Em_Eventos() { /* ... */ }
        public void Participar_De_Eventos() { /* ... */ }
        public void Sair_De_Eventos() { /* ... */ }
    }
}