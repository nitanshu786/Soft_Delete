using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository.IRepository
{
   public interface IRegisterRepo
    {
        bool IsUniqueUser(string UserName, string Email);
        Register Login(string Email, string Passward);
        Register Registers(string UserName, string Passward, string Email);
    }
}
