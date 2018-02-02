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
    public partial class Form3 : Form
    {
        
        public Form3()
        {
            InitializeComponent();
            
        }
        
        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        ClassBook_INFO dev = new ClassBook_INFO();
        private void button2_Click(object sender, EventArgs e)
        {

            dev.BookID1 = Convert.ToInt32(textBox1.Text);
            dev.BookName1 = textBox2.Text;
            dev.Author1 = textBox3.Text;
            dev.Price1 = Convert.ToInt32(textBox4.Text);

            dev._uspUpdateBookInfo();

            this.Close();
            ClassLoad.mainform.RefreshTable();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            ClassLoad.mainform.RefreshTable();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)){
                e.Handled = true;
            }
        }
    }
}
