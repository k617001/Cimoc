using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{

    public class DateTimeNullType : ITypeObject<DateTime?>
    {

        public DateTime? ConvertValue(object value)
        {
            return ConvertValue(value, null);
        }

        public DateTime? ConvertValue(object value, DateTime? defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            return Convert.ToDateTime(value);;
        }
    }
}
