using Microsoft.EntityFrameworkCore;
using My_workeplae.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
                
        }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Managers> Managers { get; set; }
    }
}
