using System;

namespace TR.Utilities.Serialization
{
    public interface ISerializer
    {
        TResult DeserializeTo<TResult>(byte[] args) where TResult : class;

        object DeserializeToType(byte[] args, Type type);

        byte[] ToPayload(object o);

        string ToJsonStringContent(object o);
    }
}