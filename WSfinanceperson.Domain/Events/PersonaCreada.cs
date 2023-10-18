using ShareKernel.Core;


namespace WSfinanceperson.Domain.Events
{
    public record PersonaCreada
        : DomainEvent
    {
        public Guid PersonaId { get; set; }
        public PersonaCreada(Guid personaId, DateTime occuredOn) : base(occuredOn)
        {
            PersonaId = personaId;
        }
    }
}
