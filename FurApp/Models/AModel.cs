using System;

namespace Models
{
    public abstract class AModel
    {
        public Guid Id { get; set; }

        protected AModel()
        {
            Id = Guid.NewGuid();
        }
    }
}