﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IOTBackend.Models
{
    public class DatabaseContext:IdentityDbContext<User>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }

        public DbSet<Light> Lights { get; set; }
    }
}
