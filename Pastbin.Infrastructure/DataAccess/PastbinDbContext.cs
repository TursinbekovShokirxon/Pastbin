using Microsoft.EntityFrameworkCore;
using Pastbin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pastbin.Infrastructure.DataAccess
{
    public class PastbinDbContext:DbContext
    {
        public PastbinDbContext()
        {
            
        }
        public PastbinDbContext(DbContextOptions<PastbinDbContext> options):base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }

    }
}
