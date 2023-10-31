using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEIMS.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Name { get; set; }
        public string ItemModel { get; set; }
        public string SerialNumber { get; set; }
        public string Description { get; set; }

        public bool EquipmentStatus { get; set; }
        public bool IsAssigned { get; set; }

        public DateTime PurchaseDate { get; set; }
        
        public int CategoryId { get; set; }
        public virtual Category CategoryReference { get; set; }
    }
}