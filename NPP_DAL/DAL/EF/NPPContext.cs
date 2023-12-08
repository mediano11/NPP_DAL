using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.EF
{
    public class NPPContext
        : DbContext
    {
        public DbSet<NPP> Npps { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Request> Requests { get; set; }

        public NPPContext(DbContextOptions options)
            : base(options)
        {
        }

    }
}