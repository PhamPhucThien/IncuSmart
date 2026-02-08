namespace IncuSmart.Infra.Persistences.Mapper
{
    [Mapper]
    public partial class UserMapper
    {
        public partial UserEntity ToEntity(User domain);
        public partial User ToDomain(UserEntity entity);
    }
}
