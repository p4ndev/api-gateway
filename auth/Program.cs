using Auth.Domains.Contract;
using Auth.Repository;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ICryptoProvider>(new CryptoProvider("p_q1YM-j#k3@y"));
builder.Services.AddSingleton<IStorageRepository, StorageRepository>();

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