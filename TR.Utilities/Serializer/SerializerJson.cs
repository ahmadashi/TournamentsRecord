using System;
using System.Text;
using Newtonsoft.Json;

namespace TR.Utilities.Serialization
{
    public class SerializerJson : ISerializer
    {
        public TResult DeserializeTo<TResult>(byte[] args) where TResult : class
        {
            return JsonConvert.DeserializeObject<TResult>(Encoding.UTF8.GetString(args));
        }

        public object DeserializeToType(byte[] args, Type type)
        {
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(args), type);
        }

        public byte[] ToPayload(object o)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(o));
        }

        public string ToJsonStringContent(object o)
        {
            return JsonConvert.SerializeObject(o);
        }
    }
}
