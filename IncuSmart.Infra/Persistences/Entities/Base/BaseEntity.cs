namespace IncuSmart.Infra.Persistences.Entities.Base
{
    public class BaseEntity<TStatus>
    {
        public long Id { get; set; }

        public required TStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }
    }
}
