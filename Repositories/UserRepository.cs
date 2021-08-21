using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TeamsPlayersTaskWebAPI_MohammedElmorsy.Helpers;
using TeamsPlayersTaskWebAPI_MohammedElmorsy.Models;

namespace TeamsPlayersTaskWebAPI_MohammedElmorsy.Repositories
{
    public class UserRepository : Repository<User>
    {
        private TeamsDBContext db;
        private DbSet<User> Users;
        private readonly AppSettings _appSettings;


        public UserRepository(TeamsDBContext db, IOptions<AppSettings> appSettings) : base(db)
        {
            this.db = db;
            Users = this.db.Set<User>();
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string password)
        {
            var user = Users.SingleOrDefault(U => U.UserName == username && U.Password == password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            db.SaveChanges();

            // remove password before returning
            user.Password = null;

            return user;
        }

        public bool UserIsExist(User _user)
        {
            User user = Users.SingleOrDefault(U => U.UserName == _user.UserName || U.Email == _user.Email);
            if (user == null)
                return false;
            return true;
        }

        public User DeleteToken(int userId)
        {
            User user = Users.Find(userId);
            if (user != null)
            {
                user.Token = null;
                return user;
            }
            return null;
        }
    }

}
