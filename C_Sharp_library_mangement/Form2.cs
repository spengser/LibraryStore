using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace C_Sharp_library_mangement
{
    public partial class Form2 : Form
    {
        ClassBook_INFO dev = new ClassBook_INFO();
        
        Form1 form;
        public Form2(Form1 form)
        {
            InitializeComponent();

            this.form = form;
            
        }

        
        private void button1_Click(object sender, EventArgs e)
        {

            this.ExitForm();
        }

          
        private void button2_Click(object sender, EventArgs e)
        {

            
                //dev.BookID1 = Convert.ToInt32(textBox1.Text);

                dev.BookName1 = textBox2.Text;
                dev.Author1 = textBox3.Text;
                dev.Price1 = Convert.ToInt32(textBox4.Text);

                dev._uspInsertBookInfo();
            
            this.ExitForm();
         
          
        }
        private void ExitForm()
        {
            ClassLoad.mainform.RefreshTable();
            this.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
       

    }
}
