using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);
_ = builder.ConfigureDefaults("Chat");

var app = builder.Build();
app.ConfigureDefaults();

app.Run();