using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DL;
using P1BL;
using Microsoft.EntityFrameworkCore;


namespace WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        

        // This method gets called by the runtime. Use this method to add services to the container.
        //*********NOTES***********
        //transient,a new object is created everytime you call
        //scoped,a new object per request
        //singleton, share an instance across request -. could lead to other requests waiting
        //container that holds the resources that the app needs
        public void ConfigureServices(IServiceCollection services)
        {

            
            
            services.AddControllersWithViews();

            

            services.AddDbContext<P1DBContext>(options =>
            options.UseNpgsql(Configuration.GetConnectionString("P1DB")));
            //secondly, you need to configure our db here, and add the db context as a dependency
            //finally, add all the other dependencies like bl and repos
            //this uses inversion of control, which means that we specify what kind of 
            //concrete classes implement interfaces
            services.AddScoped<IRepo, DBRepo>();
            services.AddScoped<IBL, BL>();
            //^thats the dependency injection. registering the dependencies that our controllers need
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            

         

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
