using Grpc.Core;

namespace Users.Server.Services
{
    public class UserGrpcService : UserService.UserServiceBase
    {
        public override Task<UserResponse> GetById(GetUserByIdRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserResponse
            {
                User = new User
                {
                    Id = request.Id,
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@gmail.com"
                }
            });
        }

        public override Task<GetAllUsersResponse> GetAll(GetAllUsersRequest request, ServerCallContext context)
        {
            var response = new GetAllUsersResponse();

            response.Users.Add(new User
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john@test.com"
            });

            return Task.FromResult(response);
        }

        public override Task<UserResponse> Create(CreateUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new UserResponse
            {
                User = new User
                {
                    Id = 123,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email
                }
            });
        }
    }
}
