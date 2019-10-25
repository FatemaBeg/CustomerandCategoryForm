using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StockManagementSystem.BLL;
using StockManagementSystem.Repository;
using StockManagementSystem.Model;

namespace StockManagementSystem
{
    public partial class CategoryUI : Form
    {
        public CategoryUI()
        {
            InitializeComponent();
        }
        int selectedID;
        Category _category = new Category();

        CategoryManager _categoryManager = new CategoryManager();
        private void addButton_Click(object sender, EventArgs e)
        {
            _category.ID = selectedID;

            if (String.IsNullOrEmpty(categoryCodeTextBox.Text))
            {
                MessageBox.Show("Please Enter Code");
                return;
            }


            if (categoryCodeTextBox.TextLength != 4)
            {
                MessageBox.Show("Code Must be 4 Charecter");
            }


            if (!_categoryManager.IsCodeUniqe(categoryCodeTextBox.Text, selectedID))
            {
                MessageBox.Show("Code Must be unique");
                return;
            }


            if (String.IsNullOrEmpty(categoryNameTextBox.Text))
            {
                MessageBox.Show("Please Enter a Name");
                return;
            }
            if (!_categoryManager.IsNameUniqe(categoryNameTextBox.Text, selectedID))
            {
                MessageBox.Show("Name Must be unique");
                return;
            }
            _category.Code = categoryCodeTextBox.Text;
            _category.Name = categoryNameTextBox.Text;

            if (addButton.Text == "Save")
            {

                if (_categoryManager.AddCategory(_category))
                {
                    MessageBox.Show("Data Saved Successfully..!!");
                    showDataGridView.DataSource = _categoryManager.Display();
                }
                else
                {
                    MessageBox.Show("Not Saved..!!");
                }
            }

            else
            {
                if (_categoryManager.UpdateCategory(_category))
                {
                    addButton.Text = "Save";

                    MessageBox.Show("Updated Successfully..!!");
                    showDataGridView.DataSource = _categoryManager.Display();
                }
                else
                {
                    MessageBox.Show("Not Updated..!!");
                }
            }
            categoryCodeTextBox.Clear();
            categoryNameTextBox.Clear();

        }

        private void CategoryUI_Load(object sender, EventArgs e)
        {
            showDataGridView.DataSource = _categoryManager.Display();
        }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != -1)
            {
                if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {


                    selectedID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells[1].Value);
                    categoryCodeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    categoryNameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                   


                    addButton.Text = "Update";



                }
            }
        }

        private void showDataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            this.showDataGridView.Rows[e.RowIndex].Cells[0].Value = e.RowIndex + 1;
        }
    }
}
