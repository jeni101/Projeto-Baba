using System;
using System.Collections.Generic;
using Repository.PersistenciaApp.Campos;
using Models.CamposApp;
using Models.CamposApp.Tipo;
using Models.ContaApp.Usuario.Jogador;

namespace Models.JogosApp
{
    public class Jogo
    {
        public Guid Id { get; protected set; }
        public string Nome { get; private set; }
        public string AbreviacaoTimeA { get; set; }
        public string AbreviacaoTimeB { get; set; }
        public DateOnly Data { get; private set; }
        public TimeOnly Hora { get; private set; }
        public string Local { get; private set; }
        public string TipoDeCampo { get; private set; }
        public List<string> Interessados { get; private set; }
        public int QuantidadeDeJogadores { get; private set; }

        //construtores
        public Jogo(DateOnly data,
                    TimeOnly hora,
                    string local,
                    string tipoDeCampo,
                    int quantidadeDeJogadores)
        {
            AbreviacaoTimeA = "Time A";
            AbreviacaoTimeB = "Time B";
            Nome = GerarNome();
            Data = data;
            Hora = hora;
            Local = local ?? throw new ArgumentNullException(nameof(local));
            TipoDeCampo = tipoDeCampo ?? throw new ArgumentNullException(nameof(tipoDeCampo));
            QuantidadeDeJogadores = quantidadeDeJogadores > 0
                ? quantidadeDeJogadores
                : throw new ArgumentException("A quantidade de jogadores deve ser positiva");
            Interessados = new List<string>();
            Id = Guid.NewGuid();
        }

        //funcoes
        //Receber nome
        public string GerarNome()
        {
            return $"{AbreviacaoTimeA} x {AbreviacaoTimeB} - {Data:dd/MM/yyyy} {Local}";
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
            Nome = $"{AbreviacaoTimeA} x {AbreviacaoTimeB} - {Data:dd/MM/yyyy} {Local}";
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
            }
        }

        //Alterar local
        public void Alterar_Local()
        {
            string novoLocal = Console.ReadLine() ?? string.Empty;
            if (!string.IsNullOrWhiteSpace(novoLocal))
            {
                Local = novoLocal;
                Nome = GerarNome();
            }
        }

        //Selecionar tipo de campo
        public static async Task<Campo?> SelecionarCampo(RepositoryCampos repoCampos)
        {
            Console.WriteLine("Seleção de Campo");
            Console.WriteLine("Filtros (deixe em branco para ignorar): ");
            Console.Write("Digite parte do nome do campo: ");
            string filtroNome = Console.ReadLine() ?? "";

            Console.Write("Digite parte do tipo de campo: ");
            string filtroTipo = Console.ReadLine() ?? "";

            var campos = await repoCampos.FiltrarCampo(filtroNome, filtroTipo);

            if (campos.Count == 0)
            {
                Console.WriteLine("Nenhum campo disponível com esses filtros");
                return null;
            }

            Console.WriteLine("Campos disponíveis");
            for (int i = 0; i < campos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {campos[i].Nome} - {campos[i].TipoDeCampo} (Capacidade: {campos[i].Capacidade})");
            }

            Console.Write("Digite número do campo");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= campos.Count)
            {
                var campoEscolhido = campos[escolha - 1];
                Console.WriteLine($"Campo selecionado: {campoEscolhido.Nome} ({campoEscolhido.TipoDeCampo})");
                return campoEscolhido;
            }
            Console.WriteLine("Inválido");
            return null;
        }

        //Definidor de campo
        public void DefinirCampo(Campo campo)
        {
            if (campo == null) return;
            Local = campo.Local;
            TipoDeCampo = campo.TipoDeCampo;
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
            if (!string.IsNullOrWhiteSpace(nome))
            {
                Interessados.Add(nome);
            }
        }

        //Interessado (Jogador)
        public bool AdicionarInteressado(Conta_Jogador jogador)
        {
            if (jogador == null) return false;

            string indentificacao = $"Jogador {jogador.Nome} ({jogador.Posicao})";

            if (!Interessados.Contains(indentificacao))
            {
                Interessados.Add(indentificacao);
                jogador.Interesses.Add($"Jogo em {Data} às {Hora} no {Local}");
                return true;
            }

            return false;
        }

        //Remover interessado (jogador)
        public bool RemoverInteressado(Conta_Jogador jogador)
        {
            if (jogador == null) return false;

            string indentificacao = $"{jogador.Nome} ({jogador.Posicao})";
            bool removido = Interessados.Remove(indentificacao);

            if (removido)
            {
                jogador.Interesses.Remove($"Jogo em {Data} às {Hora} no {Local}");
            }

            return removido;
        }
    }
}