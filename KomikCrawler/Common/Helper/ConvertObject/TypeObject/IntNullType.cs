using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{ 

    public class IntNullType : ITypeObject<int?>
    {

        public int? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public int? ConvertValue(object value, int? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            int rtnValue = 0;
            int.TryParse(value.ToString(), out rtnValue);
            return rtnValue;
        }
    }
}
