using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using StockManagementSystem.Repository;
using StockManagementSystem.Model;

namespace StockManagementSystem.BLL
{
   public class CategoryManager
    {
        CategoryRepository _categoryRepository = new CategoryRepository();

        public bool AddCategory(Category _category)
        {
            return _categoryRepository.AddCategory(_category);
        }

        public bool UpdateCategory(Category _category)
        {
            return _categoryRepository.UpdateCategory( _category);
        }

        public List<ViewCategory> Display()
        {
            return _categoryRepository.Display();
        }

        public bool IsCodeUniqe(String code, int id)
        {
            return _categoryRepository.IsCodeUniqe(code, id);
        }

        public bool IsNameUniqe(String name, int id)
        {
            return _categoryRepository.IsNameUniqe(name, id);
        }
        public List<Category> GetAllCategory()
        {

            return _categoryRepository.GetAllCategoryFromComboBox();
        }

    }
}
