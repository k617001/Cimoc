using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{

    public class BoolNullType : ITypeObject<bool?>
    {

        public bool? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public bool? ConvertValue(object value, bool? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            bool rtnValue = false;
            bool.TryParse(value.ToString(), out rtnValue);
            return rtnValue;
        }
    }
}
