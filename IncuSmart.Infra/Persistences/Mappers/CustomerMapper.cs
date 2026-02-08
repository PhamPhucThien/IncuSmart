namespace IncuSmart.Infra.Persistences.Mappers
{
    [Mapper]
    public partial class CustomerMapper
    {
        public partial CustomerEntity ToEntity(Customer domain);
        public partial Customer ToDomain(CustomerEntity entity);
    }
}
