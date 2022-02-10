using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnluCo.Hafta2.Odev.StringExtensions
{
    public static class IsValidEmail
    {
        public static bool isValidEmail(this string str)
        {

            bool result = str.Contains('@');
            return result;
        }
    }
}
