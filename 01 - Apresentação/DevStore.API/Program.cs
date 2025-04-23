using DevStore.Application.Commands.CreateSale;
using DevStore.API.Middlewares;
using DevStore.Infra.Persistence;
using DevStore.Infra.Repositories;
using DevStore.Infra.Messaging;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using DevStore.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DevStoreDbContext>(opt =>
    opt.UseInMemoryDatabase("devstore"));

builder.Services.AddScoped<ISaleRepository, SaleRepository>();

builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<CreateSaleCommand>());

builder.Services.AddScoped(typeof(INotificationHandler<>), typeof(EventPublisher<>));

builder.Services.AddValidatorsFromAssemblyContaining<CreateSaleCommand>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
