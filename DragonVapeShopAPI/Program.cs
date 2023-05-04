using Microsoft.EntityFrameworkCore;
using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.ClassInterface;
using DragonVapeShopAPI.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IVapesRepository, VapesRepository>();
builder.Services.AddScoped<IConsumableRepository, ConsumablesRepository>();
builder.Services.AddScoped<ILiquidsRepository, LiquidsRepository>();
builder.Services.AddScoped<IOnceVapesRepository, OnceVapesRepository>();

// �������� ������ ����������� �� ����� ������������
string connection = builder.Configuration.GetConnectionString("DefaultConnection");
// ��������� �������� ApplicationContext � �������� ������� � ����������
builder.Services.AddDbContext<ContextDatabase>(options => options.UseSqlServer(connection));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
