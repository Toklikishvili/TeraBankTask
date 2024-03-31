using TeraBankTask.API.Extensions;
using TeraBankTask.Aplication.Extensions;
using TeraBankTask.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationLayer();
builder.Services.AddPersistenceLayer(builder.Configuration);
builder.AddPresentationLayer();

var app = builder.Build();
app.AppConfiguration();
app.Run();
