using Microsoft.EntityFrameworkCore;

using TestCRUD.Models;

namespace TestCRUD.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Credentials> Credentials { get; set; }

		public DbSet<Listing> Listing { get; set; }
	}
}