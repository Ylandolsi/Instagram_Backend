using Instagram_Backend.Abstracts;
using Instagram_Backend.Database;
using Instagram_Backend.Extensions;
using Instagram_Backend.Middlewares;
using Instagram_Backend.Models;
using Instagram_Backend.Services;
using Instagram_Backend.Options;
using Instagram_Backend.Processors;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Instagram_Backend.Services.ExternalServices;
using Instagram_Backend.Hubs;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddOpenApi();

builder.Services.Configure<JwtOptions>(
    builder.Configuration.GetSection(JwtOptions.JwtOptionsKey));





builder.Services.AddIdentity<User, IdentityRole<Guid>>(
    o =>
    {
        o.User.RequireUniqueEmail = true;
        o.SignIn.RequireConfirmedAccount = false;
        o.Password.RequiredLength = 6;
        o.Password.RequireDigit = true;
        o.Password.RequireLowercase = true;
        o.Password.RequireUppercase = true;
        o.Password.RequireNonAlphanumeric = false;
    }
)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddApiEndpoints();


builder.Services.AddDbContext<ApplicationDbContext>(o =>
    o.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))) ; 



builder.Services.AddCorsPolicy();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureCloudinary(builder.Configuration);
builder.Services.AddSignalR();

builder.Services.AddScoped<IAuthTokenProcessor,AuthTokenProcessor>();
builder.Services.AddScoped< ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<IAccountService,AccountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IImageService , ImageService>() ;
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<ILikeService, LikeService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<INotificationService, NotificationService>();


builder.Services.AddScoped<CloudinaryService>();



builder.Services.AddAuth(builder.Configuration);
builder.Services.AddAuthorization();

builder.Services.AddHttpContextAccessor(); 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(opt =>
    {
        opt.WithTitle("InstaBackend API");
    });
}

app.UseGlobalExceptionHandler();

app.UseCors("DefaultPolicy");

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();
app.MapHub<NotificationHub>("/hubs/notifications");

app.Run();
