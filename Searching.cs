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
    public partial class Searching : Form
    {
        public Searching(string str_val)
        {
            InitializeComponent();
            textBox5.Text = str_val;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile(textBox5.Text);
            profile.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "select [Title] from [Artifact] where [Author]='" + textBox1.Text + "'";
            cmd2.CommandText = "select [Status] from [Artifact] where [Author]='" + textBox1.Text + "'";

            OleDbDataReader reader = cmd.ExecuteReader();
            OleDbDataReader reader2 = cmd2.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["Title"].ToString());
            }

            while (reader2.Read())
            {
                listBox2.Items.Add(reader2["Status"].ToString());
            }

            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();


            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "select [Title] from [Artifact] where [Title]='" + textBox2.Text + "'";
            cmd2.CommandText = "select [Status] from [Artifact] where [Title]='" + textBox2.Text + "'";

            OleDbDataReader reader = cmd.ExecuteReader();
            OleDbDataReader reader2 = cmd2.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["Title"].ToString());
            }

            while (reader2.Read())
            {
                listBox2.Items.Add(reader2["Status"].ToString());
            }
    
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "select [Title] from [Artifact] where [Genre]='" + textBox3.Text + "'";
            cmd2.CommandText = "select [Status] from [Artifact] where [Genre]='" + textBox3.Text + "'";

           
            OleDbDataReader reader = cmd.ExecuteReader();
            OleDbDataReader reader2 = cmd2.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(reader["Title"].ToString());
            }

            while (reader2.Read())
            {
                listBox2.Items.Add(reader2["Status"].ToString());
            }
            con.Close();

        }

        private void button4_Click(object sender, EventArgs e)/*borrow book button 1*/
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();

            OleDbCommand commandtype = new OleDbCommand("SELECT [Type] FROM [Artifact] WHERE [Title] ='" + textBox4.Text + "'", con);
            OleDbCommand commandfirstborr = new OleDbCommand("SELECT * FROM [UserIssuedData] WHERE [Username]='" + textBox5.Text + "'", con); 
            OleDbCommand commandbooks = new OleDbCommand("SELECT isnull([BookIssued]) & isnull([Book2Issued]) & isnull([Book3Issued]) & isnull([JournalIssued]) & isnull([Journal2Issued]) FROM [UserIssuedData] WHERE [Username]='" + textBox5.Text+"'", con);
            OleDbCommand cmdinsert = new OleDbCommand("INSERT INTO [UserIssuedData] (Username, BookIssued) VALUES ('" + textBox5.Text + "','" + textBox4.Text + "')", con);

            con.Open();
            OleDbDataReader readerfb = commandfirstborr.ExecuteReader();
            OleDbDataReader readertype = commandtype.ExecuteReader();
            OleDbDataReader readerbook = commandbooks.ExecuteReader();


            OleDbCommand cmdinsert = con.CreateCommand();


            //first borrow or not
            string fb = null;
            while (readerfb.Read())
            {
                fb = readerfb[0].ToString();
            }
            readerfb.Close();
            Console.WriteLine(fb);


            //reading type of artifact
            string type = null;
            while (readertype.Read())
            {
                type = readertype[0].ToString();
            }
            readertype.Close();
            Console.WriteLine(type);

            //finding which books/artifacts borrowing slots are empty
            //False means not empty.
            string books = null;
            while (readerbook.Read())
            {
                books = readerbook[0].ToString();
            }
            readerbook.Close();
            Console.WriteLine(books);

            //if borrowing artifact for the first time
            if (fb.Equals('1'))
            {
                if (type.Equals('1'))/**if book borrowed**/
                {

                }
            }
            /*else if (readertype.Equals('2')//journal
            {

            }*/

            


            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();
            

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;
            cmdinsert.CommandType = CommandType.Text;
            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]-1 where [Title]='" + textBox4.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [BookIssued]='"+textBox4.Text+"' where [Username]='"+textBox5.Text+"'";

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Borrowed successfully!");
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]-1 where [Title]='" + textBox6.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [Book2Issued]='" + textBox6.Text + "' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Book Borrowed!");

            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]-1 where [Title]='" + textBox7.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [Book3Issued]='" + textBox7.Text + "' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Book Borrowed !!");

            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]-1 where [Title]='" + textBox8.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [JournalIssued]='" + textBox8.Text + "' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Journal Borrowed !!");

            con.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]-1 where [Title]='" + textBox9.Text + "' and [Quantity]>0 and Type=2";
            cmd2.CommandText = "update [UserIssuedData] set [Journal2Issued]='" + textBox9.Text + "' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Journal Borrowed !!");

            con.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]+1 where [Title]='" + textBox6.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [Book2Issued]='' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Book Returned !!");

            con.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]+1 where [Title]='" + textBox4.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [BookIssued]='' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Book Borrowed !!");

            con.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]+1 where [Title]='" + textBox7.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [Book3Issued]='' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Book Returned !!");

            con.Close();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]+1 where [Title]='" + textBox8.Text + "' and [Quantity]>0";
            cmd2.CommandText = "update [UserIssuedData] set [JournalIssued]='' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Journal Returned !!");

            con.Close();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["WindowsFormsApplication2.Properties.Settings.DBfileConnectionString"].ToString();
            con.Open();

            OleDbCommand cmd = con.CreateCommand();
            OleDbCommand cmd2 = con.CreateCommand();

            cmd.CommandType = CommandType.Text;
            cmd2.CommandType = CommandType.Text;

            cmd.CommandText = "update [Artifact] set [Quantity]=[Quantity]+1 where [Title]='" + textBox9.Text + "' and [Quantity]>0 and Type=2";
            cmd2.CommandText = "update [UserIssuedData] set [Journal2Issued]='' where [Username]='" + textBox5.Text + "'";


            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("Journal Borrowed !!");

            con.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
