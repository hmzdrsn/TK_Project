using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "E-Ticaret API GATEWAY",
        Description = "E-Ticaret Api Uygulamasý",
        Contact = new OpenApiContact
        {
            Name = "Hamza Dursun",
            Email = "hmzdrsn64@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/hmzdrsn/")
        },
        License = new OpenApiLicense
        {
            Name = "Api Lisans",
            Url = new Uri("https://www.linkedin.com/in/hmzdrsn/")
        }
    });
});

//yarp registration
builder.Services.AddReverseProxy().LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//Yarp
app.MapReverseProxy();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
