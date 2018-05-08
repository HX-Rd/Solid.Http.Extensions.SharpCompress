using SharpCompress.Readers;
using Solid.Http.Extensions.SharpCompress;
using System;
using System.Collections.Generic;
using System.Text;

namespace Solid.Http.Extensions.SharpCompress.Abstraction
{
    public interface ISharpCompressSerializerSettingsProvider
    {
        SharpCompressOptions GetReaderOptions();
    }
}
