using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsPlayersTaskWebAPI_MohammedElmorsy.Models;

namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Repositories
{
    public class PlayerRepository : Repository<Player> 
    {
        private TeamsDBContext db;
        private DbSet<Player> Players;
        public PlayerRepository(TeamsDBContext db) : base(db)
        {
            this.db = db;
            Players = this.db.Set<Player>();
        }
        //public override IEnumerable<Player> GetAll()
        //{
        //    return Players.ToList();
        //}
        //public override Player GetById(int id)
        //{
        //    return Players.SingleOrDefault(player => player.Id == id);
        //}
    }
}
