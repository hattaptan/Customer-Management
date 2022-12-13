using CustomerManagement.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model.Models
{
    public class Users : IEntity
    {
        public int userId { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
    }
}
