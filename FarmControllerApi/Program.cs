using Amazon;
using Amazon.SQS;
using FarmController.Api.Configurations;
using FarmController.Api.Options;
using FarmController.Application.Factories;
using FarmController.Application.Factories.Implementations;
using FarmController.Application.Options;
using FarmController.Application.Ports;
using FarmController.Application.Services.Implementations;
using FarmController.Application.Services.Interfaces;
using FarmController.Application.Validators;
using FarmController.Infrastructure.Mqtt;
using FluentValidation;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MqttOptions>(options => builder.Configuration.GetSection("Mqtt").Bind(options));
builder.Services.Configure<SqsOptions>(options => builder.Configuration.GetSection("Sqs").Bind(options));
var sqsOptions = new SqsOptions();
builder.Configuration.GetSection("Sqs").Bind(sqsOptions);

builder.Services.AddSqsConfiguration(sqsOptions);
builder.Services.AddScoped<IMilkService, MilkService>();
builder.Services.AddSingleton<IMqttCommunicator, MqttCommunicator>();
builder.Services.AddSingleton<INotificationFactory, NotificationFactory>();

builder.Services.AddValidatorsFromAssemblyContaining<MqttInputObjectValidator>();


builder.Services.AddFluentValidationAutoValidation(AutomaticValidationConfigurations.LoadConfigurations);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
