using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpAdv.Model;

namespace CSharpAdv.Data
{
    internal class ClubMemgershipDbContext
    {
        protected override void OnConfiguring(DbContextOptionBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
            base.OnCofiguring(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
    }
}
