using EEIMS.Functionalities;
using EEIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EEIMS.Repositories
{
    public class EquipmentRepository : IEquipmentRepository
    {
        #region Private Fields
        private ApplicationDbContext _context;

        public EquipmentRepository()
        {

        }

        public EquipmentRepository(ApplicationDbContext applicationDbContext)
        {
            Context = applicationDbContext;
        }

        public ApplicationDbContext Context
        {
            get
            {
                return _context ?? new ApplicationDbContext();
            }
            private set
            {
                _context = value;
            }
        }
        #endregion

        #region Public Methods

        int IEquipmentRepository.Add(AddEquipmentViewModel item)
        {
            throw new NotImplementedException();
        }

        Equipment IEquipmentRepository.Get(int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Equipment> IEquipmentRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        int IEquipmentRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }

        int IEquipmentRepository.Update(Equipment item)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}