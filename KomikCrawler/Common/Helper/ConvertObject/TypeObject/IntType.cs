using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{



    public class IntType : ITypeObject<int>
    {

        public int ConvertValue(object value)
        {
            return ConvertValue(value, 0);
        }

        public int ConvertValue(object value, int defaultValue)
        {
            int rtnValue = 0;
            if (value != null && int.TryParse(value.ToString(), out rtnValue))
            {
                return rtnValue;
            }

            return defaultValue;
        }
    }
}
