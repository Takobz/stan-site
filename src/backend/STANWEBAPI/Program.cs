using System.Text.Json;
using STANWEBAPI.Data.Options;
using STANWEBAPI.Extensions;
using STANWEBAPI.Infrastructure.ServiceCollectionExtensions;
using STANWEBAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDTOValidatorFilters();

builder.Services.Configure<MongoDBOptions>(
   builder.Configuration.GetSection(MongoDBOptions.SectionName)
);

var mongoDBOptions = new MongoDBOptions();
var options = builder.Configuration.GetSection(MongoDBOptions.SectionName);
options.Bind(mongoDBOptions);
builder.Services.AddEventStoreData(
    mongoDBOptions
);

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    })
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
    }
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
