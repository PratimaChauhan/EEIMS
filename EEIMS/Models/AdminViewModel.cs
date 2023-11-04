using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EEIMS.Models
{
    public class AddRoleToUserViewModel
    {
        public string Email { get; set; }
        public string Role { get; set; }
    }

    public class EmployeeRoleViewModel
    {
        public string Id { get; set; }

        [Display(Name = "Id")]
        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string FullName { get; set; }

        public string Department { get; set; }


    }
}