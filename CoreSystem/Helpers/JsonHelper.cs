using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CoreSystem.Helpers
{
    public class JsonHelper
    {
        public static string ConvertToJson<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            }
        }
    }
}
