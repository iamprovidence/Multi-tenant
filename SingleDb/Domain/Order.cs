namespace SingleDb.Domain
{
    public class Order : ITenantEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TenantId { get; set; }
    }
}
