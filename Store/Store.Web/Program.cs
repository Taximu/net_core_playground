using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;
using Store.Core.DbContext;
using Store.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<LiteDbOptions>(
    builder.Configuration.GetSection(LiteDbOptions.SectionName));

builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers(options =>
{
    options.ModelMetadataDetailsProviders.Add(new SystemTextJsonValidationMetadataProvider());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options=> {
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Store API - V1", Version = "v1" });
    options.SwaggerDoc("v2", new OpenApiInfo { Title = "Store API - V2", Version = "v2" });
});

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new ApiVersion(1, 0);
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
        new HeaderApiVersionReader("x-api-version"),
        new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

app.ConfigureExceptionMiddleware();
app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
    options.RoutePrefix = string.Empty;
});
app.MapControllers();

app.Run();
