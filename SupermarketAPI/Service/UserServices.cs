using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Supermarket.Core.Contants;
using Supermarket.Core.Entities;
using Supermarket.Core.Models;
using Supermarket.Core.Utilities;
using Supermarket.Core.ViewModels;
using SupermarketAPI.Core.Entities;
using SupermarketAPI.DAL;
using SupermarketAPI.DAL.Database;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SupermarketAPI.Service
{
    public interface IUserService
    {
        CurrentStaffViewModel Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin", Role = Role.Admin },
        //    new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", Password = "user", Role = Role.User }
        //};
        private List<User> _users = new List<User>();
        private readonly AppSettings _appSettings;
        private readonly MyDBContext _db;

        public UserService(IOptions<AppSettings> appSettings, MyDBContext db)
        {
            _appSettings = appSettings.Value;
            _db = db;
        }

        public CurrentStaffViewModel Authenticate(string username, string password)
        {
            //var user = _users.SingleOrDefault(x => x.Username == username && x.Password == password);
            var user = _db.Staffs.FirstOrDefault(s => s.Account == username && s.PasswordHash == EncodeUtilities.GetPasswordHash(password));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var currentRole = GetRole(user.StaffId);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Account),
                    new Claim(ClaimTypes.SerialNumber, user.StaffId.ToString()),
                    new Claim(ClaimTypes.Role, currentRole)
                }),
                //Subject = new ClaimsIdentity(listCalim),
                Expires = DateTime.UtcNow.AddMinutes(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var authenModel = new CurrentStaffViewModel()
            {
                Account = user.Account,
                StaffId = user.StaffId,
                StaffRole = user.StaffRole,
                RoleString = currentRole,
                Token = tokenHandler.WriteToken(token)
            };

            return authenModel;
        }
        public string GetRole(int id)
        {
            var staff = _db.Staffs.Find(id);
            if (staff == null)
            {
                return null;
            }
            string result;
            switch (staff.StaffRole)
            {
                case (int)EStaffRole.Administrator:
                    result = RoleConst.ADMIN;
                    break;
                case (int)EStaffRole.SaleStaff:
                    result = RoleConst.User;
                    break;
                default:
                    result = "";
                    break;
            }
            return result;
        }
        
    }
}