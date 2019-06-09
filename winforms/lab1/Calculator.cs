using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    class Calculator
    {
        static void IsEmpty (string str)
        {
            if(str == string.Empty)
            {
                throw new Exception();
            }
        }

        public static bool Smaller (string left, string right)
        {
            IsEmpty(left);
            IsEmpty(right);
            if (left.Length < right.Length)
                return true;
            else return false;
        }

        public static bool Bigger(string left, string right)
        {
            IsEmpty(left);
            IsEmpty(right);
            if (left.Length > right.Length)
                return true;
            else return false;
        }

        public static bool Equal(string left, string right)
        {
            IsEmpty(left);
            IsEmpty(right);
            if (left.Length == right.Length)
                return true;
            else return false;
        }

        public static bool NoEqual(string left, string right)
        {
            IsEmpty(left);
            IsEmpty(right);
            if (left.Length != right.Length)
                return true;
            else return false;
        }

        public static int Left(string left, string right)
        {
            IsEmpty(left);
            IsEmpty(right);
            int newLeft = Convert.ToInt32(left);
            int newRight = Convert.ToInt32(right);
            return newLeft << newRight;
        }

        public static int Right(string left, string right)
        {
            IsEmpty(left);
            IsEmpty(right);
            int newLeft = Convert.ToInt32(left);
            int newRight = Convert.ToInt32(right);
            return newLeft >> newRight;
        }
    }
}
