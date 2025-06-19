namespace DTO.Campos
{
    public class CamposDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Local { get; set; }
        public required int Capacidade { get; set; }
        public required string TipoDeCampoNome { get; set; }
        public required Guid TipoDeCampoId { get; set; }
    }
}