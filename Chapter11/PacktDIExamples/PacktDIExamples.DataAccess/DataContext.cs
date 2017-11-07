using Microsoft.EntityFrameworkCore;

namespace PacktDIExamples.DataAccess
{
    internal class DataContext
    {
        public DataContext()
        {
        }

        public DbSet<User> Users { get; set; }
    }
}