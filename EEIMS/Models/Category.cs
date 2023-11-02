using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEIMS.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }

        public virtual ICollection<Request> Requests { get; set; }
    }
}