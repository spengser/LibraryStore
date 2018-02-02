using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary1
{
    public class ClassBOOK_INFO
    {
        DataSet ds = new DataSet();
        static string conString = ValidateConnection.ConStr();
        private static SqlConnection conn = new SqlConnection(conString);
        #region
        

    }
}
