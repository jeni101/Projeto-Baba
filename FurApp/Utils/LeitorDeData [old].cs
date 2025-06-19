namespace Utils.Pelase.Leitor.DataHora
{
    public static class LeitorDataHora
    {
        public static DateOnly LerData(string message)
        {
            while (true)
            {
                if (DateOnly.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", out var data) && data >= DateOnly.FromDateTime(DateTime.Now))
                    return data;
                Console.WriteLine("Data inválida ou no passado");
            }
        }

        public static TimeOnly LerHora(string message)
        {
            while (true)
            {
                if (TimeOnly.TryParseExact(Console.ReadLine(), "HH:mm", out var hora) && hora >= TimeOnly.FromDateTime(DateTime.Now))
                    return hora;
                Console.WriteLine("Formato inválido");
            }
        }
    }
}