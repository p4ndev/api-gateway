using Forecast.Domains.Contract;
using Forecast.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IForecastServices, ForecastServices>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();