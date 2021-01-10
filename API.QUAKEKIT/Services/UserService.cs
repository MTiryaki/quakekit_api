using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using API.QUAKEKIT.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.QUAKEKIT.Services
{
    public class UserService
    {
        private readonly IMongoCollection<User> _users;
        private readonly IQuakeKitDatabaseSettings _quakeKitDatabaseSettings;

        public UserService(IQuakeKitDatabaseSettings settings)
        {
            _quakeKitDatabaseSettings = settings;
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<User>("Users");
        }

        public User Get(AuthenticateModel authenticateModel)
        {
            return _users.Find<User>(x => x.uPhoneNo == authenticateModel.uPhoneNumber).FirstOrDefault();
        }

        public TokenResponseModel Token(AuthenticateModel authenticateModel)
        {
            User user = _users.Find<User>(x => x.uPhoneNo == authenticateModel.uPhoneNumber).FirstOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_quakeKitDatabaseSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, user.uID.ToString())
                }),
                Expires = DateTime.UtcNow.AddMonths(6),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenStr = tokenHandler.WriteToken(token);
            var expiresEpoch = (int)((DateTime)tokenDescriptor.Expires - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            var tokenType = JwtBearerDefaults.AuthenticationScheme;

            return new TokenResponseModel()
            {
                access_token = tokenStr,
                expires_in = expiresEpoch,
                token_type = tokenType
            };
        }

        public List<User> Get()
        {
            List<User> users = _users.Find(x => true).ToList();
            return users;
        }

        public User Get(string id)
        {
            return _users.Find<User>(x => x.uID == id).FirstOrDefault();
        }

        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User userIn)
        {
            _users.ReplaceOne(user => user.uID == id, userIn);
        }

        public void Remove(User userIn)
        {
            _users.DeleteOne(user => user.uID == userIn.uID);
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.uID == id);
        }
    }
}