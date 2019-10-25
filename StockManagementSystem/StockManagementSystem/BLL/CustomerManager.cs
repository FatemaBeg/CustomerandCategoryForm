using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using StockManagementSystem.Model;
using StockManagementSystem.Repository;

namespace StockManagementSystem.BLL
{
   public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();

        public bool AddCustomer(Customer _customer)
        {
            return _customerRepository.AddCustomer(_customer);
        }

        public bool UpdateCustomer(Customer _customer)
        {
            return _customerRepository.UpdateCustomer(_customer);
        }       

        public List<ViewCustomer> Display()
        {
            return _customerRepository.Display();
        }

        public bool IsCodeUniqe(String code ,int id)
        {
            return _customerRepository.IsCodeUniqe(code,id);
        }
        public bool IsEmailUniqe(String email, int id)
        {
            return _customerRepository.IsEmailUniqe(email, id);
        }

        public bool IsContactUniqe(String contact,int id)
        {
            return _customerRepository.IsContactUniqe(contact,id);
        }
        public double GetCustomerLoyaltyPointById(int id)
        {
            return _customerRepository.GetCustomerLoyaltyPointById(id);
        }
        public List<Customer> GetAllCustomerFromComboBox()
        {

            return _customerRepository.GetAllCustomerFromComboBox();
        }



    }
}
