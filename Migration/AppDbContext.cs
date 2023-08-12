using CalculatorAA.Models;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace CalculatorAA.Data
{
    public class AppDbContext : DbContext  
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<CalculatorModel> CalculatorModels { get; set; }
    }
}
