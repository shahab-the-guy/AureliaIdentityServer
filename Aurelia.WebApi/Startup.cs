using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Aurelia.WebApi {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddMvc ().SetCompatibilityVersion (CompatibilityVersion.Version_2_1);

            services.AddAuthentication (IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication (options => {
                    // the identity server url
                    options.Authority = "https://localhost:44345/";

                    // api resource information defined in identity server
                    options.ApiName = "aurelia_web_api";
                    options.ApiSecret = "apisecret";

                    // whether the connection betweeen this resource and the ISP be secure or not
                    options.RequireHttpsMetadata = true;
                });
                
            services.AddCors (build => {
                build.AddPolicy ("corsenabler", p => {
                    p.AllowAnyOrigin().AllowAnyMethod ().AllowAnyHeader ();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {

            app.UseCors ("corsenabler");

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }


            app.UseAuthentication ();

            app.UseHttpsRedirection ();
            app.UseMvc ();
        }
    }
}