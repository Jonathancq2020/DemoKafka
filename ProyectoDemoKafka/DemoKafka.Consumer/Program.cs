using DemoKafka.DomainModel.ValueObjects;
using DemoKafka.PersistenceEFCore;
using DemoKafka.Services;
using DemoKafka.Services.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<KafkaSettings>(builder.Configuration.GetSection("KafkaSettings"));
builder.Services.AddSingleton<IHostedService, ConsumerService>();

builder.Services
                .AddInfrastructureServices()
                .AddPersistenceEFCore(builder.Configuration, "TareaKafka");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
