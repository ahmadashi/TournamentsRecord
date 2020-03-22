using System;
using System.Net.Http;

namespace TR.Utilities.Serialization
{
    public interface ISerializer
    {
        TResult DeserializeTo<TResult>(byte[] args) where TResult : class;

        object DeserializeToType(byte[] args, Type type);

        byte[] ToPayload(object o);

        string ToJsonString(object o);

        StringContent ToJsonStringContent(object o);
    }
}