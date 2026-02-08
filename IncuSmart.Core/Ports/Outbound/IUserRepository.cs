using IncuSmart.Core.Domain;

namespace IncuSmart.Application.Ports.Outbound
{
    public interface IUserRepository
    {
        // Quy ước: Get - Luôn có record, Find - Có thể không có record, FindAll - Trả về list, có thể rỗng
        Task<User?> FindByUserNameAndPasswordHashAndDeletedAtIsNull(string userName, string passwordHash);

        Task<User?> FindByUserNameAndDeletedAtIsNull(string userName);

        Task<bool> Save(User user);
    }
}
