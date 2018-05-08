using Microsoft.Extensions.DependencyInjection;
using SharpCompress.Readers;
using Solid.Http.Abstractions;
using Solid.Http.Extensions.SharpCompress.Abstraction;
using Solid.Http.Extensions.SharpCompress.Providers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Http.Extensions.SharpCompress
{
    public static class SolidHttpBuilderExtensions
    {
        public static ISolidHttpBuilder AddSharpCompress(this ISolidHttpBuilder builder, SharpCompressOptions options = default(SharpCompressOptions))
        {
            options = options ?? new SharpCompressOptions();
            if (options.MimeTypes.Count < 1)
                throw new ArgumentException("You have to have at least one mimetype specified");
            var provider = new SharpCompressSerializerSettingsProvider(options);
            builder.Services.AddSingleton<ISharpCompressSerializerSettingsProvider>(provider);
            var mimeTypeTail = options.MimeTypes.GetRange(1, options.MimeTypes.Count - 1);
            builder.Services.AddSolidHttpDeserializer<SharpCompressResponseDeserializerFactory>(options.MimeTypes[0], mimeTypeTail.ToArray());
            return builder;
        }
    }
}
