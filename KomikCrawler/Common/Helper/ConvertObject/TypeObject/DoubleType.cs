using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class DoubleType : ITypeObject<double>
    {

        public double ConvertValue(object value)
        {
            return ConvertValue(value, 0);
        }

        public double ConvertValue(object value, double defaultValue)
        {
            double rtnValue = 0;
            if (value != null && double.TryParse(value.ToString(), out rtnValue))
            {
                return rtnValue;
            }

            return defaultValue;
        }
    }
}
