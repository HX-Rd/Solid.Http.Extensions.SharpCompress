﻿using Microsoft.Extensions.DependencyInjection;
using SharpCompress.Readers;
using Solid.Http.Abstractions;
using HXRd.Solid.Http.Extensions.SharpCompress.Abstraction;
using HXRd.Solid.Http.Extensions.SharpCompress.Providers;
using System;
using System.Collections.Generic;
using System.Text;
using Solid.Http;

namespace HXRd.Solid.Http.Extensions.SharpCompress
{
    public static class SolidHttpCoreBuilderExtensions
    {
        public static ISolidHttpCoreBuilder AddSharpCompress(this ISolidHttpCoreBuilder builder, SharpCompressOptions options = default(SharpCompressOptions))
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
