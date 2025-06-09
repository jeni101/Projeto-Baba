namespace DTO.Times
{
    public class TimesDTO
    { 
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Abreviacao { get; set; }
        public required string Tecnico { get; set; }
        public required List<string> Jogadores { get; set; }
        public required List<string> Jogos { get; set; }
        public required List<string> Partidas { get; set; }
    }
}