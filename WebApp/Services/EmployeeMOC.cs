using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IEmployee
    {
        public List<Employee> GetAll();
        public Employee AddItem(Employee e);
        public Employee GetById(int id);
        public List<Employee> GetByName(string _name);
        public List<Employee> GetByEmail(string _site);
        public List<Employee> GetByCompanyName(string _address);
    }

    public class EmployeeDB : IEmployee
    {
        private MyModel _db;
        public EmployeeDB(MyModel db)
        {
            _db = db;
        }
        public List<Employee> GetAll()
        {
            return _db.employees.ToList();
        }
        public Employee AddItem(Employee e)
        {
            _db.employees.Add(e);
            _db.SaveChanges();
            return e;
        }
        public Employee GetById(int id)
        {
            return _db.employees.FirstOrDefault(e => e.Id == id);
        }
        public List<Employee> GetByName(string _name)
        {
            return _db.employees.Where(e => e.Name == _name).ToList();
        }
        
        public List<Employee> GetByEmail(string _email)
        {
            return _db.employees.Where(e => e.Email == _email).ToList();
        }

        public List<Employee> GetByCompanyName(string _cname)
        {
            Company c = _db.companies.FirstOrDefault(c => c.Name == _cname);
            return _db.employees.Where(e => e.Company_ID == c.Id).ToList();
        }
    }
}
