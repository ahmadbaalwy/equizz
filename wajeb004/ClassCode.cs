using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wajeb004
{
    public class ClassCode
    {
        public string GetNewCode()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }

    }
}