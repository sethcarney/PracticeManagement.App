﻿using Microsoft.EntityFrameworkCore;
using PracticeManagement.Library.Models;

namespace PracticeManagement.API.Database
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

       
    }
}
