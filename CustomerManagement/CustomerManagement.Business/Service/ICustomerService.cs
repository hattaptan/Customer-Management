using CustomerManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Service
{
    public  interface ICustomerService
    {
        List<Customers> GetAll();
        Customers GetById(int id);
        Customers Add(Customers customers);
        Customers Update(Customers customers);
        void Delete(Customers customers);
    }
}
