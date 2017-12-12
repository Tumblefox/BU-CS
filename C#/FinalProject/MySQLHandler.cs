using System;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;

namespace FinalProject
{
    class MySQLHandler
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        private string connectionString;
        public event EventHandler<EventArgs> dataSync;

        public MySQLHandler()
        {
            //connectionString = "server=localhost;database=test;userid=root;password=";
            connectionString = "server=sql9.freemysqlhosting.net;database=sql9209418;userid=sql9209418;password=quVzFMJSkA";
            connection = new MySqlConnection(connectionString);
            dataSync = delegate { };
        }

        public MySQLHandler(string conn)
        {
            connectionString = conn;
            connection = new MySqlConnection(connectionString);
        }

        public void Login(string sql)
        {
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                reader.Read();

                if (reader.GetInt32(0) == 1)
                {
                    MessageBox.Show("Successful Login!");
                }
                else
                {
                    MessageBox.Show("Login Unsuccessful: " + reader.GetInt32(0) + " results");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void loadGrid(DataGridView grid, string sql)
        {
            try
            {
                connection.Open();

                DataSet dataSet = new DataSet();
                MySqlDataAdapter data = new MySqlDataAdapter(sql, connection);
                data.Fill(dataSet, "customers");

                grid.DataSource = dataSet.Tables["customers"];
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            
        }

        public string[] getCustomerData(string sql)
        {
            string[] customer = new string[11];
            try
            {
                connection.Open();

                MySqlCommand command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    for (int i = 1; i < 12; i++)
                    {
                        if (!reader.IsDBNull(i))
                            customer[i - 1] = reader.GetString(i);
                        else
                            customer[i - 1] = "";
                    }
                }
                else
                {
                    MessageBox.Show("No such customer exists!");
                }
                
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
            return customer;
        }

        public void DeleteCustomer(string id)
        {
            try
            {
                connection.Open();
                string sql = "delete from customers where CustomerID='" + id + "'";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();

                MessageBox.Show("Customer " + id + " successfully deleted!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void AddCustomer(string[] customer)
        {
            try
            {
                connection.Open();
                string sql = "insert into customers values(@id, @company, @contact, @title, @address, @city, @region, @postal, @country, @phone, @email, @fax)";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Prepare();

                command.Parameters.AddWithValue("@id", customer[0]);
                command.Parameters.AddWithValue("@company", customer[1]);
                command.Parameters.AddWithValue("@contact", customer[2]);
                command.Parameters.AddWithValue("@title", customer[3]);
                command.Parameters.AddWithValue("@address", customer[4]);
                command.Parameters.AddWithValue("@city", customer[5]);
                command.Parameters.AddWithValue("@region", customer[6]);
                command.Parameters.AddWithValue("@postal", customer[7]);
                command.Parameters.AddWithValue("@country", customer[8]);
                command.Parameters.AddWithValue("@phone", customer[9]);
                command.Parameters.AddWithValue("@email", customer[10]);
                command.Parameters.AddWithValue("@fax", customer[11]);

                command.ExecuteNonQuery();

                MessageBox.Show("Customer " + customer[0] + " successfully added!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void updateCustomer(string[] customer)
        {
            try
            {
                connection.Open();

                string sql = "update customers set CustomerID=@id, CompanyName=@company, ContactName=@contact, ContactTitle=@title, Address=@address, City=@city, Region=@region, PostalCode=@postal, Country=@country, Phone=@phone, Email=@email, Fax=@fax where CustomerID=@id";
                MySqlCommand command = new MySqlCommand(sql, connection);
                command.Prepare();

                command.Parameters.AddWithValue("@id", customer[0]);
                command.Parameters.AddWithValue("@company", customer[1]);
                command.Parameters.AddWithValue("@contact", customer[2]);
                command.Parameters.AddWithValue("@title", customer[3]);
                command.Parameters.AddWithValue("@address", customer[4]);
                command.Parameters.AddWithValue("@city", customer[5]);
                command.Parameters.AddWithValue("@region", customer[6]);
                command.Parameters.AddWithValue("@postal", customer[7]);
                command.Parameters.AddWithValue("@country", customer[8]);
                command.Parameters.AddWithValue("@phone", customer[9]);
                command.Parameters.AddWithValue("@email", customer[10]);
                command.Parameters.AddWithValue("@fax", customer[11]);

                command.ExecuteNonQuery();

                MessageBox.Show("Customer " + customer[0] + " successfully updated!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                connection.Close();
            }
        }

        public void syncData()
        {
            dataSync(this, EventArgs.Empty);
        }
    }
}
