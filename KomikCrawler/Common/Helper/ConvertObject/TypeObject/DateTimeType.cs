using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class DateTimeType : ITypeObject<DateTime>
    {

        public DateTime ConvertValue(object value)
        {
            return ConvertValue(value, DateTime.MinValue);
        }

        public DateTime ConvertValue(object value, DateTime defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            return Convert.ToDateTime(value);
        }
    }
}
