using Store.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.InitializeDatabase(builder.Configuration);
builder.Services.AddControllers();

var app = builder.Build();
app.MapGet("/", () => "Hello World!");

app.Run();
