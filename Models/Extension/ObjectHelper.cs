using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Models.Extension
{
    public static class ObjectHelper
    {
        public static byte[] Serialize(this object obj)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                binaryFormatter.Serialize(ms, obj);
                return ms.ToArray();
            }

        }

        public static object Derialize(this byte[] buff, int count)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var ms = new MemoryStream(buff, 0, count))
            {
                return binaryFormatter.Deserialize(ms);
            }

        }
    }
}
