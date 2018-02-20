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
    public partial class Profile : Form
    {
        public Profile(string str_val)
        {
            InitializeComponent();
            textBox1.Text = str_val;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Searching search_page = new Searching(textBox1.Text);
            search_page.Show();
            this.Hide();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();
            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [UserIssuedData] where [Username]='"+textBox1.Text+"'", con);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
