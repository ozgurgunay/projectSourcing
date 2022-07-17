using ESourcing.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ESourcing.Infrastructure.Data
{
    public class WebAppContext : IdentityDbContext<AppUser>
    {
        public WebAppContext(DbContextOptions<WebAppContext> options) : base(options)
        {
        }

        public DbSet<AppUser> AppUsers { get; set; }

    }
}
//docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=123456" -p 1433:1433 --name WebAppDb - d mcr.microsoft.com / mssql / server:2019 - latest
