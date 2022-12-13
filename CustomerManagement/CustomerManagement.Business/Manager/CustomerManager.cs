using CustomerManagement.Business.Service;
using CustomerManagement.DataAccess.Abstract;
using CustomerManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Manager
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal; 
        }

        public Customers Add(Customers customers)
        {
           return _customerDal.Add(customers);
        }

        public void Delete(Customers customers)
        {
            _customerDal.Delete(customers);
        }

        public List<Customers> GetAll()
        {
             return _customerDal.GetList();
        }

        public Customers GetById(int id)
        {
            return _customerDal.Get(x => x.customerId == id);
        }

        public Customers Update(Customers customers)
        {
           return _customerDal.Update(customers);
        }
    }
}
