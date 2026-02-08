namespace IncuSmart.Core.Ports.Outbound
{
    public interface IUnitOfWork
    {
        Task BeginAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}
