using HXRd.Solid.Http.Extensions.SharpCompress.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using SharpCompress.Readers;
using HXRd.Solid.Http.Extensions.SharpCompress;

namespace HXRd.Solid.Http.Extensions.SharpCompress.Providers
{
    public class SharpCompressSerializerSettingsProvider : ISharpCompressSerializerSettingsProvider
    {
        private SharpCompressOptions _options;

        public SharpCompressSerializerSettingsProvider(SharpCompressOptions options)
        {
            _options = options;
        }

        public SharpCompressOptions GetReaderOptions()
        {
            return _options;
        }
    }
}
