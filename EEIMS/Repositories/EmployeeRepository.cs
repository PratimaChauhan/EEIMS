using EEIMS.Functionalities;
using EEIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Web;

namespace EEIMS.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository()
        {
            _context = new ApplicationDbContext();
        }

        void IEmployeeRepository.AddOnce(FirstTimeAddEmployeeViewModel employee)
        {
            var temp = _context.Employees.Where(e => e.Id == employee.Id).FirstOrDefault();
            
            temp.FirstName = employee.FirstName;
            temp.LastName = employee.LastName;
            temp.Designation = employee.Designation;
            temp.Department = employee.Department;
            temp.PhoneNumber = employee.PhoneNumber;
           
            SaveChanges();
        }

        void IEmployeeRepository.Update(int id)
        {
            _context.Entry(_context.Employees.Find(id)).State = EntityState.Modified;
            SaveChanges();
        }


        void IEmployeeRepository.Delete(Expression<Func<Employee, bool>> where)
        {
            _context.Employees.Remove(_context.Employees.Where(where).FirstOrDefault());
            SaveChanges();
        }

        void IEmployeeRepository.DeleteById(int id)
        {
            _context.Employees.Remove(_context.Employees.Where(e => e.EmployeeId == id).FirstOrDefault());
            SaveChanges();
        }

        //
        // Summary: For getting employee by Id (string Type)
        Employee IEmployeeRepository.GetById(string id)
        {
            return _context.Employees.Where(e => e.Id == id).FirstOrDefault();
        }
        Employee IEmployeeRepository.Get(Expression<Func<Employee, bool>> where)
        {
            return _context.Employees.Where(where).FirstOrDefault();
        }


        IEnumerable<Employee> IEmployeeRepository.GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        IEnumerable<Employee> IEmployeeRepository.GetMany(Expression<Func<Employee, bool>> where)
        {
            return _context.Employees.Where(where).ToList();
        }


        void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}