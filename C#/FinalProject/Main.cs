using System;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Main : Form
    {
        MySQLHandler handler;
        public Main()
        {
            InitializeComponent();
            handler = new MySQLHandler();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            handler.loadGrid(dataGrid, "select * from customers");
        }

        public void refreshGrid(object sender, EventArgs e)
        {
            handler.loadGrid(dataGrid, "select * from customers");
        }
    }
}
