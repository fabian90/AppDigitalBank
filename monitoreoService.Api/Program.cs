using monitoreo.Core.Interfaces.Repositories;
using monitoreo.Core.Interfaces.Services;
using monitoreo.Core.Services;
using monitoreo.Core.Options;
using monitoreo.Infrastructure.Data;
using monitoreo.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using FluentValidation.AspNetCore;
using monitoreo.Commons.Helper;
using Identity.Core.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

var allowSpecificOrigins = "AllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

string[] lOrigins = builder.Configuration.GetValue<string>("Origins").Split(","); ;

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins(lOrigins);
                          policy.AllowAnyMethod();
                          policy.AllowAnyHeader();
                      });
});

#region Servicios
builder.Services.AddScoped<IErrorLogService, ErrorLogService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
#endregion

// Add services to the container.

builder.Services.AddControllers();
//.AddFluentValidation(x => x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(config => { config.AddSecurityDefinition("Bearer", new AuthenticateService().ValidateUser("usuarioPrueba", "123")); });
builder.Services.AddSwaggerGen();

builder.Services.AddFluentValidation(conf =>
{
    conf.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    conf.AutomaticValidationEnabled = false;
});

string connString =Encryption.DecryptConnectionString(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddDbContext<monitoreoDBContext>(options =>
{
    options.UseSqlServer(connString);
    options.UseSqlServer(connString, b => b.MigrationsAssembly("monitoreoService.Api"));
});

//Configure Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Configure Password Options
//builder.Services.Configure<PasswordOptions>(options => builder.Configuration.GetSection("PasswordOptions").Bind(options));
builder.Services.Configure<monitoreo.Core.Options.TokenOptions>(options => builder.Configuration.GetSection("Jwt").Bind(options));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var tokenOptions = builder.Configuration.GetSection("Jwt").Get<monitoreo.Core.Options.TokenOptions>();
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.Key))
        };
    });

builder.Services.AddAuthorization(options =>
{
    options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
        .RequireAuthenticatedUser()
        .Build();
});
//Configure UnitOfWork 
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FabianVargasTovar.Api v1"));
   
}

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
