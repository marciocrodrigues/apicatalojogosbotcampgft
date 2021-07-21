using System;

namespace ApiCatalogoJogos.Entities
{
    public abstract class Entidade
    {
        public Entidade()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
    }
}
