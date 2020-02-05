/*
 Name: Antonio Rodrigues
 Email: arodriguez245@cnm.edu
 FileName: RodriguesP7
 */

using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;

namespace RodriguesP7
{
	class DBManager
    {
        Customer customer = new Customer();

        public void GetCustomers(BindingList<Customer> customers) {

            //TODO:  Add :
            customers.Clear();
            string connStr = ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
			string data = "SELECT * FROM Customer";
			// making a connection
			using (SqlConnection conn = new SqlConnection(connStr))
            {
				SqlCommand cmd = new SqlCommand(data,conn);
                
                conn.Open();
                 
				SqlDataReader dr= cmd.ExecuteReader();

                
                while (dr.Read())
                {
                    
                    customer = new Customer();
                    
                    customer.Id = (int)dr["Id"];
                    customer.State = dr["state"].ToString();
                    customer.Zip = (int)dr["zip"];                                      
                    customer.City = dr["city"].ToString();
                    customer.Name = dr["name"].ToString();

                    customers.Add(customer);
                    
                }
            }

        }

        public void AddCustomer(Customer customer) { 
			SqlCommand cmd;
			string insert = "INSERT INTO Customer (state, zip, city, name) VALUES(@state, @zip, @city, @name);";


			string connStr = ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                
				conn.Open();
				cmd = new SqlCommand(insert,conn);
                cmd.Parameters.AddWithValue("state", customer.State);
                cmd.Parameters.AddWithValue("zip", customer.Zip);
                cmd.Parameters.AddWithValue("city", customer.City);
                cmd.Parameters.AddWithValue("name", customer.Name);
                

                cmd.ExecuteNonQuery();
                conn.Close();
			}
		}

		public void UpdateCustomer(Customer customer) {
			
			string update = "UPDATE Customer SET state = @state, zip = @zip, city = @city, name = @name WHERE Id = @Id;";
			string connStr = ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
			using (SqlConnection conn = new SqlConnection(connStr))
			{
				SqlCommand cmd = new SqlCommand(update, conn);
				cmd.Parameters.AddWithValue("state", customer.State);
				cmd.Parameters.AddWithValue("zip", customer.Zip);
                cmd.Parameters.AddWithValue("city", customer.City);
                cmd.Parameters.AddWithValue("name", customer.Name);
				cmd.Parameters.AddWithValue("Id", customer.Id);
				conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

		}

		public void RemoveCustomer(Customer customer) {
			
			//TODO:  I added a semi-colon to the end of the sql string.
				string delete = "DELETE FROM Customer WHERE Id=@Id;";
				string connStr = ConfigurationManager.ConnectionStrings["CustomerDB"].ConnectionString;
				using (SqlConnection conn = new SqlConnection(connStr))
				{
                    conn.Open(); //TODO:  Moved this one here.
					SqlCommand cmd = new SqlCommand(delete, conn);
					
					cmd.Parameters.AddWithValue("Id", customer.Id);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                }
			

		}

    }
}
