﻿using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;
using static IdentityServer4.IdentityServerConstants;

namespace Aurelia.IdentityServer
{
	public static class Config
	{

		public static IEnumerable<IdentityResource> IdentityResources =>
				new List<IdentityResource>() {
					new IdentityResources.OpenId() ,
					new IdentityResources.Profile()
				};

		public static IEnumerable<ApiResource> ApiResources =>

				new List<ApiResource>() {
					new ApiResource( ApiScopes.AureliaApiScope , "Aurelia WebApi") {

						ApiSecrets = { new Secret( "apisecret".Sha256() ) }
					}
				};

		public static List<TestUser> Users => new List<TestUser>() {
																new TestUser() {
																	SubjectId = "1D9F016D-58A9-4256-85A1-188ACE29DB44",
																	Username = "shahab" ,
																	Password = "password"
																}
		};



		// those who want to get access to protected resources, such as api or identity resources
		public static IEnumerable<Client> Clients => new List<Client>(){

			new Client() {

				ClientName = "Aurelia SPA Application",
				ClientId = "aurelia_web_api_client_spa",

				ClientSecrets = new []{ new Secret("secret".Sha256()) } , // this is nott required since we will redirect the user to the identity server login page and we do not want back-end token validation

				AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,

				AllowAccessTokensViaBrowser = true ,

				RedirectUris = { "https://localhost:44380/callback.html" } ,
				PostLogoutRedirectUris = { "https://localhost:44380/logout.html" },
				AllowedCorsOrigins = { "https://localhost:44380/" } ,

				AllowedScopes = {
					StandardScopes.OpenId ,
					StandardScopes.Profile , 

					ApiScopes.AureliaApiScope
				}
			}

		};


	}
}