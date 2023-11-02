using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EEIMS.Models
{
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected
    }

    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public DateTime RequestDate { get; set; }
        public RequestStatus Status { get; set; }
        public string Comments { get; set; }

        public virtual Employee RequestedBy { get; set; }
        public int EmployeeId { get; set; }

        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }

    
}