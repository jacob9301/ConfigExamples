var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string allowedHosts = builder.Configuration["AllowedHosts"];

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "AllowOriginsFromAppsettings",
        policy =>
        {
            policy.WithOrigins(allowedHosts);
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOriginsFromAppsettings");

app.UseAuthorization();

app.MapControllers();

app.Run();