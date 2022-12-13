using CustomerManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Business.Service
{
    public interface IUserService
    {
        List<Users> GetAll();
        Users GetById(int id);
        Users Add(Users users);
        Users Update(Users users);
        void Delete(Users users);
    }
}
