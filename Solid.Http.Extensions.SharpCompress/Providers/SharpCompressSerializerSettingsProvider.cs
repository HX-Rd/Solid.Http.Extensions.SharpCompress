using Solid.Http.Extensions.SharpCompress.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;
using SharpCompress.Readers;
using Solid.Http.Extensions.SharpCompress;

namespace Solid.Http.Extensions.SharpCompress.Providers
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
