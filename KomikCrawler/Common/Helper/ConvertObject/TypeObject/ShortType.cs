using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class ShortType : ITypeObject<short>
    {

        public short ConvertValue(object value)
        {
            return ConvertValue(value, 0);
        }

        public short ConvertValue(object value, short defaultValue)
        {

            short rtnValue = 0;
            if (value != null && short.TryParse(value.ToString(), out rtnValue))
            {
                return rtnValue;
            }

            return defaultValue;
        }
    }
}
