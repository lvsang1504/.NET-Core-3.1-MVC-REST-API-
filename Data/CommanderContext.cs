using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data 
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> otp) : base(otp)
        {
            
        }
       // public DbSet<Command> Commands { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<User> Users { get; set; }

        //Name have to same in SQL Server
        public DbSet<PeriodicReportItem> PeriodicReportItem { get; set; }

        public DbSet<Notification> Notifications { get; set; }
    }
}