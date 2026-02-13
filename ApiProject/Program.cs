using ApiProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI for data layer. 
builder.Services.AddSingleton<IMessageStore, MessageStore>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    
    app.UseSwagger();
    app.UseSwaggerUI();
    

}

//app.UseHttpsRedirection();

// We don't add /api/v1 here.  We do this at the controller level.  This allows us to have multiple versions of the API running simultaneously.
app.MapControllers();
app.Run();
