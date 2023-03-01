using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MuradAuthServer.Core.Entity;
using MuradAuthServer.Data.EntityConfugiration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MuradAuthServer.Data
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*builder.ApplyConfiguration(new AppUserConfugiration());
            builder.ApplyConfiguration(new ProductConfugiration());
            builder.ApplyConfiguration(new UserRefreshTokenConfugiration());
            
            Burada istesek bir-bir bele yaza bilerik. Istesek hamisini avtomat qebul etmek olar asagidkai kodla
             */

            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
