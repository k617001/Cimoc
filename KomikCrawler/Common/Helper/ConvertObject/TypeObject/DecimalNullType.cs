using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{

    public class DecimalNullType : ITypeObject<decimal?>
    {

        public decimal? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public decimal? ConvertValue(object value, decimal? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            decimal rtnValue = 0;
            decimal.TryParse(value.ToString(), out rtnValue);
            return rtnValue;
        }
    }
}
