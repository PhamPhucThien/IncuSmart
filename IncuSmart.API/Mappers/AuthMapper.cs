namespace IncuSmart.API.Mappers
{
    [Mapper]
    public partial class AuthMapper
    {
        //[MapProperty(source: "SDT", target: "SDT", Use = nameof(toVNDNumber))]
        public partial LoginCommand RequestToLoginCommand(LoginRequest request);

        public partial RegisterCommand RequestToRegisterCommand(RegisterRequest request);
    }
}
