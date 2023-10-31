using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEIMS.Models
{
    public class Request
    {
        public Request()
        {
            RequestDate = DateTime.Now;
        }
        public int RequestId { get; set; }
        public int EmployeeId { get; set; }
        public int EquipmentId { get; set; }
        public DateTime RequestDate { get; set; }
        public int RequestStatus { get; set; }
        public virtual Employee RequestedBy { get; set; }
    }
}