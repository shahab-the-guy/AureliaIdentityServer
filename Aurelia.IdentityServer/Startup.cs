using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Aurelia.IdentityServer
{
	public class Startup
	{
		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{

			services.AddMvc();

			var apiResources = IdentityServerConfiguration.ApiResources;
			var clients = IdentityServerConfiguration.Clients;

			services.AddIdentityServer()
				.AddDeveloperSigningCredential()
				.AddTestUsers(IdentityServerConfiguration.Users)
				.AddInMemoryClients(clients)
				.AddInMemoryApiResources(apiResources)
				.AddInMemoryIdentityResources(IdentityServerConfiguration.IdentityResources);
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseIdentityServer();

			app.UseStaticFiles();

			app.UseMvcWithDefaultRoute();

		}
	}
}
