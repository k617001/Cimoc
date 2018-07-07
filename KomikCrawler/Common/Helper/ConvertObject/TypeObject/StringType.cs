using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public class StringType : ITypeObject<string>
    {

        public string ConvertValue(object value)
        {
            return ConvertValue(value, string.Empty);
        }

        public string ConvertValue(object value, string defaultValue)
        {
            if (value == null)
            {
                return defaultValue;
            }

            return value.ToString().Trim();
        }
    }
}
