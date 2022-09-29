using ClinicManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementSystem.DataConnection
{
    public class Dbcontext:DbContext
    {

        public Dbcontext(DbContextOptions<Dbcontext> options): base(options)
        {

        }
         
        public DbSet<UserManagement> User { get; set; }

    }
}
