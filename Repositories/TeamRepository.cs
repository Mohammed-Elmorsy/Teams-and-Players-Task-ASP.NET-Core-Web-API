using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TeamsPlayersTaskWebAPI_MohammedElmorsy.Models;

namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Repositories
{
    public class TeamRepository : Repository<Team>
    {
        private TeamsDBContext db;
        private DbSet<Team> Teams;
        public TeamRepository(TeamsDBContext db) : base(db)
        {
            this.db = db;
            Teams = this.db.Set<Team>();
        }
        public override IEnumerable<Team> GetAll()
        {
            return Teams.Include(team => team.Players).ToList();
        }
        public override Team GetById(int id)
        {
            return Teams.SingleOrDefault(Team => Team.Id == id);
        }
    }
}
