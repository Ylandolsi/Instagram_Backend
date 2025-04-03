using Instagram_Backend.Database;
using Instagram_Backend.Extensions;
using Instagram_Backend.Middlewares;
using Instagram_Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();
builder.Services.AddSwaggerGenWithAuth();

builder.Services.AddIdentityCore<User>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();


builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))) ; 

builder.Services.AddAuthorization();
builder.Services.AddAuth();

builder.Services.AddCorsPolicy();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

app.UseGlobalExceptionHandler();


app.UseCors("DefaultPolicy");

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();


app.Run();

// // claimsprinciapl 
// app.MapGet("users/me", async (ClaimsPrincipal claims, ApplicationDbContext context) =>
//     {
//         string userId = claims.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

//         return await context.Users.FindAsync(userId);
//     })
//     .RequireAuthorization();
