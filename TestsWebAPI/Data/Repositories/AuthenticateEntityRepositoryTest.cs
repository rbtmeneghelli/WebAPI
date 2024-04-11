namespace TestsWebAPI.Data.Repositories;

public class AuthenticateEntityRepositoryTest : GenericRepositoryTest<AuthenticateEntity>, IAuthenticateEntityRepositoryTest
{
    public AuthenticateEntityRepositoryTest(WebAPITestContext context) : base(context) { }
}
