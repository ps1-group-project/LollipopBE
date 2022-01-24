
namespace Lollipop.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Lollipop.Persistence.Repositories;
    using Lollipop.Application.Repository;
    using Lollipop.Persistence.DbContext;
    using Lollipop.Persistence.EmailSender;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using MediatR;
    using Lollipop.Application.Keyword.Commands;
    using Microsoft.OpenApi.Models;
    using Microsoft.AspNetCore.Http;
    using Lollipop.Core.Models;
    using Lollipop.Persistence.TokenService;
    using Lollipop.Application.MapperProfile;
    using Lollipop.Persistence.Services;
    using Lollipop.Application.Service;

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
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
          .AddCookie(options =>
          {
              options.LoginPath = "/account/google-login";
          })
          .AddGoogle(options =>
          {
              options.ClientId = "996066867520-1npd5tcf3hqljfv8jj5spri40srqm2ro.apps.googleusercontent.com";
              options.ClientSecret = "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";
          });
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(XmlConfigurationExtensions => XmlConfigurationExtensions.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<LollipopDbContext>(
                //options => options.UseSqlServer(Configuration.GetConnectionString("local_sql_lollipop")
                options => options.UseNpgsql(Configuration.GetConnectionString("postgre_sql_lollipop")
                
                )) ;
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LollipopDbContext>()
                .AddDefaultTokenProviders();
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lollipop.API", Version = "v1" }); });
            services.AddMediatR(typeof(CreateKeywordCommand).Assembly);
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<IMailService, MailService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lollipop.API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lollipop.API v1"));
                //app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                //.WithOrigins("https://projektz-46d76.web.app", "http://localhost:3000")
                //.AllowAnyOrigin()
                .SetIsOriginAllowed(_ => true)
                .AllowCredentials()
                );

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRoles(serviceProvider).Wait();
        }
        private async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            List<string> roleNames = this.Configuration.GetSection("Roles").Get<List<string>>();

            foreach(string role in roleNames)
            {
                var roleExists = await roleManager.RoleExistsAsync(role);
                if (!roleExists)
                {
                    var roleResult = await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

        }
    }
}
