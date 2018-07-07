using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class CharType : ITypeObject<char>
    {

        public char ConvertValue(object value)
        {
            char defVal = ' ';
            return ConvertValue(value, defVal);
        }

        public char ConvertValue(object value, char defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            return Convert.ToChar(value);
        }
    }
}
