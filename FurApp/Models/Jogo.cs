using System;
using System.Collections.Generic;
using Repository.PersistenciaApp.Campos;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Models.JogosApp.Partidas;
using Models.ContaApp.Usuario.Jogador;
using Repository.PersistenciaApp.Jogos;
using Repository.PersistenciaApp.Partidas;
using Utils.Pelase.Leitor.DataHora;
using Services.Jogos;

namespace Models.JogosApp
{
    public class Jogo
    {
        public Guid Id { get; protected set; }
        public string Nome { get; private set; }
        public string AbreviacaoTimeA { get; set; }
        public string AbreviacaoTimeB { get; set; }
        public bool Aberto { get; private set; }
        public DateOnly Data { get; private set; }
        public TimeOnly Hora { get; private set; }
        public Guid CampoId { get; private set; }
        public string LocalDisplay { get; private set; }
        public string TipoDeCampoDisplay { get; private set; }
        public List<string> Interessados { get; private set; }
        public int QuantidadeDeJogadores { get; private set; }

        //construtores
        public Jogo(DateOnly data,
                    TimeOnly hora,
                    Campo campo,
                    int quantidadeDeJogadores)
        {
            if (campo == null)
                throw new ArgumentNullException(nameof(campo), "Campo não pode ser nulo");
            if (campo.TipoDeCampo == null)
                throw new InvalidOperationException("Campo.TipoDeCampo é nulo. O campo deve ter um tipo associado.");
            if (quantidadeDeJogadores <= 0)
                throw new ArgumentException("A quantidade de jogadores deve ser positiva.", nameof(quantidadeDeJogadores));

            AbreviacaoTimeA = "Time A";
            AbreviacaoTimeB = "Time B";

            Data = data;
            Hora = hora;

            CampoId = campo.Id;
            LocalDisplay = campo.Local;
            TipoDeCampoDisplay = campo.TipoDeCampo.Tipo;

            QuantidadeDeJogadores = quantidadeDeJogadores;

            Interessados = new List<string>();
            Id = Guid.NewGuid();
            Aberto = true;
            Nome = GerarNome();
        }

        //Construtor no banco de dados
        public Jogo(Guid id, string nome, string abreviacaoTimeA, string abreviacaoTimeB, 
                    bool aberto, DateOnly data, TimeOnly hora, Guid campoId,
                    string localDisplay, string tipoDeCampoDisplay, 
                    List<string> interessados, int quantidadeDeJogadores)
        {
            Id = id;
            Nome = nome;
            AbreviacaoTimeA = abreviacaoTimeA;
            AbreviacaoTimeB = abreviacaoTimeB;
            Aberto = aberto;
            Data = data;
            Hora = hora;
            CampoId = campoId;
            LocalDisplay = localDisplay;
            TipoDeCampoDisplay = tipoDeCampoDisplay;
            Interessados = interessados ?? new List<string>();
            QuantidadeDeJogadores = quantidadeDeJogadores;
        }

        //funcoes
        //Receber nome
        public string GerarNome()
        {
            return $"{AbreviacaoTimeA} x {AbreviacaoTimeB} - {Data:dd/MM/yyyy} {LocalDisplay}";
        }

        //Definir abreviaturas
        public void DefinirAbreviacoes(string timeA, string timeB)
        {
            if (string.IsNullOrWhiteSpace(timeA) || string.IsNullOrWhiteSpace(timeB))
                throw new ArgumentException("Abreviação não deve estar vazia");

            AbreviacaoTimeA = timeA.Trim().ToUpper();
            AbreviacaoTimeB = timeB.Trim().ToUpper();
            Nome = GerarNome();
        }

        //Atualização
        public void AtualizarNome()
        {
            Nome = GerarNome();
        }

        //Alterar data
        public void Alterar_Data()
        {
            try
            {
                string entrada = Console.ReadLine() ?? string.Empty;

                if (DateOnly.TryParseExact(entrada, "dd/MM/yyyy", null,
                    System.Globalization.DateTimeStyles.None, out DateOnly novaData))
                {
                    Data = novaData;
                    Nome = GerarNome();
                }
                else
                {
                    Console.WriteLine("Formato de data inválido. Use dd/MM/yyyy");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Alterar hora
        public void Alterar_Hora()
        {
            string entrada = Console.ReadLine() ?? "0";

            if (TimeOnly.TryParseExact(entrada, "HH:mm", null,
                System.Globalization.DateTimeStyles.None, out TimeOnly novaHora))
            {
                Hora = novaHora;
                Nome = GerarNome();
            }
        }

        //Alterar local
        public void Alterar_Local(string novoLocal)
        {
            if (string.IsNullOrWhiteSpace(novoLocal))
                throw new ArgumentException("O novo local não pode estar vazio");

            LocalDisplay = novoLocal;
            Nome = GerarNome();
        }

        //Quantidade de Jogadores
        public void Alterar_Quantidade_De_Jogadores()
        {
            string entrada = Console.ReadLine() ?? string.Empty;
            if (int.TryParse(entrada, out int novaQuantidade) && novaQuantidade > 0)
            {
                QuantidadeDeJogadores = novaQuantidade;
            }
        }

        //Interessados
        public void AdicionarInteressado(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome) && !Interessados.Contains(nome))
            {
                Interessados.Add(nome);
                Console.WriteLine($"[Jogo] Adicionado interessado: {nome}"); // Adicionado para debug
            }
            else
            {
                Console.WriteLine($"[Jogo] Interessado '{nome}' já existe ou nome inválido.");
            }
        }

        //Interessados (Conta_Jogador)
        public bool AdicionarInteressado(Conta_Jogador jogador)
        {
            if (jogador == null)
            {
                Console.WriteLine("[Jogo] Tentativa de adicionar interessado nulo.");
                return false;
            }

            string identificacao = $"{jogador.Nome} ({jogador.Posicao})";

            if (!Interessados.Contains(identificacao))
            {
                Interessados.Add(identificacao);
                Console.WriteLine($"[Jogo] Adicionado interessado (objeto): {identificacao}");
                return true;
            }
            else
            {
                Console.WriteLine($"[Jogo] Interessado (objeto) '{identificacao}' já existe.");
                return false;
            }
        }

        //Remover interessado (Conta_Jogador)
        public bool RemoverInteressado(Conta_Jogador jogador)
        {
            if (jogador == null)
            {
                Console.WriteLine("[Jogo] Tentativa de remover interessado nulo.");
                return false;
            }

            string identificacao = $"{jogador.Nome} ({jogador.Posicao})";
            bool removido = Interessados.Remove(identificacao);

            if (removido)
            {
                Console.WriteLine($"[Jogo] Removido interessado: {identificacao}");
            }
            else
            {
                Console.WriteLine($"[Jogo] Interessado '{identificacao}' não encontrado para remoção.");
            }
            return removido;
        }

        public void AbrirJogo()
        {
            Aberto = true;
        }

        public void FecharJogo()
        {
            Aberto = false;
        }
    }
}