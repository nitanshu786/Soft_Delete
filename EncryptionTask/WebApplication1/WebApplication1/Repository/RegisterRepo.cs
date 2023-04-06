using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class RegisterRepo : IRegisterRepo
    {
        private readonly ApplicationDbcontext _context;
        private readonly JwtToken _jwtToken;

        public RegisterRepo(ApplicationDbcontext context, IOptions<JwtToken> jwtToken)
        {
            _context = context;
            _jwtToken = jwtToken.Value;
        }

        public Register Login(string Email, string passward)
        {

            var auth = _context.Registers.FirstOrDefault(s => s.Email == Email && s.Password == passward);
            Decryption(auth.Password);

            if (auth == null)
                return null;


            else
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_jwtToken.Secret);
                var tokenDescritor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, auth.Id.ToString())


                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescritor);
                auth.Token = tokenHandler.WriteToken(token);
                return auth;
            }
        }
        public string Decryption(string password)
        {
            if (string.IsNullOrEmpty(password))
                return null;
            else
            {
                byte[] encryption = Convert.FromBase64String(password);
                string dencryption = Encoding.ASCII.GetString(encryption);
               
                return dencryption;
                
            }

        }






        public bool IsUniqueUser(string Username, string Email)
        {
            var uniq = _context.Registers.FirstOrDefault(s => s.UserName == Username && s.Email == Email);

            if (uniq == null)
            {
                return true;
            }
            else
                return false;
        }

        public Register Registers(string UserName, string Passward, string Email)
        {

            Register register = new Register()
            {
                UserName = UserName,
                Password = Passward,
                Email = Email
            };

            _context.Registers.Add(register);
            _context.SaveChanges();
            return register;
        }



       
    }
}
