using Messaging.Kafka;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddProducer<Order>(builder.Configuration.GetSection("Kafka:Order"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/create-order", async (IKafkaProducer<Order> kafkaProducer) =>
{
    await kafkaProducer.ProduceAsync(new Order
    {
        Id = Guid.NewGuid().ToString(),
        Name = "my order"
    }, default);
});

app.Run();
