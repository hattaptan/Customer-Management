using CustomerManagement.Base.Manager;
using CustomerManagement.DataAccess.Abstract;
using CustomerManagement.DataAccess.Context;
using CustomerManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DataAccess.Concrete
{
    public class UserDal : EntityRepository<Users, CustomerManagementContext>, IUserDal
    {
    }
}
