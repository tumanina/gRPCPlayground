using Scalar.AspNetCore;
using UsersApi;
using UsersApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpcClient<UserService.UserServiceClient>(options =>
{
    options.Address = new Uri("https://localhost:7085");
});
builder.Services.AddScoped<UsersGateway>();

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
