using Microsoft.EntityFrameworkCore;
using WhooberInfrastructure.Data;

namespace WhooberServiceTests
{
    public class TestingDbContext : WhooberContext
    {
        public TestingDbContext(DbContextOptions<WhooberContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestingWhooberDbContext");
        }
    }
}