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
        Task updted(Employees em);
        Task<IEnumerable<Object>> GetAllEmployees();
        Task<Employees> GetEmployee(int id);
        Task<IEnumerable<Object>> GetEmployeesByFirsName(string firstname);
        Task<IEnumerable<Object>> GetEmployeesByLastName(string LastName);
        Task<IEnumerable<Object>> GetEmployeesByIdentityCard(string identityCard);
        Task<bool> SaveAll();


    }
}
