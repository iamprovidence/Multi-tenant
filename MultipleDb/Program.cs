using Microsoft.EntityFrameworkCore;
using MultipleDb.Domain;
using MultipleDb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TenantContext>();
builder.Services.AddDbContext<AppDbContext>((sp, opt) =>
{
    var tenantId = sp.GetRequiredService<TenantContext>().GetId();

    opt.UseSqlServer(@$"Server=(localdb)\mssqllocaldb;Database=tenant-{tenantId}-db;Trusted_Connection=True;");
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
