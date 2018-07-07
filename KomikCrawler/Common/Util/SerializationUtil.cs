using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CrawlerCommon.Helper
{

    [Serializable]
    public class SerializationUtil
    {
        public void Action()
        {
            byte[] ser = SerializationUtil.Serialization(this);
            SerializationUtil util = SerializationUtil.ToObject<SerializationUtil>(ser);
            byte[] ser2 = util.Serialization1(this);

            print(ser);
            print(ser2);
        }

        private void print(byte[] bb)
        {
            StringBuilder result = new StringBuilder();
            foreach (byte b in bb)
            {
                result.Append(b);
            }
            Console.WriteLine(result);
            Console.WriteLine("------------------------------------------------------------");

        }

        private byte[] Serialization1(object source)
        {
            return SerializationUtil.Serialization(source);
        }

        /// <summary>
        /// 物件序列化
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static byte[] Serialization(object source)
        {
            var Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            byte[] result;
            using (var stream = new System.IO.MemoryStream())
            {
                Formatter.Serialize(stream, source);
                result = stream.ToArray();
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T ToObject<T>(byte[] source)
        {
            var Formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            using (var stream = new System.IO.MemoryStream(source))
            {
                return (T)Formatter.Deserialize(stream);
            }
        }
    }
}
