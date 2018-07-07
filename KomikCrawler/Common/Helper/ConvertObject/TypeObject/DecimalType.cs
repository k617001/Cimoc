using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class DecimalType : ITypeObject<decimal>
    {

        public decimal ConvertValue(object value)
        {
            return ConvertValue(value, 0);
        }

        public decimal ConvertValue(object value, decimal defaultValue)
        {
            decimal rtnValue = 0;
            if (value != null && decimal.TryParse(value.ToString(), out rtnValue))
            {
                return rtnValue;
            }

            return defaultValue;
        }
    }
}
