using System;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class CustomerMaintenance : Form
    {
        MySQLHandler handler;
        public CustomerMaintenance()
        {
            InitializeComponent();
            Main main = new Main();
            main.Show();

            handler = new MySQLHandler();
            handler.dataSync += main.refreshGrid;
        }

        private void id_button_Click(object sender, EventArgs e)
        {
            string sql = "select * from customers where CustomerID='" + id_box.Text + "'";
            string[] customer = handler.getCustomerData(sql);

            company_box.Text = customer[0];
            name_box.Text = customer[1];
            title_box.Text = customer[2];
            address_box.Text = customer[3];
            city_box.Text = customer[4];
            region_box.Text = customer[5];
            postal_box.Text = customer[6];
            country_box.Text = customer[7];
            phone_box.Text = customer[8];
            email_box.Text = customer[9];
            fax_box.Text = customer[10];
        }

        //TODO: USE EVENT HANDLER TO MAKE THIS REFESH THE MAIN WINDOW
        private void delete_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this customer?", "confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            
            if (result == DialogResult.OK)
            {
                handler.DeleteCustomer(id_box.Text);
            }
            handler.syncData();
        }

        //TODO: USE EVENT HANDLER TO MAKE THIS REFESH THE MAIN WINDOW
        private void add_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to add this customer?", "confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                string[] customer = { id_box.Text, company_box.Text, name_box.Text, title_box.Text, address_box.Text, city_box.Text,
                region_box.Text, postal_box.Text, country_box.Text, phone_box.Text, email_box.Text, fax_box.Text};

                handler.AddCustomer(customer);
            }
            handler.syncData();
        }

        //TODO: USE EVENT HANDLER TO MAKE THIS REFESH THE MAIN WINDOW
        private void update_button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update this customer's info?", "confirmation",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                string[] customer = { id_box.Text, company_box.Text, name_box.Text, title_box.Text, address_box.Text, city_box.Text,
                region_box.Text, postal_box.Text, country_box.Text, phone_box.Text, email_box.Text, fax_box.Text};

               handler.updateCustomer(customer);
            }
            handler.syncData();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            id_box.Clear();
            company_box.Clear();
            name_box.Clear();
            title_box.Clear();
            address_box.Clear();
            city_box.Clear();
            region_box.Clear();
            postal_box.Clear();
            country_box.Clear();
            phone_box.Clear();
            email_box.Clear();
            fax_box.Clear();
        }
    }
}
