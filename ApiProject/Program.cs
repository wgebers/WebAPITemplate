using ApiProject.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
   .AddMicrosoftIdentityWebApi(builder.Configuration);


// DI for data layer. 
builder.Services.AddSingleton<IMessageStore, MessageStore>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.UseSwagger();
    app.UseSwaggerUI();
    

}
// Enable auth
app.UseAuthentication();
app.UseAuthorization();
//app.UseHttpsRedirection();

// We don't add /api/v1 here.  We do this at the controller level.  This allows us to have multiple versions of the API running simultaneously.
app.MapControllers();
app.Run();
