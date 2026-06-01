using Grpc.Net.Client;
using Users.ClientConsole;

var channel = GrpcChannel.ForAddress("https://localhost:7085");

var client = new UserService.UserServiceClient(channel);

var response = await client.GetByIdAsync(
    new GetUserByIdRequest
    {
        Id = 1
    });

Console.WriteLine(response.User.FirstName);

Console.ReadLine();