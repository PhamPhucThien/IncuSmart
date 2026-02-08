using IncuSmart.Infra.Persistences.Mappers;

namespace IncuSmart.Infra.Persistences.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private static readonly UserMapper _userMapper = new();
        private static readonly CustomerMapper _customerMapper = new();
        private readonly ICustomerRepository _customerRepository;
        public UserRepository(ApplicationDbContext dbContext, ICustomerRepository customerRepository) 
        {
            _dbContext = dbContext;
            _customerRepository = customerRepository;
        }

        public async Task<User?> FindByUserNameAndPasswordHashAndDeletedAtIsNull(string userName, string passwordHash)
        {
            UserEntity? entity = await _dbContext.Users
                .Where(x => x.Username == userName && x.PasswordHash == passwordHash && x.DeletedAt == null)
                .FirstOrDefaultAsync();

            return entity != null ? _userMapper.ToDomain(entity) : null;
        }

        public async Task<User?> FindByUserNameAndDeletedAtIsNull(string userName)
        {
            UserEntity? entity = await _dbContext.Users
                            .Where(x => x.Username == userName && x.DeletedAt == null)
                            .FirstOrDefaultAsync();

            return entity != null ? _userMapper.ToDomain(entity) : null;
        }

        public async Task Add(User user)
        {
            UserEntity entity = _userMapper.ToEntity(user);
            await _dbContext.AddAsync(entity);
        }
    }
}
