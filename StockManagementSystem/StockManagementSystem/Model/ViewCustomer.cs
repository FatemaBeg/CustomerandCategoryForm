using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
  public   class ViewCustomer
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public string Contact { set; get; }
        public double LoyaltyPoint { set; get; }
    }
}
