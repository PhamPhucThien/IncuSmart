namespace IncuSmart.Infra.Persistences.Entities
{
    [Table("incubators")]
    public class IncubatorEntity : BaseEntity<BaseStatus>
    {
        public string SerialNumber { get; set; } = null!;

        public string? QrCode { get; set; }

        public long? ModelId { get; set; }

        public Guid? CustomerId { get; set; }

        public DateTime? ActivatedAt { get; set; }
    }
}
