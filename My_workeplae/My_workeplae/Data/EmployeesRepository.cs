using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_workeplae.Modles;

namespace My_workeplae.Data
{
    public class EmployeesRepository : IEmployeesRepositoey
    {
        public DataContext _Context { get; }

        public EmployeesRepository(DataContext context)
        {
            _Context = context;
        }

        public void Add (Employees entity) 
        {
            _Context.Employees.Add(entity);
        }
        public async Task updted(Employees em)
        {
            var entity =await _Context.Employees.FindAsync(em.ID);
            if (entity == null)
            {
                return;
            }

            _Context.Entry(entity).CurrentValues.SetValues(em);
          
        }


        public async Task Delete(int id) 
        {
            var employee = await _Context.Employees.FirstOrDefaultAsync(X => X.ID == id);
                _Context.Employees.Remove(employee);
        }

        public async Task<IEnumerable<Object>> GetAllEmployees()
        {
            //var List = await _Context.Employees.Include(X => X.Manager).Select(X=>X.FirstName).ToListAsync();
            var List = await (from d in _Context.Employees
                              join f in _Context.Managers
                             on d.ManagerID equals f.ID
                              select new
                              {
                                  ID = d.ID,
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  IdentityCard = d.IdentityCard,
                                  Managername = f.FirstName

                              }).ToListAsync();
            return List;
        }



        public async Task<Employees> GetEmployee(int id)
        {
            var employee = await _Context.Employees.FirstOrDefaultAsync(x => x.ID==id);
            return employee;
        }

        public async Task<IEnumerable<Object>> GetEmployeesByFirsName(string firstname)
        {
            //var employee = await _Context.Employees.Include(X=>X.Manager).Where(x => x.FirstName == firstname).ToListAsync();
            //return employee;
            var List = await (from d in _Context.Employees
                              join f in _Context.Managers
                             on d.ManagerID equals f.ID
                              where d.FirstName == firstname
                              select new
                              {
                                  ID = d.ID,
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  IdentityCard = d.IdentityCard,
                                  Managername = f.FirstName

                              }).ToListAsync();
            return List;

        }


   

        public async Task<IEnumerable<Object>> GetEmployeesByIdentityCard(string identityCard)
        {
            //var employee = await _Context.Employees.Where(x => x.IdentityCard == identityCard).ToListAsync();
            //return employee;
            var List = await (from d in _Context.Employees
                              join f in _Context.Managers
                             on d.ManagerID equals f.ID
                              where d.IdentityCard == identityCard
                              select new
                              {
                                  ID = d.ID,
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  IdentityCard = d.IdentityCard,
                                  Managername = f.FirstName

                              }).ToListAsync();
            return List;

        }


        public async Task<IEnumerable<Object>> GetEmployeesByLastName(string LastName)
        {
            //var employee = await _Context.Employees.Where(x => x.LastName ==LastName).ToListAsync();
            //return employee;
            var List = await (from d in _Context.Employees
                              join f in _Context.Managers
                             on d.ManagerID equals f.ID
                              where d.LastName == LastName
                              select new
                              {
                                  ID = d.ID,
                                  FirstName = d.FirstName,
                                  LastName = d.LastName,
                                  IdentityCard = d.IdentityCard,
                                  Managername = f.FirstName

                              }).ToListAsync();
            return List;
        }

     

        public async Task<bool> SaveAll()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

      
    }
}
