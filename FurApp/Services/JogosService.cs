using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models.JogosApp;
using Models.CamposApp;
using Models.JogosApp.Partidas;
using Repository.PersistenciaApp.Campos;
using Repository.PersistenciaApp.Jogos;
using Repository.PersistenciaApp.Partidas;
using Utils.Pelase.Leitor.DataHora;

namespace Services.Jogos
{
    public class JogosServices
    {
        // Repositórios injetados via construtor (melhor prática)
        private readonly RepositoryCampos _campoRepository;
        private readonly RepositoryJogo _jogoRepository; // Renomeado para seguir o padrão de nome
        private readonly RepositoryPartidas _partidaRepository;

        // Construtor: Ideal para injeção de dependência.
        // Se você não usa um container de DI, pode instanciá-los aqui, mas a injeção é mais flexível.
        public JogosServices(
            RepositoryCampos campoRepository,
            RepositoryJogo jogoRepository,
            RepositoryPartidas partidaRepository)
        {
            _campoRepository = campoRepository ?? throw new ArgumentNullException(nameof(campoRepository));
            _jogoRepository = jogoRepository ?? throw new ArgumentNullException(nameof(jogoRepository));
            _partidaRepository = partidaRepository ?? throw new ArgumentNullException(nameof(partidaRepository));
        }

        public async Task<Jogo?> CriarNovoJogo()
        {
            Console.WriteLine("\n--- Início da Criação de Novo Jogo ---");

            // 1. Obter Data e Hora do Jogo
            var data = LeitorDataHora.LerData("Digite a data do jogo (dd/MM/yyyy): ");
            var hora = LeitorDataHora.LerHora("Digite a hora do jogo (HH:mm): ");

            // 2. Selecionar Campo Disponível (Toda a lógica de UI e filtragem está AQUI)
            var campoEscolhido = await SelecionarCampoDisponivel(data, hora);
            if (campoEscolhido == null)
            {
                Console.WriteLine("Criação de jogo cancelada: Nenhum campo disponível ou seleção inválida.");
                return null;
            }

            // 3. Obter Quantidade de Jogadores
            int quantidadeJogadores = ObterQuantidadeDeJogadores(campoEscolhido.Capacidade);
            if (quantidadeJogadores <= 0)
            {
                Console.WriteLine("Criação de jogo cancelada: Quantidade de jogadores inválida.");
                return null;
            }

            // 4. Criar a instância do objeto Jogo
            // O construtor de Jogo agora é mais simples e não tem lógica de Console.
            var novoJogo = new Jogo(data, hora, campoEscolhido, quantidadeJogadores);

            // 5. Definir abreviações dos times (opcional)
            Console.Write("Deseja definir as abreviações dos times (ex: SPFC, CRFL)? (S/N): ");
            if (Console.ReadLine()?.Trim().ToUpper() == "S")
            {
                Console.Write("Digite a abreviação para o Time A: ");
                string timeA = Console.ReadLine() ?? "Time A";
                Console.Write("Digite a abreviação para o Time B: ");
                string timeB = Console.ReadLine() ?? "Time B";
                novoJogo.DefinirAbreviacoes(timeA, timeB);
            }

            // 6. Definir status de Aberto/Fechado para interessados
            Console.Write("Deseja que o jogo seja ABERTO para interessados? (S/N): ");
            if (Console.ReadLine()?.Trim().ToUpper() == "N")
            {
                novoJogo.FecharJogo();
                Console.WriteLine($"Status inicial: O jogo está FECHADO para novos interessados.");
            }
            else
            {
                novoJogo.AbrirJogo();
                Console.WriteLine($"Status inicial: O jogo está ABERTO e pode receber interessados.");
            }

            // 7. Persistir o Jogo
            bool jogoSalvo = await PersistirJogo(novoJogo);

            if (jogoSalvo)
            {
                Console.WriteLine($"\nJogo '{novoJogo.Nome}' criado e salvo com sucesso!");

                // 8. Criar e Persistir a Partida automaticamente
                try
                {
                    Partida novaPartida = new Partida(
                        novoJogo.Id,
                        novoJogo.AbreviacaoTimeA,
                        novoJogo.AbreviacaoTimeB,
                        novoJogo.Data,
                        novoJogo.Hora,
                        novoJogo.LocalDisplay
                    );

                    bool partidaSalva = await _partidaRepository.SalvarPartidas(novaPartida);

                    if (partidaSalva)
                    {
                        Console.WriteLine($"Partida '{novaPartida.Nome}' criada e salva automaticamente para o jogo.");
                    }
                    else
                    {
                        Console.WriteLine($"Aviso: Falha ao criar e salvar a partida automaticamente para o jogo.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao criar/salvar partida: {ex.Message}");
                }

                return novoJogo;
            }
            else
            {
                Console.WriteLine("Falha ao criar e salvar o Jogo.");
                return null;
            }
        }

        //Campo disponível
        public async Task<Campo?> SelecionarCampoDisponivel(DateOnly data, TimeOnly hora)
        {
            Console.WriteLine("\n--- Seleção de Campo ---");
            string filtroNome;
            string filtroTipo;
            List<Campo> camposLivres;
            Campo? campoEscolhido;

            while (true)
            {
                Console.WriteLine("Filtros para campos (deixe em branco para ignorar):");
                Console.Write("Digite parte do nome do campo: ");
                filtroNome = Console.ReadLine() ?? "";

                Console.Write("Digite parte do tipo de campo: ");
                filtroTipo = Console.ReadLine() ?? "";

                var camposFiltrados = await _campoRepository.FiltrarCampo(filtroNome, filtroTipo);

                var jogosExistentesNoHorario = await _jogoRepository.GetJogosByDataHora(data, hora);
                var camposOcupadosIds = jogosExistentesNoHorario.Select(j => j.CampoId).ToHashSet();

                camposLivres = camposFiltrados
                                .Where(c => !camposOcupadosIds.Contains(c.Id))
                                .ToList();

                if (camposLivres.Count == 0)
                {
                    Console.WriteLine("Nenhum campo disponível com esses filtros para a data e hora selecionadas.");
                    Console.Write("Deseja tentar outros filtros ou outra data/hora? (S/N): ");
                    if (Console.ReadLine()?.Trim().ToUpper() != "S")
                    {
                        return null;
                    }
                }
                else
                {
                    break;
                }
            }

            while (true)
            {
                Console.WriteLine("\nCampos disponíveis:");
                for (int i = 0; i < camposLivres.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {camposLivres[i].Nome} - {camposLivres[i].TipoDeCampo?.Tipo ?? "Desconhecido"} (Capacidade: {camposLivres[i].Capacidade})");
                }

                Console.Write("Digite o número do campo desejado (ou 0 para cancelar): ");
                if (int.TryParse(Console.ReadLine(), out int escolha) && escolha >= 0 && escolha <= camposLivres.Count)
                {
                    if (escolha == 0)
                    {
                        Console.WriteLine("Seleção de campo cancelada.");
                        return null;
                    }
                    campoEscolhido = camposLivres[escolha - 1];
                    Console.WriteLine($"Campo selecionado: {campoEscolhido.Nome} ({campoEscolhido.TipoDeCampo?.Tipo ?? "Desconhecido"})");
                    return campoEscolhido;
                }
                Console.WriteLine("Seleção inválida. Por favor, digite um número da lista.");
            }
        }

        //Quantidade de Jogadores
        public int ObterQuantidadeDeJogadores(int capacidadeMaximaCampo)
        {
            Console.WriteLine($"\n--- Definição da Quantidade de Jogadores ---");
            Console.WriteLine($"Capacidade máxima do campo: {capacidadeMaximaCampo} jogadores.");

            int quantidade;
            while (true)
            {
                Console.Write("Digite a quantidade de jogadores para o jogo: ");
                string entrada = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(entrada, out quantidade))
                {
                    if (quantidade < 1)
                    {
                        Console.WriteLine("A quantidade deve ser pelo menos 1.");
                        continue;
                    }
                    
                    if (quantidade > capacidadeMaximaCampo)
                    {
                        Console.WriteLine($"Aviso: A quantidade ({quantidade}) excede a capacidade máxima do campo ({capacidadeMaximaCampo}).");
                        Console.Write("Deseja continuar mesmo assim? (S/N): ");
                        if (Console.ReadLine()?.Trim().ToUpper() == "S")
                        {
                            return quantidade;
                        }
                        else
                        {
                            continue;
                        }
                    }
                    return quantidade;
                }
                else
                {
                    Console.WriteLine("Por favor, digite um número válido.");
                }
            }
        }

        public async Task<bool> PersistirJogo(Jogo jogo)
        {
            try
            {
                if (jogo == null)
                {
                    Console.WriteLine("Erro: O objeto Jogo a ser persistido não pode ser nulo.");
                    return false;
                }
                return await _jogoRepository.SalvarJogos(jogo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao persistir jogo: {ex.Message}");
                return false;
            }
        }
    }
}