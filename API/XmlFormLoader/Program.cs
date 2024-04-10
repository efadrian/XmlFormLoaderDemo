using XMLFormLoaderDemo;
using XMLFormLoaderDemo.Repository;
using XMLFormLoaderDemo.Repository.Interface;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
}); //

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IXmlHelper, XmlHelperRepository>(); // xml

builder.Services.AddSingleton<IFormData, FormDataRepository>(); // address

builder.Services.AddSingleton<IPayments,PaymentsRepository>(); // payment

// sql
builder.Services.AddDbContext<DbSQLContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection"));
});

builder.Services.AddScoped<IUserAddress,UserAddressRepository>(); // user address

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll"); // CORS
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
