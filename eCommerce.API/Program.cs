using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Core.Validators;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;
using System.Text.Json.Serialization;
//using eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);

//add infrastructure to service collection
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//add controllers to service collection
builder.Services.AddControllers().AddJsonOptions(
    options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddAutoMapper(cfg => { }, typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddFluentValidationAutoValidation();
var app = builder.Build();
app.UseExceptionHandlingMiddleware();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
