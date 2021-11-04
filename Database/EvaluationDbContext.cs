using EvaluationBizsol.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvaluationBizsol.Database
{
    public class EvaluationDbContext : DbContext
    {
        public EvaluationDbContext(DbContextOptions<EvaluationDbContext> options) : base(options) { } 

       public DbSet<DeveloperDM> Developer { get; set; }
    }
}
