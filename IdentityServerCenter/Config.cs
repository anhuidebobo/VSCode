using System.Collections.Generic;
using IdentityServer4.Models;
using IdentityServer4.Test;

namespace IdentityServerCenter
{
    public class Config
    {
        public static IEnumerable<ApiResource> GetResources()
        {
            return new List<ApiResource>
            {
                new ApiResource("api","My Api"),
                new ApiResource("api1","My Api")
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>
            {
                new Client
                {
                    ClientId="clientId",
                    AllowedGrantTypes=GrantTypes.ClientCredentials,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    AllowedScopes={"api"}
                },
                new Client
                {
                    ClientId="pwdClient",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,
                    ClientSecrets={
                        new Secret("secret".Sha256())
                    },
                    RequireClientSecret=false,
                    AllowedScopes={"api"}
                }
            };
        }


        public static List<TestUser> GetTestUser()
        {
            return new List<TestUser>
            {
                new TestUser{
                    SubjectId="1",
                    Username="bobo",
                    Password="123456"
                }
            };

        }
    }
}