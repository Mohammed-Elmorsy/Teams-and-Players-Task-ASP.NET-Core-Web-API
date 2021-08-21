using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Models
{
    public class TeamsDBContext: DbContext
    {
        public TeamsDBContext(DbContextOptions<TeamsDBContext> options): base(options) {}

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
