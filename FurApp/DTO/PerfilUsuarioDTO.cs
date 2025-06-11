namespace DTO.Perfil.Usuario
{
    public class PerfilUsuarioDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string TipoConta { get; set; }
        public required int Idade { get; set; }
        public float Saldo { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Interesses { get; set; }
        public required string Amistosos { get; set; }
        public required string TimeAssociado { get; set; }
    }
}