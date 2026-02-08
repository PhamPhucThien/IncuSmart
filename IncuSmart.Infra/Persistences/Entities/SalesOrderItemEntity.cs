namespace IncuSmart.Infra.Persistences.Entities
{
    [Table("sales_order_items")]
    public class SalesOrderItemEntity : BaseEntity<BaseStatus>
    {
        public long OrderId { get; set; }

        public long IncubatorId { get; set; }
    }
}
