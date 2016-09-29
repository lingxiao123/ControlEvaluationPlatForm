using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatFormWeb.Utility
{
    public class StringHelper
    {
        public static string SpiltStr(string key)
        {
            string[] _in = key.Split(',');
            string _key = "";
            foreach (string str in _in)
            {
                _key = _key + ",'" + str + "'";
            }
            return _key.Substring(1);
        }
    }
}