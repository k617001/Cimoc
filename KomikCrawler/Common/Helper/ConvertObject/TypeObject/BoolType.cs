using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class BoolType : ITypeObject<bool>
    {

        public bool ConvertValue(object value)
        {
            return ConvertValue(value, false);
        }

        public bool ConvertValue(object value, bool defaultValue)
        {
            bool rtnValue = defaultValue;
            if (value != null && bool.TryParse(value.ToString(), out rtnValue))
            {
                return rtnValue;
            }

            return defaultValue;
        }
    }
}
