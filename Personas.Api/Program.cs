using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persons.Api.Filters;
using Persons.Infrastructure.Contexts;
using Persons.Infrastructure.Extensions;
using System.Globalization;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    var Key = Encoding.UTF8.GetBytes(config.GetValue<string>("JwtConfig:SecretKey"));
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = config.GetValue<string>("JwtConfig:Issuer"),
        ValidAudience = config.GetValue<string>("JwtConfig:Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Key)
    };
});

builder.Services.AddControllers(opts =>
{
    opts.Filters.Add(typeof(AppExceptionFilterAttribute));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/
string[] origins = config.GetSection("Cors:UrlOrigins").Get<IEnumerable<string>>().ToArray();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builderx => builderx.WithOrigins(origins)
                            .AllowAnyHeader()
                            .WithMethods("GET", "POST", "PUT", "DELETE")
                            .AllowCredentials());
});

builder.Services.AddMediatR(Assembly.Load("Persons.Application"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(Assembly.Load("Persons.Infrastructure"));

var sqlServerConnection = config.GetConnectionString("database");
int timeOut = 60;

builder.Services.AddDbContext<PersistenceContext>(opt =>
{
    opt.UseSqlServer(sqlServerConnection, sqlopts =>
    {
        sqlopts.CommandTimeout(timeOut);
        sqlopts.MigrationsHistoryTable("_MigrationHistory", config.GetValue<string>("SchemaName"));
    });
    opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
}, ServiceLifetime.Transient);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Persons Api", Version = "v1" });
});


builder.Services.LoadConfigurations(config).AddDomainServices().AddPersistence().AddRepositorios();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Persons Api"));
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");
app.SeedDataBase();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
