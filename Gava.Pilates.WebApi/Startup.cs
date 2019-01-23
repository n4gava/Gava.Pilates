using Gava.Framework.DataAccess;
using Gava.Pilates.Business.Business;
using Gava.Pilates.Business.Entities;
using Gava.Pilates.WebApi.Data;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;

namespace Gava.Pilates.WebApi
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
            services.AddDbContext<AppDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, AppDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<PatientsBusiness>();
            services.AddOData();
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
            app.UseMvc(b =>
            {
                b.Count().Filter().OrderBy().Expand().Select().MaxTop(null);
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Patient>(nameof(Patient));
            return builder.GetEdmModel();
        }
    }
}
