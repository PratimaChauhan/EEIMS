using EEIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEIMS.Functionalities
{
    public interface IEquipmentRepository
    {
        IEnumerable<Equipment> GetAll();
        Equipment Get(int id);
        int Add(AddEquipmentViewModel item);
        int Remove(int id);
        int Update(Equipment item);
    }
}
