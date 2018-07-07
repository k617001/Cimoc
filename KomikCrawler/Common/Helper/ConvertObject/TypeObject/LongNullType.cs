using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{

    public class LongNullType : ITypeObject<long?>
    {

        public long? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public long? ConvertValue(object value, long? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            long rtnValue = 0;
            long.TryParse(value.ToString(), out rtnValue);
            return rtnValue;
        }
    }
}
