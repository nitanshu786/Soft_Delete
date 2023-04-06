using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Model;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class Employe : IEmployee
    {
        private readonly ApplicationDbcontext _context;

        public Employe(ApplicationDbcontext context)
        {
            _context = context;
        }

        public async Task AddEmploye(Employee employee)
        {
           await _context.Employees.AddAsync(employee);
           await  _context.SaveChangesAsync();
           
        }

        public async Task DeleteEmploye(int Id)
        {
            var dell = await _context.Employees.FindAsync(Id);
            _context.Employees.Remove(dell);
            _context.SaveChanges();
        }

      

        public async Task<Employee> GetbyId(int Id)
        {
            return await _context.Employees.FindAsync(Id);
        }

        public async Task UpdateEmploye(Employee employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async  Task<List<Employee>> GetAll()
        {
            return  _context.Employees.ToList();
        }
    }
}
