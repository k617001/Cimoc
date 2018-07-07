using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{

    public class ShortNullType : ITypeObject<short?>
    {

        public short? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public short? ConvertValue(object value, short? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            short rtnValue = 0;
            short.TryParse(value.ToString(), out rtnValue);
            return rtnValue;
        }
    }
}
