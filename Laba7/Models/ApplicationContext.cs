﻿using Microsoft.EntityFrameworkCore;

namespace Laba7.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
