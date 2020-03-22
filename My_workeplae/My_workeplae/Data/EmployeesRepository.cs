using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using My_workeplae.Modles;

namespace My_workeplae.Data
{
    public class EmployeesRepository : IEmployeesRepositoey
    {
        public DataContext _Context { get; }
        

        public EmployeesRepository(DataContext context, IMapper maapper)
        {
            _Context = context;
         
        }

        public void Add (Employees entity) 
        {
            _Context.Employees.Add(entity);
        }
     


        public async Task Delete(int id) 
        {
            var employee = await _Context.Employees.FirstOrDefaultAsync(X => X.ID == id);
                _Context.Employees.Remove(employee);
        }

        public async Task<IEnumerable<Employees>> GetAllEmployees()
        {
            var List = await _Context.Employees.Include(X => X.Manager).OrderBy(x=> x.FirstName). ToListAsync();
       
            return List;

        }



        public async Task<Employees> GetEmployee(int id)
        {
            var employee = await _Context.Employees.Include(X => X.Manager).FirstOrDefaultAsync(x => x.ID==id);
            return employee;
        }


        public async Task<bool> SaveAll()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

       

        public async Task<IEnumerable<Employees>> GetEmployeesByFirsName(string firstname)
        {
            var list = await _Context.Employees.Where(x => x.FirstName == firstname).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<Employees>> GetEmployeesByLastName(string LastName)
        {
            var list = await _Context.Employees.Where(x => x.LastName == LastName).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<Employees>> GetEmployeesByIdentityCard(string identityCard)
        {
            var list = await _Context.Employees.Where(x => x.IdentityCard == identityCard).ToListAsync();

            return list;
        }

        public bool Update()
        {
            return _Context.SaveChanges() > 0;
        }
    }
}
