using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Repository.IRepository
{
      public interface IEmployee
    {
        Task<List< Employee>> GetAll();
        Task<Employee> GetbyId(int Id);
        Task AddEmploye(Employee employee);
        Task UpdateEmploye(Employee employee);
        Task DeleteEmploye(int Id);

    }
}
