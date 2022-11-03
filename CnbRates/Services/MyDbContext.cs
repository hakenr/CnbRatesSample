using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CnbRates.Model;
using Microsoft.EntityFrameworkCore;

namespace CnbRates.Services
{
	public class MyDbContext : DbContext
	{
		public DbSet<Currency>	Currencies { get; set; }
		public DbSet<ExchangeRate> ExchangeRates { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ExchangeRatesEF;");
		}

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	modelBuilder.Entity<Currency>().HasKey(c => c.Code);
		//	modelBuilder.Entity<ExchangeRate>().HasKey(er => new { er.Day, er.Currency });
		//}
	}
}
