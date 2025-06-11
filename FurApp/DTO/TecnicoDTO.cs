using System;

namespace DTO.Tecnico
{
    public class TecnicoDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public Guid TimeId { get; set; }
    }
}