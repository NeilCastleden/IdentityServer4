// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServerHost.Configuration
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            var clients = new List<Client>();

            //clients.AddRange(ClientsConsole.Get());
            //clients.AddRange(ClientsWeb.Get());

            clients.Add(
            new Client
            {
                ClientId = "cirrus-web",
                ClientName = "Business Fitness Web Server",
                RequireClientSecret = false,
                AllowedGrantTypes = GrantTypes.Code,
                RequirePkce = true,
                AllowAccessTokensViaBrowser = true,
                RequireConsent = false,

                RedirectUris = { "https://localhost:44331", "https://localhost:44331/signin-callback", "https://localhost:44331/assets/silent-callback.html" },
                PostLogoutRedirectUris = { "https://localhost:44331" },//{ "https://localhost:44331/signout-callback" },
                AllowedCorsOrigins = { "https://localhost:44331", "https://localhost:44318", },

                AllowedScopes =
                    {
                        IdentityServer4.IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Profile,
                        IdentityServer4.IdentityServerConstants.StandardScopes.Email,
                        "cirrus-api",
                        //"roles",
                    },
                AccessTokenLifetime = 600,

                ClientSecrets =
                    {
                        new Secret("dev-secret".Sha256())
                    },

                AllowOfflineAccess = true,
                AlwaysIncludeUserClaimsInIdToken = true,
            }

            );


            return clients;
        }
    }
}