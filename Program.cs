namespace Group_4_Intake_44
{
    public class Program
    {
        public static async Task Main(string[] args)
        { 
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //1- Database Context Service
            builder.Services.AddDbContext<gis44_SupplyChainContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefualtDbConnection"));
            });

            //2- Role Services
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<gis44_SupplyChainContext>();

            //3- Repository Add Scoop Services
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IStoreRepositry, StoreRepository>();
            builder.Services.AddControllers();

            //4- Registration Passsword Validation 
            builder.Services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            });

            //5- Add Authentication (JWT)
            var key = builder.Configuration.GetValue<string>("ApiSetting:Secret");
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(key))
                };
            });

            //6- Cors Enable
            builder.Services.AddCors();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            //---------------------- Swagger UI ----------------------
            builder.Services.AddSwaggerGen(swagger =>
            {
                //This IS To Generate The Defualt UI Of Swagger Documention 
                swagger.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "V1",
                    Title = "E-Commerce Project BackEnd",
                    Description = "ITI Project"
                });

                //To Enable Authorization Using Swagger (JWT)
                swagger.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
                                  "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
                                  "Example: \"Bearer 12345abcdef\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = JwtBearerDefaults.AuthenticationScheme,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                });

                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement()
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
                        new string[] {}
                    }
                });
            });

            //--------------------------------------------------------------------

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

                // Un commend it When Deployed // 
            //else
            //{
            //    app.UseSwaggerUI(c =>
            //    {
            //        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            //        c.RoutePrefix = string.Empty;
            //    });
            //}

            app.UseCors(o => o.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
           
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
