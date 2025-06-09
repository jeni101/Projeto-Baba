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
            if (campo == null) throw new ArgumentNullException(nameof(campo), "Campo não pode ser nulo");
            if (campo.TipoDeCampo == null) throw new InvalidOperationException("Campo.TipoDeCampo é nulo. O campo deve ter um tipo associado.");

            AbreviacaoTimeA = "Time A";
            AbreviacaoTimeB = "Time B";

            Data = data;
            Hora = hora;

            CampoId = campo.Id;
            LocalDisplay = campo.Local;
            TipoDeCampoDisplay = campo.TipoDeCampo.Tipo;

            QuantidadeDeJogadores = quantidadeDeJogadores > 0
                ? quantidadeDeJogadores
                : throw new ArgumentException("A quantidade de jogadores deve ser positiva");

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
            Nome = $"{AbreviacaoTimeA} x {AbreviacaoTimeB} - {Data:dd/MM/yyyy} {LocalDisplay}";
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
                Console.WriteLine($"{i + 1}. {campos[i].Nome} - {campos[i].TipoDeCampo.Tipo} (Capacidade: {campos[i].Capacidade})");
            }

            Console.Write("Digite número do campo: ");
            if (int.TryParse(Console.ReadLine(), out int escolha) && escolha > 0 && escolha <= campos.Count)
            {
                var campoEscolhido = campos[escolha - 1];
                Console.WriteLine($"Campo selecionado: {campoEscolhido.Nome} ({campoEscolhido.TipoDeCampo.Tipo})");
                return campoEscolhido;
            }
            Console.WriteLine("Inválido");
            return null;
        }

        //Definidor de campo
        public void DefinirCampo(Campo campo)
        {
            if (campo == null)
                throw new ArgumentNullException(nameof(campo), "O campo fornecido não pode ser nulo.");

            if (campo.TipoDeCampo == null)
                throw new InvalidOperationException("O campo fornecido não tem um TipoDeCampo associado.");

            CampoId = campo.Id;
            LocalDisplay = campo.Local;
            TipoDeCampoDisplay = campo.TipoDeCampo.Tipo;
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
                jogador.Interesses.Add($"Jogo em {Data:dd/MM/yyyy} às {Hora:HH:mm} no {LocalDisplay}");
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
                jogador.Interesses.Add($"Jogo em {Data:dd/MM/yyyy} às {Hora:HH:mm} no {LocalDisplay}");
            }
            return removido;
        }

        //Status se está aberto
        public void AbrirJogo()
        {
            Aberto = true;
            Console.WriteLine($"O jogo '{Nome}' agora está ABERTO para interessados.");
        }

        public void FecharJogo()
        {
            Aberto = false;
            Console.WriteLine($"O jogo '{Nome}' agora está FECHADO para interessados.");
        }

        //Criar jogo
        public static async Task<Jogo?> CriarJogo(JogosServices jogosServices)
        {
            Console.WriteLine("Criação de Jogo");

            var data = LeitorDataHora.LerData("data (dd/MM/yyyy): ");
            var hora = LeitorDataHora.LerHora("hora (HH:mm): ");

            var campo = await jogosServices.SelecionarCampoDisponível(data, hora);
            if (campo is null) return null;

            int quantidadeJogadores = jogosServices.ObterQuantidadeDeJogadores(campo.Capacidade);

            var jogo = new Jogo(data, hora, campo, quantidadeJogadores);

            Console.Write("Deseja que o jogo seja ABERTO para interessados? (S/N): ");
            if (Console.ReadLine()?.Trim().ToUpper() == "N")
            {
                jogo.FecharJogo();
            }
            else
            {
                jogo.AbrirJogo();
            }

            if (jogo.Aberto)
            {
                Console.WriteLine($"Status inicial: O jogo está ABERTO e pode receber interessados.");
            }
            else
            {
                Console.WriteLine($"Status inicial: O jogo está FECHADO para novos interessados.");
            }

            bool jogoSalvo = await jogosServices.PersistirJogo(jogo);

            if (jogoSalvo)
            {
                Console.WriteLine("Jogo criado e salvo com sucesso");

                try
                {
                    RepositoryPartidas repoPartidas = new RepositoryPartidas();

                    Partida novaPartida = new Partida(
                        jogo.Id,
                        jogo.AbreviacaoTimeA,
                        jogo.AbreviacaoTimeB,
                        jogo.Data,
                        jogo.Hora,
                        jogo.LocalDisplay
                    );

                    bool partidaSalva = await repoPartidas.SalvarPartidas(novaPartida);

                    if (partidaSalva)
                    {
                        Console.WriteLine($"Partida '{novaPartida.Nome}' criada e salva automaticamente para o jogo '{jogo.Nome}'.");
                    }
                    else
                    {
                        Console.WriteLine($"Aviso: Falha ao criar e salvar a partida automaticamente para o jogo '{jogo.Nome}'.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return jogo;
            }
            else
            { 
                Console.WriteLine("Falha ao criar e salvar o Jogo.");
                return null;
            }
        }
    }
}