using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using StockManagementSystem.Model;
using System.Threading.Tasks;

namespace StockManagementSystem.Repository
{
   public  class CategoryRepository
    {
        public bool AddCategory(Category _category)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"INSERT INTO Categories (Code, Name) VALUES('" + _category.Code + "', '" + _category.Name + "')";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isAdded = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isAdded > 0)
                return true;
            else
                return false;
        }

        public bool UpdateCategory(Category _category)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"UPDATE Categories SET Code = '" + _category.Code + "', Name = '" + _category.Name + "'  WHERE ID = " + _category.ID + " ";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            int isUpdated = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();

            if (isUpdated > 0)
                return true;
            else
                return false;
        }
        public List<ViewCategory> Display()
        {
            List<ViewCategory> viewCategories = new List<ViewCategory>();

            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Categories";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            while (sqlDataReader.Read())
            {


                ViewCategory viewCategory = new ViewCategory();

                viewCategory.ID = Convert.ToInt32(sqlDataReader["ID"]);
                viewCategory.Code = sqlDataReader["Code"].ToString();
                viewCategory.Name = sqlDataReader["Name"].ToString();


                viewCategories.Add(viewCategory);
            }

            sqlConnection.Close();

            return viewCategories;
        }

        public bool IsCodeUniqe(string code, int id)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Categories WHERE Code = '" + code + "' AND ID != " + id + "";
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

        public bool IsNameUniqe(string name, int id)
        {
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Categories WHERE Name = '" + name + "'  AND ID != " + id + "";
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
       
        public List<Category> GetAllCategoryFromComboBox()
        {
            List<Category> categories = new List<Category>();
            string sqlString = @"Server=FATEMA-PC\SQLEXPRESS; Database=SMS; Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlString);

            string commandString = @"SELECT * FROM Categories";
            SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

            sqlConnection.Open();

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();


            Category category1 = new Category
            {
                ID = 1,
                Name = "--Select--"
            };
            categories.Add(category1);
            while (sqlDataReader.Read())
            {
                Category category = new Category();
                category.ID = Convert.ToInt32(sqlDataReader["ID"]);
                category.Code = sqlDataReader["Code"].ToString();
                category.Name = sqlDataReader["Name"].ToString();
                categories.Add(category);
            }
            return categories;
        }


    }
}
