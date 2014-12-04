using System;

namespace GAsty.Helpers
{
    public static class StringHelper
    {
        public static string[] SplitString(string pString, Char pSpliter)
        {
            var spliter = new char[0];
            spliter[0] = pSpliter;
            string[] split = pString.Split(spliter[0]);
            return split;
        }





    }
}
