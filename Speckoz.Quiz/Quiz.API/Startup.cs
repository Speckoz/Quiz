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
        private readonly IHostEnvironment _appHost;

        public Startup(IConfiguration configuration, IHostEnvironment appHost)
        {
            _configuration = configuration;
            _appHost = appHost;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // MySQL
            services.AddDbContext<ApiContext>
            (
                options => options.UseMySql(_configuration["ConnectionString"],
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
            services.AddScoped<IQuestionsStatusRepository, QuestionsStatusRepository>();

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
                app.UseDeveloperExceptionPage();
            }

            // Auto create DB
            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                ApiContext context = serviceScope.ServiceProvider.GetRequiredService<ApiContext>();
                context.Database.Migrate();
            }

            seedingService.Seed();

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}