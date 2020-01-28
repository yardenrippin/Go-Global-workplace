using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae.Modles
{
    public class Managers
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string IdentityCard { get; set; }

        public ICollection<Employees> Employees { get; set; }
    }
}
