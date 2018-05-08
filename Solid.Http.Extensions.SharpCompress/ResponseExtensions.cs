using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Solid.Http.Extensions.SharpCompress
{
    public static class ResponseExtensions
    {
        public static async Task<T> As<T>(this SolidHttpRequest request, SharpCompressOptions options)
        {
            var factory = new SharpCompressResponseDeserializerFactory(options);
            var deserialize = factory.CreateDeserializer<T>();
            return await request.As<T>();
        }
    }
}
