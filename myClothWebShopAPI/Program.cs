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
    options.Password.RequireDigit = false; // Эта строка отключает требование наличия хотя бы одной цифры в пароле
    options.Password.RequiredLength = 1; // Эта строка устанавливает минимальную длину пароля в 1 символ. То есть, пароль теперь может состоять всего из одного символа.
    options.Password.RequireUppercase = false;  //Эта строка отключает требование наличия хотя бы одной заглавной буквы в пароле.
    options.Password.RequireLowercase = false; //  Эта строка отключает требование наличия хотя бы одной строчной буквы в пароле.
    options.Password.RequireNonAlphanumeric = false; // Эта строка отключает требование наличия хотя бы одного не-буквенно-цифрового символа (например, символов пунктуации) в пароле.

});

var secretKey = builder.Configuration.GetValue<string>("DeveloperSettings:SecretKey");

builder.Services.AddAuthentication(schemes =>
{
    schemes.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; //Этот код устанавливает схему аутентификации по умолчанию на JWTBearer. Это означает, что при аутентификации приложение будет использовать JWT-токены для проверки подлинности.
    schemes.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options => // Здесь настраивается схема аутентификации JWTBearer.
{
    options.RequireHttpsMetadata = false; //  Этот параметр отключает требование HTTPS при передаче JWT-токенов. 
    options.SaveToken = true; // Указывает, что токен следует сохранить в контексте аутентификации после успешной проверки.
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true, // Этот параметр указывает, что токен должен быть проверен на предмет соответствия ключу подписи. 
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey)),     
        ValidateIssuer = false,      //Этот параметр отключает проверку "issuer" (издателя) токена.
        ValidateAudience = false,   //тот параметр отключает проверку "audience" (аудитории) токена. Токены также могут содержать информацию об аудитории
    };
});

builder.Services.AddCors(); // Этот вызов добавляет службу CORS в вашу конфигурацию приложения. Он регистрирует службу, которая будет обрабатывать запросы и ответы CORS.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
    {
        Name = "Authorization", // Это имя параметра заголовка, который будет использоваться для передачи токена. 
        In = ParameterLocation.Header,  // Это местоположение параметра. Здесь указывается, что токен будет передаваться в заголовке.
        Scheme = JwtBearerDefaults.AuthenticationScheme,
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme   //определение безопасности, связанное с схемой аутентификации Bearer Token.
            {
                Reference = new OpenApiReference        // В этой части вы создаете объект OpenApiReference, который указывает на то, что вы ссылаетесь на определенную схему безопасности
                {
                    Type = ReferenceType.SecurityScheme, // указывает, что это относится к схеме безопасности
                    Id = "Bearer" // устанавливается в "Bearer", что является идентификатором вашей схемы безопасности. То есть, это говорит Swagger, что это схема безопасности "Bearer".
                },
                Scheme = "oauth2", 
                Name = "Bearer",    // Этот параметр определяет имя, которое будет использоваться для передачи Bearer Token. Обычно, для Bearer Token, это имя устанавливается в "Bearer". Когда клиент делает запрос, он включает заголовок с именем "Authorization", и значение этого заголовка начинается с "Bearer ", а затем следует сам Bearer Token.
                In = ParameterLocation.Header   //Этот параметр указывает, что Bearer Token будет передаваться в заголовке запроса. Это стандартная практика для Bearer Token, и при аутентификации клиент должен включать токен в заголовке "Authorization".
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

app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()); // разрешает запросы с любыми заголовками, любыми методами HTTP и из любого источника (домена).

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
