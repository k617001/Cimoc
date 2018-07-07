using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper.ConvertObject.TypeObject
{
    public interface ITypeObject<T>
    {
        /// <summary>
        /// 轉型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        T ConvertValue(object value);

        /// <summary>
        /// 轉型給預設值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        T ConvertValue(object value, T defaultValue);
    }
}
