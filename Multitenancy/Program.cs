using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Multitenancy.Configuration;
using Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IMongoContext, MongoContext>(x => new MongoContext(builder.Configuration.GetConnectionString("MongoDB"), "POC_MULTI_TENANCY"));
builder.Services.AddScoped<IContractRepository, ContractRepository>();
builder.Services.AddScoped<ITenancyRepository, TenancyRepository>();
builder.Services.AddScoped<ITenancyService, TenancyService>();
builder.Services.AddScoped<IContractService, ContractService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddJwtConfiguation(builder.Configuration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
