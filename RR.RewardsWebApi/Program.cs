using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RR.DataBaseConnect;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//



builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>

{

    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,

        ValidateAudience = false,

        ValidateIssuer = false,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(
         builder.Configuration.GetSection("AppSettings:Token").Value!))


    };

});

builder.Services.AddDbContext<DataBaseAccess>(option =>
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
