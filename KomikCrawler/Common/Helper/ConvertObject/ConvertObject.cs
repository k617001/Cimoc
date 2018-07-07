using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject
{
    public class ConvertObjectHelper
    {
        /// <summary>
        /// 物件轉型使用
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T To<T>(object value)
        {
            return TypeFactory.GetInstance<T>().ConvertValue(value);
        }

        /// <summary>
        /// 轉型使用，調整預設值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static T To<T>(object value, T defaultValue)
        {
            return TypeFactory.GetInstance<T>().ConvertValue(value, defaultValue);
        }
    }
}
