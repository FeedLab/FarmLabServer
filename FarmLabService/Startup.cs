using System;
using System.Security.Claims;
using FarmLabService.Dal;
using FarmLabService.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FarmLabService
{
    public enum ErrorCode
    {
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }

    public class Startup
    {
        private ServiceProvider _services;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

        //    services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<FarmLabContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("MS_FarmLabConnectionString");

                if (string.IsNullOrEmpty(connectionString))
                {
                    connectionString = Environment.GetEnvironmentVariable("MS_FarmLabConnectionString");
                }

                options.UseSqlServer(connectionString);
            //    options.UseSqlServer("Server=tcp:farmlabdbserver.database.windows.net,1433;Initial Catalog=FarmLabDb;Persist Security Info=False;User ID=Jompa67;Password=yaa2Jonny;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
     //           options.UseSqlServer(connectionString);
            });

      //      services.AddIdentity<UserItemXxxx, IdentityRole>();

            services
                .AddAuthentication(v =>
                {
                    v.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
                    v.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
                })
                .AddGoogle(googleOptions =>
                {
                    googleOptions.ClientId = "441250064983-ettrc7jm7q26clr7aj3di3fr4r0s46le.apps.googleusercontent.com";
                    googleOptions.ClientSecret = "rWYnVfgRbg-vKuhHGsypozJ8";
                    googleOptions.Events = new OAuthEvents()
                    {
                        OnCreatingTicket = async (context) =>
                        {
                            var token = context.AccessToken;
                            var userEmail = context.Identity.FindFirst(ClaimTypes.Email).Value;
                            var userName = context.Identity.Name;

                            var userRepository = _services.GetRequiredService<IUserRepository>();

                            //await userRepository.InsertAsync(new UserItemXxxx
                            //{
                            //    Email = userEmail,
                            //    Name = userName,
                            //    Token = token,
                            //    CreateDate = DateTime.UtcNow
                            //});
                        }
                    };

                    _services = services.BuildServiceProvider();
                });

            //    .AddEntityFrameworkStores<FarmLabContext>()
            //    .AddDefaultTokenProviders();

            // services.AddAuthentication().AddGoogle(googleOptions =>
            // {
            //     googleOptions.ClientId = "441250064983-ettrc7jm7q26clr7aj3di3fr4r0s46le.apps.googleusercontent.com";
            //     googleOptions.ClientSecret = "rWYnVfgRbg-vKuhHGsypozJ8";
            ////     googleOptions.Scope.Add(CalendarService.Scope.CalendarReadonly); //"https://www.googleapis.com/auth/calendar.readonly"
            //     googleOptions.AccessType = "offline"; //request a refresh_token
            //     googleOptions.Events = new OAuthEvents()
            //     {
            //         OnCreatingTicket = async (context) =>
            //         {
            //             var userEmail = context.Identity.FindFirst(ClaimTypes.Email).Value;

            //             //var tokenResponse = new TokenResponse()
            //             //{
            //             //    AccessToken = context.AccessToken,
            //             //    RefreshToken = context.RefreshToken,
            //             //    ExpiresInSeconds = (long)context.ExpiresIn.Value.TotalSeconds,
            //             //    IssuedUtc = DateTime.UtcNow
            //             //};

            //             //await dataStore.StoreAsync(userEmail, tokenResponse);
            //         }
            //     };
            // });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder application, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }

            application
                .UseAuthentication()
                .UseMvc();

            //using (var serviceScope = application.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            //{
            //    var context = serviceScope.ServiceProvider.GetRequiredService<FarmLabContext>();
            //    context.Database.Migrate();
            //}
        }
    }
}
