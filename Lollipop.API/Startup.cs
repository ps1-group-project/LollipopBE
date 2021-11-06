namespace Lollipop.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.HttpsPolicy;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Lollipop.Persistence.Repositories;
    using Lollipop.Application.Repository;
    using Lollipop.Persistence.DbContext;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using MediatR;
    using Lollipop.Application.Keyword.Commands;
    using Microsoft.OpenApi.Models;

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
            services.AddControllersWithViews();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<LollipopDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("lollipop_sql")));
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lollipop.API", Version = "v1" }); });
            services.AddMediatR(typeof(CreateKeywordCommand).Assembly);

            /*            The first thing we do is call AddAuthentication and set up a default scheme.As we are not using Identity for this example, we will use the CookieAuthenticationDefaults scheme.
            */
            services.AddAuthentication(options =>
           {
               options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
           })
           //Next, using the AddCookie method, we need to set up a default path for where a user is redirected when they require authentication. We have set this up as /account/google-login, and we will set this up in a bit.
           .AddCookie(options =>
           {
               options.LoginPath = "/account/google-login";
           })
           //Finally, using the AddGoogle method, we provide our client ID and client secret which was created when we set up a project in Google Cloud Platform.
           .AddGoogle(options =>
           {
               options.ClientId = "996066867520-str9lnbhhit09b64oskdngt47oqcom1n.apps.googleusercontent.com";
               options.ClientSecret = "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";
           });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //w oknie przegl�darki co� w stylu localhost:PORT/swagger/index.html by dosta� si�
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UberQuiz.API v1"));
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
