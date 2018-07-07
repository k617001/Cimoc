using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{

    public class DoubleNullType : ITypeObject<double?>
    {

        public double? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public double? ConvertValue(object value, double? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            double rtnValue = 0;
            double.TryParse(value.ToString(), out rtnValue);
            return rtnValue;
        }
    }
}
