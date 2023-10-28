using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using myClothWebShopAPI.Data;
using myClothWebShopAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("SQLConnection")); 
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false; // ��� ������ ��������� ���������� ������� ���� �� ����� ����� � ������
    options.Password.RequiredLength = 1; // ��� ������ ������������� ����������� ����� ������ � 1 ������. �� ����, ������ ������ ����� �������� ����� �� ������ �������.
    options.Password.RequireUppercase = false;  //��� ������ ��������� ���������� ������� ���� �� ����� ��������� ����� � ������.
    options.Password.RequireLowercase = false; //  ��� ������ ��������� ���������� ������� ���� �� ����� �������� ����� � ������.
    options.Password.RequireNonAlphanumeric = false; // ��� ������ ��������� ���������� ������� ���� �� ������ ��-��������-��������� ������� (��������, �������� ����������) � ������.

});

var secretKey = builder.Configuration.GetValue<string>("DeveloperSettings:SecretKey");

builder.Services.AddAuthentication(schemes =>
{
    schemes.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //���� ��� ������������� ����� �������������� �� ��������� �� JWTBearer. ��� ��������, ��� ��� �������������� ���������� ����� ������������ JWT-������ ��� �������� �����������.
    schemes.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => // ����� ������������� ����� �������������� JWTBearer.
{
    options.RequireHttpsMetadata = false; //  ���� �������� ��������� ���������� HTTPS ��� �������� JWT-�������. 
    options.SaveToken = true; // ���������, ��� ����� ������� ��������� � ��������� �������������� ����� �������� ��������.
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // ���� �������� ���������, ��� ����� ������ ���� �������� �� ������� ������������ ����� �������. 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),     
        ValidateIssuer = false,      //���� �������� ��������� �������� "issuer" (��������) ������.
        ValidateAudience = false,   //��� �������� ��������� �������� "audience" (���������) ������. ������ ����� ����� ��������� ���������� �� ���������
    };
});

builder.Services.AddCors(); // ���� ����� ��������� ������ CORS � ���� ������������ ����������. �� ������������ ������, ������� ����� ������������ ������� � ������ CORS.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization", // ��� ��� ��������� ���������, ������� ����� �������������� ��� �������� ������. 
        In = ParameterLocation.Header,  // ��� �������������� ���������. ����� �����������, ��� ����� ����� ������������ � ���������.
        Scheme = JwtBearerDefaults.AuthenticationScheme,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme   //����������� ������������, ��������� � ������ �������������� Bearer Token.
            {
                Reference = new OpenApiReference        // � ���� ����� �� �������� ������ OpenApiReference, ������� ��������� �� ��, ��� �� ���������� �� ������������ ����� ������������
                {
                    Type = ReferenceType.SecurityScheme, // ���������, ��� ��� ��������� � ����� ������������
                    Id = "Bearer" // ��������������� � "Bearer", ��� �������� ��������������� ����� ����� ������������. �� ����, ��� ������� Swagger, ��� ��� ����� ������������ "Bearer".
                },
                Scheme = "oauth2", 
                Name = "Bearer",    // ���� �������� ���������� ���, ������� ����� �������������� ��� �������� Bearer Token. ������, ��� Bearer Token, ��� ��� ��������������� � "Bearer". ����� ������ ������ ������, �� �������� ��������� � ������ "Authorization", � �������� ����� ��������� ���������� � "Bearer ", � ����� ������� ��� Bearer Token.
                In = ParameterLocation.Header   //���� �������� ���������, ��� Bearer Token ����� ������������ � ��������� �������. ��� ����������� �������� ��� Bearer Token, � ��� �������������� ������ ������ �������� ����� � ��������� "Authorization".
            }, new List<string>()
        }
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

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // ��������� ������� � ������ �����������, ������ �������� HTTP � �� ������ ��������� (������).

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
