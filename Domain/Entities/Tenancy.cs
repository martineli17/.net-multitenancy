namespace Domain.Entities
{
    public class Tenancy
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Tenancy(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
