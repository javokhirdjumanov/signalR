
using Chat.DB.Models;
using Core.EF;
using Microsoft.EntityFrameworkCore;

namespace Chat.DB
{
    public class AppDbContext : DefaultConfiguredDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<DB.Models.Chat> Chats { get; set; }

        public AppDbContext()
        { }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
    }
}
