namespace IncuSmart.Infra.Persistences.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private static readonly CustomerMapper _customerMapper = new();
        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Customer customer)
        {
            CustomerEntity entity = _customerMapper.ToEntity(customer);
            await _dbContext.AddAsync(entity);
        }
    }
}
