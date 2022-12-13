using CustomerManagement.Base.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.Model.Models
{
    public class Customers : IEntity
    {
        public int customerId { get; set; }
        public string customerCode { get; set; }
        public string customerTitle { get; set; }
        public string city  { get; set; }
        public string district  { get; set; }
        public int salesAmount { get; set; }
    }
}
