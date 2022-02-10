using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using UnluCo.Hafta2.Odev.DBOperations;

namespace UnluCo.Hafta2.Odev
{
    public class JWTAutheticationManager : IJWTAutheticationManager
    {
       
        private readonly string _key;
        public JWTAutheticationManager(string key)
        {
            _key = key;
        }

        private readonly List<User> users = SchoolDbContext.userlist;
        //private readonly IDictionary<string, string> users = new Dictionary<string, string>
        //{
        //    {"usr1","pwd1" },
        //    {"usr2","pwd2" }
        //};
        public string Autheticate(User user)
        {
            //kullanıcı var mı?
            if(!users.Any(x => x.Username == user.Username && x.Password == user.Password))
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(_key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),//uluslararası bir proje geliştiriliyorsa utcnow yerelse now
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}