using Microsoft.EntityFrameworkCore;
using WhooberInfrastructure.Data;

namespace WhooberServiceTests
{
    public class TestingDbContext : WhooberContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("TestingWhooberDbContext");
        }
    }
}