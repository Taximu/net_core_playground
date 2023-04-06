using Store.Web;
using Store.Web.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app);

var dbHelper = new DbHelper();
dbHelper.ForceCreation();

app.MapGet("/", () => "Hello World!");

app.Run();