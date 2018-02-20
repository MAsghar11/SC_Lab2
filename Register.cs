using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace WindowsFormsApplication2
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = new OleDbCommand();
            

            cmd.CommandText = "insert into [User](Username,[Password])values(@name,@pass)";
            cmd.Parameters.AddWithValue("@name", textBox1.Text);

       
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);


            cmd.Connection = con;

            OleDbDataAdapter da = new OleDbDataAdapter("SELECT * FROM [User] where [Username]='" + textBox1.Text + "' and [Password]='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();

            da.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                MessageBox.Show("User already exist !!");
            }

            if (dt.Rows.Count <= 0)
            {
                int a = cmd.ExecuteNonQuery();

                if (a > 0)
                {
                    MessageBox.Show("User Registered !!");
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
