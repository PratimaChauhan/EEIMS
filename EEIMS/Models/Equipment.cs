﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EEIMS.Models
{
    public class Equipment
    {
        public Equipment()
        {
            this.PurchaseDate = DateTime.Now;
        }

        [Key]
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string ItemModel { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public bool EquipmentStatus { get; set; }  // 0: not-in-use, 1: in-use
        public bool IsAssigned { get; set; }   // 0: not-assigned, 1: assigned

        public DateTime PurchaseDate { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category CategoryReference { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}