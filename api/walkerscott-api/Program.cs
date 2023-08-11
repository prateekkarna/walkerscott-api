using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using wakerscott_integration.DbConfigurations;
using wakerscott_integration.Services;
using walkerscott_application.Query.Interfaces;
using walkerscott_application.Query.Services;
using walkerscott_domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<INewsCommandRepository,>()
builder.Services.AddScoped<INewsQueryRepository, NewsQueryRepository>();
builder.Services.AddScoped<INewsQuery, NewsQuery>();



builder.Services.AddTransient<ApplicationDbContext>();

builder.Services.AddScoped<IDbConnection>((service) =>

{
    var cns = builder.Configuration.GetConnectionString("ApplicationDbConnection");
    var connection = new SqlConnection(cns);
    connection.Open();
    return connection;

});





builder.Services.AddScoped<IDbTransaction>((serviceProvider) =>

{
    var connection = serviceProvider.GetRequiredService<IDbConnection>();
    return connection.BeginTransaction(IsolationLevel.ReadCommitted);

});




builder.Services.AddDbContext<ApplicationDbContext>((sp, optionsBuilder) =>

{
    var cn = (DbConnection)sp.GetRequiredService<IDbConnection>();
    var cns = builder.Configuration.GetConnectionString("ApplicationDbConnection");
    optionsBuilder.UseSqlServer(cns);

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
