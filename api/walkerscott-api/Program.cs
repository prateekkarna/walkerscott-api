using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using wakerscott_integration.DbConfigurations;
using wakerscott_integration.Services;
using walkerscott_application.Query.Interfaces;
using walkerscott_application.Query.Services;
using walkerscott_domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using walkerscott_application.Utilities;
using walkerscott_application.Command.Interfaces;
using walkerscott_application.Command.Services;
using walkerscott_domain.Interfaces.UnitOfWork;
using walkerscott_application.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<INewsQueryRepository, NewsQueryRepository>();
builder.Services.AddScoped<INewsCategoryRepository, NewsCategoryRepository>();
builder.Services.AddScoped<INewsQuery, NewsQuery>();
builder.Services.AddScoped<INewsCategory, NewsCategory>();
builder.Services.AddScoped<INewsCommandRepository, NewsCommandRepository>();
builder.Services.AddScoped<INewsCommand, NewsCommand>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<RequestInfo>();

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


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
    //var cns = builder.Configuration.GetConnectionString("ApplicationDbConnection");
    optionsBuilder.UseSqlServer(cn);

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corsapp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
