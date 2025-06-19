using System;

namespace Utils.Pelase.Leitor.DataHora
{
    public static class LeitorDataHora
    {
        public static DateOnly LerData(string message)
        {
            DateOnly data;
            Console.WriteLine(message); 
            while (true)
            {
                Console.Write("Data (dd/MM/yyyy): ");
                string? input = Console.ReadLine(); 
                if (DateOnly.TryParseExact(input, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out data))
                {
                    if (data >= DateOnly.FromDateTime(DateTime.Now))
                    {
                        return data;
                    }
                    else
                    {
                        Console.WriteLine("Data inválida: A data não pode ser no passado.");
                    }
                }
                else
                {
                    Console.WriteLine("Formato de data inválido. Use dd/MM/yyyy.");
                }
            }
        }

        public static TimeOnly LerHora(string message)
        {
            TimeOnly hora;
            Console.WriteLine(message);
            while (true)
            {
                Console.Write("Hora (HH:mm): ");
                string? input = Console.ReadLine(); 
                if (TimeOnly.TryParseExact(input, "HH:mm", null, System.Globalization.DateTimeStyles.None, out hora))
                {
                    return hora;
                }
                else
                {
                    Console.WriteLine("Formato de hora inválido. Use HH:mm (ex: 14:30).");
                }
            }
        }

        public static DateTime LerDataHoraCombinada(string messageData, string messageHora)
        {
            DateOnly data = LerData(messageData); 
            TimeOnly hora = LerHora(messageHora); 

            DateTime dataHoraCombinada = data.ToDateTime(hora);

            if (dataHoraCombinada < DateTime.Now)
            {
                Console.WriteLine("A data e hora combinadas não podem ser no passado. Por favor, tente novamente.");
                throw new InvalidOperationException("Data e hora combinadas no passado.");
            }
            return dataHoraCombinada;
        }
    }
}