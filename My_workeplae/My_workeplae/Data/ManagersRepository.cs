using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using My_workeplae.Modles;

namespace My_workeplae.Data
{
    public class ManagersRepository : IManagers
    {

        public DataContext _Context { get; }

        public ManagersRepository(DataContext dbcontext)
        {
            _Context = dbcontext;
        }



        public void Add(Managers managers)
        {
            _Context.Managers.Add(managers);
        }

        public async Task Delete(int id)
        {
            var manager = await _Context.Managers.FirstOrDefaultAsync(x => x.ID == id);
            _Context.Managers.Remove(manager);
        }

        public async Task<IEnumerable<Managers>> GetManagers()
        {
            var List = await _Context.Managers.ToArrayAsync();
            return List;
        }

        public async Task<Managers> Manager(int id)
        {
            var manager = await _Context.Managers.FirstOrDefaultAsync(x => x.ID == id);
            return manager;
        }

        public async Task<bool> SaveAll()
        {
            return await _Context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Employees>> Getemployees(int id)
        {
            var employees = await _Context.Employees.Where(x => x.ManagerID == id).ToListAsync();


         
            return employees;

        }

    }
}
