using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrawlerCommon.Helper.ConvertObject.TypeObject;

namespace CrawlerCommon.Helper.ConvertObject
{
    class TypeFactory
    {
        public static ITypeObject<T> GetInstance<T>() 
        {
            Type convertType = typeof(T);
            switch (Type.GetTypeCode(convertType))
            {
                case TypeCode.Int16:
                    return (ITypeObject<T>)new ShortType();

                case TypeCode.Int32:
                    return (ITypeObject<T>)new IntType();

                case TypeCode.Int64:
                    return (ITypeObject<T>)new LongType();

                case TypeCode.Double:
                    return (ITypeObject<T>)new DoubleType();

                case TypeCode.Decimal:
                    return (ITypeObject<T>)new DoubleType();

                case TypeCode.String:
                    return (ITypeObject<T>)new StringType();

                case TypeCode.Boolean:
                    return (ITypeObject<T>)new BoolType();

                case TypeCode.Char:
                    return (ITypeObject<T>)new CharType();

                case TypeCode.DateTime:
                    return (ITypeObject<T>)new DateTimeType();

                case TypeCode.Object:
                    return GetNullableInstance<T>(convertType); //基本型別給null
            }

            throw new Exception("沒有可轉型的型態→" + convertType.ToString());
        }

        /// <summary>
        /// 註冊nullable物件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static ITypeObject<T> GetNullableInstance<T>(Type convertType)
        {

            if (convertType == typeof(int?))
            {
                return (ITypeObject<T>)new IntNullType();
            }
            else if (convertType == typeof(double?))
            {
                return (ITypeObject<T>)new DoubleNullType();
            }
            else if (convertType == typeof(long?))
            {
                return (ITypeObject<T>)new LongNullType();
            }
            else if (convertType == typeof(short?))
            {
                return (ITypeObject<T>)new ShortNullType();
            }
            else if (convertType == typeof(decimal?))
            {
                return (ITypeObject<T>)new DecimalNullType();
            }
            else if (convertType == typeof(bool?))
            {
                return (ITypeObject<T>)new BoolNullType();
            }
            else if (convertType == typeof(DateTime?))
            {
                return (ITypeObject<T>)new DateTimeNullType();
            }

            throw new Exception("沒有可轉型的型態→" + convertType.ToString());
        }
    }
}
