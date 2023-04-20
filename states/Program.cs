using States.Domains.Contract;
using States.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IAcreServices>(new ReaderServices("ac"));
builder.Services.AddSingleton<ISaoPauloServices>(new ReaderServices("sp"));
builder.Services.AddSingleton<ITocantinsServices>(new ReaderServices("to"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment()){
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();