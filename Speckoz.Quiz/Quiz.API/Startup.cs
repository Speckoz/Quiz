using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using Quiz.API.Data;
using Quiz.API.Repository;
using Quiz.API.Repository.Interfaces;

using System.Text;

namespace Quiz.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Sqlite
            services.AddDbContext<ApiContext>
            (
                options => options.UseSqlite(_configuration["ConnectionString"],
                builder => builder.MigrationsAssembly("Quiz.API"))
            );

            // JWT
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "Speckoz",
                    ValidAudience = "Speckoz",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]))
                });

            // Repository
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            services.AddScoped<IQuestionSuggestionRepository, QuestionSuggestionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // SeedingService
            services.AddScoped<SeedingService>();

            services.AddControllers();

            services.AddOptions();

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, SeedingService seedingService)
        {
            if (env.IsDevelopment())
            {
                // Auto create DB
                using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    ApiContext context = serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
                    context.Database.Migrate();
                }
                app.UseDeveloperExceptionPage();
                seedingService.Seed();
            }

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}