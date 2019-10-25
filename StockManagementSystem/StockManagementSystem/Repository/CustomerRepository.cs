using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Model;
using System.Data;
using System.Data.SqlClient;

namespace StockManagementSystem.Repository
{
    public class CustomerRepository
    {
        public bool AddCustomer(Customer _customer)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"INSERT INTO Customers (Code, Name,  Address, Email,Contact,LoyaltyPoint) VALUES('" + _customer.Code + "', '" + _customer.Name + "', '" + _customer.Address + "', '" + _customer.Email + "', '" + _customer.Contact + "', " + _customer.LoyaltyPoint + ")";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isAdded = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isAdded > 0)
                return true;
            else
                return false;
        }

        public bool UpdateCustomer(Customer _customer)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"UPDATE Customers SET Code = '" + _customer.Code + "', Name = '" + _customer.Name + "', Address = '" + _customer.Address + "',  Email = '" + _customer.Email + "',Contact = '" + _customer.Contact + "' , LoyaltyPoint = " + _customer.LoyaltyPoint + "  WHERE ID = " + _customer.ID + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isUpdated = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isUpdated > 0)
                return true;
            else
                return false;
        }
        public List<ViewCustomer> Display()
        {
            List<ViewCustomer> viewCustomers = new List<ViewCustomer>();

            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {
                

                ViewCustomer viewCustomer = new ViewCustomer();

                viewCustomer.ID = Convert.ToInt32(sqlDataReader["ID"]);
                viewCustomer.Code = sqlDataReader["Code"].ToString();
                viewCustomer.Name = sqlDataReader["Name"].ToString();
                viewCustomer.Address = sqlDataReader["Address"].ToString();
                viewCustomer.Email = sqlDataReader["Email"].ToString();               
                viewCustomer.Contact = sqlDataReader["Contact"].ToString();
                viewCustomer.LoyaltyPoint = Convert.ToDouble(sqlDataReader["LoyaltyPoint"].ToString());

                viewCustomers.Add(viewCustomer);
            }

            sqlConnection.Close();

            return viewCustomers;
        }

        public bool IsCodeUniqe(string code,int id)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Code = '" + code + "' AND ID != "+id+"";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }
        public bool IsEmailUniqe(string email, int id)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Email = '" + email + "' AND ID != " + id + "";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }

        public bool IsContactUniqe(string contact ,int id)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers WHERE Contact = '" + contact + "'  AND ID != "+id+"";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            int flag = 0;
            while (sqlDataReader.Read())
            {
                flag = 1;
                break;
            }

            sqlConnection.Close();

            if (flag == 0)
                return true;
            else
                return false;
        }
        public double GetCustomerLoyaltyPointById(int id)
        {
            double point = 0;
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT LoyaltyPoint FROM Customers   WHERE ID = " + id + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                point = Convert.ToDouble(sqlDataReader["LoyaltyPoint"]);
            }

            sqlConnection.Close();
            return point;
        }
        public List<Customer> GetAllCustomerFromComboBox()
        {
            List<Customer> customers = new List<Customer>();
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            Customer customer1 = new Customer
            {
                ID = 0,
                Name = "--Select--"
            };
            customers.Add(customer1);
            while (sqlDataReader.Read())
            {
                Customer customer = new Customer();
                customer.ID = Convert.ToInt32(sqlDataReader["ID"]);
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Email = sqlDataReader["Email"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.LoyaltyPoint = Convert.ToDouble(sqlDataReader["LoyaltyPoint"]);
                customers.Add(customer);
            }
            return customers;
        }
    }
}
