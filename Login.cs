using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Login : Form
    {
        DataTable dt = new DataTable();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();
            OleDbDataAdapter da=new OleDbDataAdapter("SELECT * FROM [User] where [Username]='"+textBox1.Text+"' and [Password]='"+textBox2.Text+"'",con);
            
            da.Fill(dt);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("Username or Password Invalid!");
            }

            else
            {
                MessageBox.Show("Login Successful!");
                Searching search_page = new Searching(textBox1.Text);
                search_page.Show();
                this.Hide();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
