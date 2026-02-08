namespace IncuSmart.Infra.Persistences.Entities
{
    [Table("customers")]
    public class CustomerEntity : BaseEntity<BaseStatus>
    {
        public long UserId { get; set; }

        public string? DeviceToken { get; set; }

        public string? PinNumberHash { get; set; }

        public string? Address { get; set; }
    }
}
