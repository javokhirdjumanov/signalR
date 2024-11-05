using Chat.DB;
using Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

_ = builder.ConfigureDefaults("Chat");
_ = builder.ConfiguredDbContext<AppDbContext>("DefaultConnectionString");

var app = builder.Build();
app.ConfigureDefaults();
app.Run();