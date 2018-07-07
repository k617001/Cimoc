using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WinFormTest.Common
{
    public class ItemMap
    {
        static Dictionary<string, Type> containerMap = new Dictionary<string, Type>();

        /// <summary>
        /// 註冊
        /// </summary>
        public ItemMap RegisterItem<T>(string key, string name) where T : Form
        {
            if (containerMap.ContainsKey(key))
            {
                throw new Exception("功能已被註冊 key → " + key);
            }
            containerMap.Add(key, typeof(T));
            return this;
        }

        /// <summary>
        /// 取得實體物件與依賴注入
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetNewItem<T>(string key)
        {
            if (!containerMap.ContainsKey(key))
            {
                throw new Exception("功能未被註冊 idName→ " + key);
            }

            return (T)Activator.CreateInstance(containerMap[key]); ;
        }
    }
}
