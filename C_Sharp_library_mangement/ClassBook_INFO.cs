using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace C_Sharp_library_mangement
{
    class ClassBook_INFO
    {

        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConStr();
        private static SqlConnection conn = new SqlConnection(conString);
        private string BookName, Author;


     

        public string Author1
        {
            get { return Author; }
            set { Author = value; }
        }

        public string BookName1
        {
            get { return BookName; }
            set { BookName = value; }
        }

        private int BookID, Price;

        public int Price1
        {
            get { return Price; }
            set { Price = value; }
        }

        public int BookID1
        {
            get { return BookID; }
            set { BookID = value; }
        }

        public DataSet _uspBook()
        {
            SqlCommand cmd = new SqlCommand("_uspBook",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds, "_uspBook");
            return ds;

        }
        public void _uspInsertBookInfo()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("_uspInsertBookInfo",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.Add("@BOOK_ID",SqlDbType.Int).Value = BookID;
            cmd.Parameters.Add("@BOOK_NAME", SqlDbType.VarChar).Value = BookName;
            cmd.Parameters.Add("@AUTHOR_NAME", SqlDbType.VarChar).Value = Author;
            cmd.Parameters.Add("@PRICE", SqlDbType.Int).Value = Price;
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void _uspDeleteBookInfo()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("_uspDeleteBookInfo",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BOOK_ID", SqlDbType.Int).Value = Convert.ToInt32(BookID);
            cmd.ExecuteNonQuery();
            conn.Close();

            
        }

        public void _uspUpdateBookInfo()
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("_uspUpdateBookInfo", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BOOK_ID", SqlDbType.Int).Value = BookID;
            cmd.Parameters.Add("@BOOK_NAME", SqlDbType.VarChar).Value = BookName;
            cmd.Parameters.Add("@AUTHOR_NAME", SqlDbType.VarChar).Value = Author;
            cmd.Parameters.Add("@PRICE", SqlDbType.Int).Value = Price;
            cmd.ExecuteNonQuery();
            conn.Close();

        }


        public static int excute(String query)
        {
            conn.Open();
            int count;
            SqlCommand cmd = new SqlCommand("excute",conn);
            count = cmd.ExecuteNonQuery();
            
            conn.Close();
            return count;

        }

    }
}
