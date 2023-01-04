using Microsoft.EntityFrameworkCore;
using SingleDb.Domain;
using SingleDb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TenantContext>();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=single-tenant-db;Trusted_Connection=True;");
});

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
