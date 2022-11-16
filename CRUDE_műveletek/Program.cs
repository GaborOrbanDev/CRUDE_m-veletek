var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles();
app.MapControllers();
app.UseStaticFiles();

app.Run();
