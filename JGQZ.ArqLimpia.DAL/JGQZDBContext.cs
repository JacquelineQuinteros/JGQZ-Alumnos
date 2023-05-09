using JGQZ.ArqLimpia.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JGQZ.ArqLimpia.DAL
{
    public class JGQZDBContext : DbContext
    {
        public JGQZDBContext(DbContextOptions<JGQZDBContext> options) : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
