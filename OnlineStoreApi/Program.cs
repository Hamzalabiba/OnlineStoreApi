using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using OnlineStore.Domain.Data;
using OnlineStore.Domain.Entities;
using OnlineStore.Repstory.Repostory;
using OnlineStore.Service.CustomServices;
using OnlineStore.Service.Product;
using OnlineStore.Service.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Depindancy Injection
builder.Services.AddScoped(typeof(IRepstory<>), typeof(Repository<>));
builder.Services.AddScoped<ICustomService<Users>, UserService>();
builder.Services.AddScoped<ICustomService<UserType>, UserTypeServies>();
builder.Services.AddScoped<ICustomService<Category>, CategoryService>();
builder.Services.AddScoped<ICustomService<Products>, ProudctsServices>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
