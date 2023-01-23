using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Debit_Credit.Models
{
    public class DebitDbContext:DbContext
    {
        public DebitDbContext(DbContextOptions<DebitDbContext> options):base(options)
        {
                
        }
        public DbSet<DebitModelsClass> DebitTB { get; set; }


        public DbSet<CreditModelsClass> CreditTB { get; set; }

        public DbSet<AmountTkClass> AmountTB { get; set; }
    }
}
