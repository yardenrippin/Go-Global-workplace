using My_workeplae.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae.Data
{
   public interface IEmployeesRepositoey
    {
        void Add(Employees employees);
        Task Delete(int id);
        Task<IEnumerable<Employees>> GetAllEmployees();
        Task<Employees> GetEmployee(int id);
        Task<IEnumerable<Employees>> GetEmployeesByFirsName(string firstname);
        Task<IEnumerable<Employees>> GetEmployeesByLastName(string LastName);
        Task<IEnumerable<Employees>> GetEmployeesByIdentityCard(string identityCard);
        Task<bool> SaveAll();
        bool Update();


    }
}
