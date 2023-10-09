using ShareKernel.Core;


namespace WSfinanceperson.Domain.Events
{
    public record PersonaCreada
        : DomainEvent
    {
        public Guid PersonaId { get; }
        public PersonaCreada(Guid personaId, DateTime occuredOn) : base(occuredOn)
        {
            PersonaId = personaId;
        }
    }
}
