using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
        private DbSet<Player> Players;
        public TeamRepository(TeamsDBContext db) : base(db)
        {
            this.db = db;
            Teams = this.db.Set<Team>();
            Players = this.db.Set<Player>();
        }
        public override IEnumerable<Team> GetAll()
        {
            return Teams.Include(team => team.Players).ToList();
        }
        public override Team GetById(int id)
        {
            return Teams.SingleOrDefault(Team => Team.Id == id);
        }

        public bool AddTeamWithPlayers(Team team)
        {
            using (IDbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    var _team = Teams.Add(team);
                    if (_team != null)
                    {
                        foreach (Player player in team.Players)
                        {
                            Players.Add(player);
                        }
                        transaction.Commit();
                        return true;
                    }
                    return false;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    return false;
                }
            }

        }

    }
}
