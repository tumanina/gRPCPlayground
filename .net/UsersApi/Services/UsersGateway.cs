namespace UsersApi.Services
{
    public class UsersGateway(UserService.UserServiceClient client)
    {
        private readonly UserService.UserServiceClient _client = client;

        public async Task<User> GetUser(long id)
        {
            var response = await _client.GetByIdAsync(new GetUserByIdRequest { Id = id });

            return response.User;
        }
    }
}
