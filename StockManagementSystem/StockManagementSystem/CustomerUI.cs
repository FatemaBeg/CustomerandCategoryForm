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
using StockManagementSystem.Model;
using StockManagementSystem.BLL;
using StockManagementSystem.Repository;

namespace StockManagementSystem
{
    public partial class CustomerUI : Form
    {
        public CustomerUI()
        {
            InitializeComponent();
        }
         int selectedID;
        Customer _customer = new Customer();

        CustomerManager _customerManager = new CustomerManager();

        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                _customer.ID = selectedID;

                if (String.IsNullOrEmpty(customerCodeTextBox.Text))
                {
                    MessageBox.Show("Please Enter Code");
                    return;
                }


                if (customerCodeTextBox.TextLength != 4)
                {
                    MessageBox.Show("Code Must be 4 Charecter");
                }


                if (!_customerManager.IsCodeUniqe(customerCodeTextBox.Text,selectedID))
                {
                    MessageBox.Show("Code Must be unique");
                    return;
                }


                if (String.IsNullOrEmpty(customerNameTextBox.Text))
                {
                    MessageBox.Show("Please Enter a Name");
                    return;
                }


               
                if (String.IsNullOrEmpty(customerAddressTextBox.Text))
                {
                    MessageBox.Show("Please Enter a  Address ");
                    return;
                }



                if (String.IsNullOrEmpty(customerEmailTextBox.Text))
                {
                    MessageBox.Show("Please Enter a Valid Eamil ");
                    return;
                }

                if(!_customerManager.IsEmailUniqe(customerEmailTextBox.Text, selectedID))
                {
                    MessageBox.Show("Email Must be unique");
                    return;
                }
                if (String.IsNullOrEmpty(customerContactTextBox.Text))
                {
                    MessageBox.Show(" Please Enter a Valid Mobile Number");
                    return;
                }


                if (customerContactTextBox.TextLength != 11)
                {
                    MessageBox.Show("Enter Valid Mobile No 11 digit");
                    return;
                }


                if (!_customerManager.IsContactUniqe(customerContactTextBox.Text, selectedID))
                {
                    MessageBox.Show("Contact Number Already Exist");
                    return;
                }

                _customer.Code = customerCodeTextBox.Text;
                _customer.Name = customerNameTextBox.Text;
                _customer.Address = customerAddressTextBox.Text;
                _customer.Email = customerEmailTextBox.Text;
                _customer.Contact = customerContactTextBox.Text;
                _customer.LoyaltyPoint = Convert.ToDouble(loyaltyPointTextBox.Text);


                if (addButton.Text == "Save")
                {

                    if (_customerManager.AddCustomer(_customer))
                    {
                        MessageBox.Show("Data Saved Successfully..!!");
                        showDataGridView.DataSource = _customerManager.Display();
                    }
                    else
                    {
                        MessageBox.Show("Not Saved..!!");
                    }
                }

                else
                {
                    if (_customerManager.UpdateCustomer(_customer))
                    {
                        addButton.Text = "Save";

                        MessageBox.Show("Updated Successfully..!!");
                        showDataGridView.DataSource = _customerManager.Display();
                    }
                    else
                    {
                        MessageBox.Show("Not Updated..!!");
                    }
                }
                customerCodeTextBox.Clear();
                customerNameTextBox.Clear();
                customerAddressTextBox.Clear();
                customerEmailTextBox.Clear();
                customerContactTextBox.Clear();
                loyaltyPointTextBox.Clear();

                   

            }


            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void CustomerUI_Load(object sender, EventArgs e)
         {
            showDataGridView.DataSource = _customerManager.Display();
         }

        private void showDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8 && e.RowIndex != -1)
            {
                if (showDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
                {
                    

                    selectedID = Convert.ToInt32(showDataGridView.Rows[e.RowIndex].Cells[1].Value);
                    customerCodeTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    customerNameTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    customerAddressTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                    customerEmailTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                    customerContactTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
                    loyaltyPointTextBox.Text = showDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();


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
