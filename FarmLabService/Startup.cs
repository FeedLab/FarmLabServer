using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using FarmLabService.Dal;
using FarmLabService.DataObjects;
using FarmLabService.Services;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<FarmLabContext>(options =>options.UseSqlServer(Configuration.GetConnectionString("MS_FarmLabConnectionString")));

            services.AddIdentity<UserItem, IdentityRole>();

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
                        OnCreatingTicket = (context) =>
                        {
                            var userEmail = context.Identity.FindFirst(ClaimTypes.Email).Value;

                            return Task.CompletedTask;
                        }
                    };
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
        }
    }
}
