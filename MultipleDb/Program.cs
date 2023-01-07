using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MultipleDb.Domain;
using MultipleDb.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllers()
    .AddNewtonsoftJson((opt) =>
    {
        opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<TenantContext>(sp =>
{
    var httpContext = sp.GetRequiredService<IHttpContextAccessor>().HttpContext;

    var tenantId = int.Parse(httpContext.GetRouteValue("tenantId").ToString());

    return new TenantContext()
    {
        Id = tenantId,
    };
});

builder.Services.AddDbContext<CoreDbContext>((opt) =>
{
    opt.UseSqlServer(@$"Server=(localdb)\mssqllocaldb;Database=core-db;Trusted_Connection=True;");
});

builder.Services.AddDbContext<AppDbContext>((sp, opt) =>
{
    var tenantId = sp.GetRequiredService<TenantContext>().Id;

    // from core db? with mem cache
    var connectionString = @$"Server=(localdb)\mssqllocaldb;Database=tenant-{tenantId}-db;Trusted_Connection=True;";

    opt.UseSqlServer(connectionString);
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
