/*
 Name: Antonio Rodrigues
 Email: arodriguez245@cnm.edu
 FileName: RodriguesP7
 */
using System;
using System.ComponentModel;
using System.Windows;

//TODO:  Works great.  score 100/100

namespace RodriguesP7
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		DBManager manage = new DBManager();
        BindingList<Customer> customersList = new BindingList<Customer>();
		Customer customer = new Customer();

        // bool to check if the update button was pressed
        bool update = false;

		public MainWindow()
		{
			InitializeComponent();
            RefreshCustomersList();
        }
		private void UpdateManageControls()
		{
			txtId.Text = customer.Id.ToString();
			txtCity.Text = customer.City.ToString();
			txtName.Text = customer.Name.ToString();
			txtState.Text = customer.State.ToString();
			txtZip.Text = customer.Zip.ToString();
		}
		private void RefreshCustomersList()
		{
            //TODO:  Don't make a new Binding List.  You need only one.
			manage.GetCustomers(customersList);
            lbtCustomers.ItemsSource = customersList;
            lbtCustomers.Items.Refresh();
        }
		private void GetCustomersFromControls()
		{
            customer = new Customer();
			customer.City = txtCity.Text;
			customer.Name = txtName.Text;
			customer.State = txtState.Text;
            try
            {
                customer.Zip = int.Parse(txtZip.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Error! Make sure you are only using numbers for the zip code.\r\nDefaulting zip code to 87002");
            }
            finally {
                customer.Zip = customer.Zip;
            }
            // checking to see if update is true if so than it will set the customer id
            if (update == true)
            {
                // no need to for exception handling here sense the user wont be entering any Id for the customer thats all done automagicaly
                customer.Id = int.Parse(txtId.Text);
            }
		}

		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
            customer = new Customer();
            GetCustomersFromControls();
			manage.AddCustomer(customer);
            RefreshCustomersList();
            
		}

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (lbtCustomers.SelectedItem != null)
            {
                if (MessageBox.Show("Are you sure?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    customer = (Customer)lbtCustomers.SelectedItem;

                    manage.RemoveCustomer(customer);

                    RefreshCustomersList();
                }
            }
            else {
                MessageBox.Show("Make sure you have an Customer selected");
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbtCustomers.SelectedItem != null)
            {
                update = true;

                customer = new Customer();

                GetCustomersFromControls();

                manage.UpdateCustomer(customer);

                RefreshCustomersList();
            }
            else {
                MessageBox.Show("Make sure you have an Customer selected");
            }

        }

        private void btnTabAdd_Click(object sender, RoutedEventArgs e)
        {
            tabManage.IsSelected = true;
			txtCity.Clear();
			txtId.Clear();
			txtName.Clear();
			txtState.Clear();
			txtZip.Clear();
        }

        private void btnTabEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lbtCustomers.SelectedItem != null)
            {
                tabManage.IsSelected = true;
                customer = (Customer)lbtCustomers.SelectedItem;
                UpdateManageControls();
            }
            else
            {
                MessageBox.Show("Make sure you have an Customer selected");
            }

        }
    }


}
