using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class LongType : ITypeObject<long>
    {

        public long ConvertValue(object value)
        {
            return ConvertValue(value, 0);
        }

        public long ConvertValue(object value, long defaultValue)
        {

            long rtnValue = 0;
            if (value != null && long.TryParse(value.ToString(), out rtnValue))
            {
                return rtnValue;
            }

            return defaultValue;
        }
    }
}
