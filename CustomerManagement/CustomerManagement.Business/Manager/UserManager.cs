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
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager( IUserDal userDal)
        {
            _userDal = userDal;
        }


        public Users Add(Users users)
        {
            return _userDal.Add(users);
        }

        public void Delete(Users users)
        {
            _userDal.Delete(users);
        }

        public List<Users> GetAll()
        {
            return _userDal.GetList();
        }

        public Users GetById(int id)
        {
             return _userDal.Get( x => x.userId == id );
        }

        public Users Update(Users users)
        {
            return _userDal.Update( users );
        }
    }
}
