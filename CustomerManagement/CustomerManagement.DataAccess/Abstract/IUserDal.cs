using CustomerManagement.Base.Abstract;
using CustomerManagement.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<Users>
    {
    }
}
