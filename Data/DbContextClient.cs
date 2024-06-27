using EdenredTest.Model;
using Microsoft.EntityFrameworkCore;

namespace EdenredTest.Data
{
    public class DbContextClient: DbContext
    {
        public DbContextClient(DbContextOptions<DbContextClient> options)
           : base(options)
        {

        }
        public DbSet<Client> client { get; set; }

    }
}
