namespace Domain.Entities
{
    public class Contract
    {
        public Guid TenancyId { get; private set; }
        public Guid Id { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public decimal Value { get; private set; }

        public Contract(Guid tenancyId, decimal value)
        {
            TenancyId = tenancyId;
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            Value = value;
        }
    }
}
