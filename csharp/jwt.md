# Working with JWTs

.NET 7 

Nuget `Microsoft.AspNetCore.Authentication.JwtBearer`

In Program.cs:

```csharp
builder.Services.AddAuthentication()
    .AddJwtBearer();
```

For the Swagger stuff in Program.cs

```csharp
builder.Services.AddSwaggerGen(config =>
{
    config.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });
    config.AddSecurityRequirement(new OpenApiSecurityRequirement()
{
    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
            }
        },
        new List<string>()
    }
});
});

```

For the stuff in the `appsettings.development.json` just go to a command prompt (in the project directory and run)

```shell
dotnet user-jwts create
```