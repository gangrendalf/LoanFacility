using API.Helpers;
using AutoMapper;
using Core.Interfaces;
using Core.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace API
{
  public class Startup
  {
    private readonly IConfiguration _conf;
    public Startup(IConfiguration conf)
    {
      this._conf = conf;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddCors(options =>
        {
          options.AddPolicy(name: "DevCorsPolicy",
            builder =>
            {
                builder.WithOrigins("http://localhost:4200", "https://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

      services.AddControllers();
      services.AddScoped<IScheduler, Scheduler>();
      services.AddScoped<ILoanRepository, LoanRepository>();
      services.AddDbContext<LoanFacilityContext>(x => 
        x.UseSqlite(_conf.GetConnectionString("DefaultConnection")));

      services.AddAutoMapper(typeof(MappingProfiles));

      services.AddSwaggerGen(c => 
      {
        c.SwaggerDoc("v1", new OpenApiInfo () { Title = "Loan Facility API", Version = "v1"});
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors("DevCorsPolicy");

      app.UseAuthorization();

      app.UseSwagger();
      app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Loan Facility v1");
      });

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
