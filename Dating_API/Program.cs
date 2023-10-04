using Dating_API.Data;
using Dating_API.Extensions;
using Dating_API.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddServicesCollection(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors(p => p.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

if (app.Environment.IsDevelopment())
{
   app.UseSwagger();
   app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
using var scope=app.Services.CreateScope();
var services=scope.ServiceProvider;
try{
   var context=services.GetRequiredService<DataContext>();
   await context.Database.MigrateAsync();
   await seed.SeedUser(context);
}
catch(Exception ex){
   var logger=services.GetService<ILogger<Program>>();
   logger.LogError(ex,"An error occurred during migration");
}

app.Run();
