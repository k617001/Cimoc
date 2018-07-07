using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CommonUtil.ObjectContainer
{
    public class Container
    {
        static Dictionary<Type, Type> containerMap = new Dictionary<Type, Type>();

        /// <summary>
        /// 註冊
        /// </summary>
        public Container RegisterType<T1, T2>() where T2 : T1
        {
            Type regType = typeof(T1);
            if (containerMap.ContainsKey(regType))
            {
                throw new Exception("您註冊的type已重覆 → " + regType.Name);
            }
            containerMap.Add(typeof(T1), typeof(T2));
            return this;
        }

        /// <summary>
        /// 取得實體物件與依賴注入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetInstance<T>()
        {
            Type regType = typeof(T);
            if (!containerMap.ContainsKey(regType))
            {
                throw new Exception("查無註冊的type → " + regType.Name);
            }

            Type obj = containerMap[regType];
            return (T)Activator.CreateInstance(obj);
        }
        /*
        /// <summary>
        /// 產生DI後的物件
        /// </summary>
        class CreateContainerDIInstance
        {
            public static T CreateInstance<T>(Type objType)
            {
                ConstructorInfo[] constructors = objType.GetConstructors();
                if (constructors.Count() == 0)
                {
                    return (T)Activator.CreateInstance(objType);
                }

                foreach (ConstructorInfo constructorInfo in constructors)
                {
                    Type type = constructorInfo.GetType();
                    Console.WriteLine(type.Name);
                }
            }
        }
         * */
    }
}
