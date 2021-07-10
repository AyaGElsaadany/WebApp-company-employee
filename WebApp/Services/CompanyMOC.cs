using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface ICompany
    {
        public List<Company> GetAll();
        public Company AddItem(Company c);
        public Company GetById(int id);
        public List<Company> GetByName(string _name);
        public List<Company> GetByWebsite(string _site);
        public List<Company> GetByAddress(string _address);
    }

    public class CompanyDB:ICompany
    {
        private MyModel _db;
        public CompanyDB(MyModel db)
        {
            _db = db;
        }
        public List<Company> GetAll()
        {
            return _db.companies.ToList();
        }
        public Company AddItem(Company c)
        {
            _db.companies.Add(c);
            _db.SaveChanges();
            return c;
        }
        public Company GetById(int id)
        {
            return _db.companies.FirstOrDefault(c => c.Id == id);
        }
        public List<Company> GetByName(string _name)
        {
            return _db.companies.Where(c => c.Name == _name).ToList();
        }
        public List<Company> GetByWebsite(string _site)
        {
            return _db.companies.Where(c => c.Website == _site).ToList();
        }
        public List<Company> GetByAddress(string _address)
        {
            return _db.companies.Where(c => c.Address == _address).ToList();
        }
    }
}
