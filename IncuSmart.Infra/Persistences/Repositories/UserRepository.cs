using IncuSmart.Application.Ports.Outbound;
using IncuSmart.Infra.Persistences.Mapper;
using Microsoft.EntityFrameworkCore;

namespace IncuSmart.Infra.Persistences.Repositories
{
    public class UserRepository : IUserRepository
    {
        public readonly ApplicationDbContext _dbContext;
        public static readonly UserMapper _userMapper = new();
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public async Task<bool> Save(User user)
        {
            await _dbContext.AddAsync(_userMapper.ToEntity(user));
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
