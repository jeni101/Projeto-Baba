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
        public float Saldo { get; private set; }
        public List<string> Interesses { get; set; }
        public List<string> Amistosos { get; set; }
        public bool TornouSeJogador { get; private set; }
        public bool TornouSeTecnico { get; private set; }
        public DateTime DataCriacao { get; private set; }

        //Construtor
        public Conta_Usuario(string nome,
                            string senha,
                            int idade,
                            bool querSerJogador = true,
                            bool querSerTecnico = false)
                    : base(nome, senha, idade)
        {
            Saldo = 10f;
            Interesses = new List<string>();
            Amistosos = new List<string>();
            TornouSeJogador = querSerJogador;
            TornouSeTecnico = querSerTecnico;
            DataCriacao = DateTime.Now;
        }

        //grana
        public void ExibirSaldo()
        {
            Console.WriteLine($"Saldo: {Saldo:F2}");
        }
        public void Apostar(float valor)
        {
            if (valor > Saldo)
            {
                Console.WriteLine("Saldo insuficiente para essa aposta"); //LUIS VERIFICA O OUTPUT
                return;
            }
            Saldo -= valor;
            Console.WriteLine($"Aposta de R$ {valor:F2} realizada com sucesso"); //LUIS VERIFICA O OUTPUT
        }

        //perfil
        public void Editar_Perfil(string escolha)
        {
            // tipo de conta: 1- jogador 
            Console.WriteLine(""" 
            -=-=-=- opcoes de edicao  conta jogador -=-=-=-=-
            1. Nome/Nick
            2. Interesses
            3. Amistosos
            4. time 
            0. voltar
            """); //LUIS VERIFICA O OUTPUT
        }

        public void Editar_Perfil_Nome()
        {
            string novoNome;

            while (true)
            {
                Console.WriteLine("digite o novo Nome: ");
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


       public void Editar_Interesses()
        {
            int limite = 150;
            var buffer = new StringBuilder();
            ConsoleKeyInfo key;

            Console.Write($"Digite seus interesses (máx: {limite} caracteres): ");

            while (true)
            {
                key = Console.ReadKey(intercept: true); // intercepta para não imprimir automaticamente

                if (key.Key == ConsoleKey.Enter) // verifica se apertou enter
                {
                    Console.WriteLine(); // pular linha ao finalizar
                    break;
                }
                else if (key.Key == ConsoleKey.Backspace && buffer.Length > 0) // verifica se tem algo no bufer p poder apagar
                {
                    buffer.Length--; // remove o último caractere
                    Console.Write("\b \b"); // apaga visualmente
                }
                else if (!char.IsControl(key.KeyChar) && buffer.Length < limite)
                {
                    buffer.Append(key.KeyChar);
                    Console.Write(key.KeyChar); // mostra o caractere
                }
                else if (buffer.Length >= limite) 
                {
                    
                    Console.Beep(); // dá um aviso sonoro se funcionar 
                    Console.Write("\nLimite de 150 caracteres atingido! \n");

                }
            }

            // Atribui o valor à lista
            Interesses = new List<string> { buffer.ToString() };

            Console.WriteLine("Interesses atualizados com sucesso!");
        }

        public void Deletar_Conta() { }

        public void Exibir_Interesses() { }
        public void Deletar_Interesses() { }

        // funcionalidade
        public void Inscrever_Em_Eventos() { }
        public void Participar_De_Eventos() { }
        public void Sair_De_Eventos() { }
    }
}

