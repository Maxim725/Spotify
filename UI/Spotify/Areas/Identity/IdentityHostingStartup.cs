using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Spotify.Areas.Identity.Data;
using Spotify.Domain.Entities.Identity;

[assembly: HostingStartup(typeof(Spotify.Areas.Identity.IdentityHostingStartup))]
namespace Spotify.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            /* builder.ConfigureServices((context, services) => {
                services.AddDbContext<SpotifyIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("SpotifyIdentityDbContextConnection")));

                services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<SpotifyIdentityDbContext>();
            }); */
        }
    }
}