using My_workeplae.Modles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae.Data
{
   public interface IManagers
    {
        void Add(Managers managers);
        Task Delete(int id);
        Task<IEnumerable<Managers>> GetManagers();
        Task<Managers> Manager(int id);
        Task<bool> SaveAll();
        Task <IEnumerable<object>> Getemployees(int id);
    }
}
