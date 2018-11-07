using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using iCalServer.Authentication;
using iCalServer.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace iCalServer
{
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSingleton<ICalendarService, MockCalendarService>();
            services.AddScoped<IiCalBuilderService, iCalBuilderService>();
            services.AddAuthentication(BasicAuthenticationDefaults.AuthenticationScheme)
                .AddBasic(options =>
                {
                    options.Realm = "iCalServer";
                    options.Events = new BasicAuthenticationEvents
                    {
                        OnValidateCredentials = context =>
                        {
                            if (context.Password == BasicAuthenticationDefaults.THE_PASSWORD)
                            {
                                var claims = new[]
                                {
                                    new Claim(
                                        ClaimTypes.NameIdentifier,
                                        context.Username,
                                        ClaimValueTypes.String,
                                        context.Options.ClaimsIssuer
                                    ),
                                    new Claim(
                                        ClaimTypes.Name,
                                        context.Username,
                                        ClaimValueTypes.String,
                                        context.Options.ClaimsIssuer
                                    )
                                };

                                context.Principal = new ClaimsPrincipal(new ClaimsIdentity(claims, context.Scheme.Name));

                                context.Success();
                            }

                            return Task.CompletedTask;
                        }
                    };
                });
         }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
