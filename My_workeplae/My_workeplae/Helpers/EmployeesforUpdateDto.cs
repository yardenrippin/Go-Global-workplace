using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace My_workeplae.Helpers
{
    public class EmployeesforUpdateDto
    {

        public int ID { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name must between 2-20 characters")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name must between 2-20 characters")]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 4, ErrorMessage = "IdentityCard name must between 4-10 characters")]
        public string IdentityCard { get; set; }

        public int ManagerID { get; set; }
       
  
        public DateTime Last_Update { get; set; }



    }
}
