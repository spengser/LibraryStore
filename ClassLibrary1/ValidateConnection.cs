using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary1
{
    public class ValidateConnection
    {
        public static string ConStr()
        {
            return @"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\Sfenzer\Documents\Library.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True";
        }
    }
}
