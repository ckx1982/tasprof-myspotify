using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySpotifyMVC.Extensions;
using Tasprof.Apps.MySpotifyDroid;
using Tasprof.Apps.MySpotifyDroid.Services.Identity;
using Tasprof.Apps.MySpotifyDroid.Services.Request;
using Tasprof.Apps.MySpotifyDroid.Services.Spotify;

namespace MySpotifyMVC
{
    public class Startup
    {
        private const string SpotifyAuthenticationScheme = "Spotify";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                        o =>
                        {
                            o.LoginPath = new PathString("/login");
                            o.LogoutPath = new PathString("/logout");
                        })
                .AddSpotify(
                        SpotifyAuthenticationScheme,
                        o =>
                        {
                            o.ClientId = GlobalSettings.Instance.ClientId;
                            o.ClientSecret = GlobalSettings.Instance.ClientSecret;
                            o.Scope.Add("playlist-read-private");
                            o.Scope.Add("playlist-read-collaborative");
                            o.SaveTokens = true;
                        });

            services.AddRouting(options => { options.LowercaseUrls = true; });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddHttpContextAccessor();

            services.AddScoped<ISpotifyService, SpotifyService>();
            //services.AddScoped<ISpotifyService, SpotifyMockService>();
            services.AddScoped<IRequestService, RequestService>();
            services.AddScoped<IIdentityService, IdentityService>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSpotifyInvalidRefreshTokenExceptionHandler("/login");
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseAuthentication();

            app.Map(
              "/login",
              builder =>
              {
                  builder.Run(
                      async context =>
                      {
                            // Return a challenge to invoke the Spotify authentication scheme
                            await context.ChallengeAsync(SpotifyAuthenticationScheme, properties: new AuthenticationProperties() { RedirectUri = "/", IsPersistent = true });
                      });
              });

            // Listen for requests on the /logout path, and sign the user out
            app.Map(
                "/logout",
                builder =>
                {
                    builder.Run(
                        async context =>
                        {
                            // Sign the user out of the authentication middleware (i.e. it will clear the Auth cookie)
                            await context.SignOutAsync();

                            // Redirect the user to the home page after signing out
                            context.Response.Redirect("/");
                        });
                });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
