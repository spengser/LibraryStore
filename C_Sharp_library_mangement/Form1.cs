using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace C_Sharp_library_mangement
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }



        // SEARCH BUTTON
        private void button1_Click(object sender, EventArgs e)
        {
          


            
        }



       

        private void aDDBOOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2(this);
            form.ShowDialog();
        }

      


        ValidateConnection VC = new ValidateConnection();
        string connect = @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sfenzer\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";

        private void Form1_Load(object sender, EventArgs e)
        {
            ClassLoad.mainform = this;


            RefreshTable();       
            


        }

        public void RefreshTable()
        {
            using (SqlConnection sqlcon = new SqlConnection(connect))
            {

                sqlcon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM BOOK_INFO3", sqlcon);
                DataTable db = new DataTable();
                sqlDa.Fill(db);
                dataGridView1.DataSource = db;

            }

        }
        ClassBook_INFO dev = new ClassBook_INFO();
        static string conString = ValidateConnection.ConStr();

        private static SqlConnection conn = new SqlConnection(conString);
        private void button3_Click(object sender, EventArgs e)
        {
            
            string selected_bookid = dataGridView1.CurrentRow.Cells["a"].Value.ToString();
            string selected_bookname = dataGridView1.CurrentRow.Cells["b"].Value.ToString();
            string selected_author = dataGridView1.CurrentRow.Cells["c"].Value.ToString();
            string selected_price = dataGridView1.CurrentRow.Cells["d"].Value.ToString();
            
            //string delete_row = "delete from BOOK_INFO where BOOK_ID = '" + selected_bookid + "'AND BOOK_NAME ='" + selected_bookname + "'AND AUTHOR_NAME ='" + selected_author + "' AND PRICE = '" + selected_price+ "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand("",conn);
            cmd.CommandText = "delete from BOOK_INFO3 where BOOK_ID = '" + selected_bookid + "'AND BOOK_NAME ='" + selected_bookname + "'AND AUTHOR_NAME ='" + selected_author + "' AND PRICE = '" + selected_price + "'";
            int count = cmd.ExecuteNonQuery();

            conn.Close();
            if (count > 0)
            {
                MessageBox.Show("Delete Successfully");
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Failed");
            }



               

            


            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f2 = new Form3();
            f2.textBox1.Text = this.dataGridView1.CurrentRow.Cells["a"].Value.ToString();
            f2.textBox2.Text = this.dataGridView1.CurrentRow.Cells["b"].Value.ToString();
            f2.textBox3.Text = this.dataGridView1.CurrentRow.Cells["c"].Value.ToString();
            f2.textBox4.Text = this.dataGridView1.CurrentRow.Cells["d"].Value.ToString();
            f2.ShowDialog();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from BOOK_INFO3 where BOOK_NAME ='" + textBox1.Text + "' OR AUTHOR_NAME ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

            
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            


        }

      
        

       
      
    }
}
