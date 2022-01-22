using Microsoft.EntityFrameworkCore;

namespace WhooberInfrastructure.Data
{
    public class WhooberContext : DbContext
    {
        public WhooberContext() : base()
        {
        }

        public WhooberContext(DbContextOptions<WhooberContext> options)
            : base(options)
        {
        }
    }
}