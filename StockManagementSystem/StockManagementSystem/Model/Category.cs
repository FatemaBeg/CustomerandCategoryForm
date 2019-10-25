using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StockManagementSystem.BLL;
using StockManagementSystem.Repository;
using System.Threading.Tasks;

namespace StockManagementSystem.Model
{
   public class Category
    {
        public int ID { set; get; }
        public string Code { set; get; }
        public string Name { set; get; }
    }
}
