using SharpCompress.Readers;
using HXRd.Solid.Http.Extensions.SharpCompress;
using System;
using System.Collections.Generic;
using System.Text;

namespace HXRd.Solid.Http.Extensions.SharpCompress.Abstraction
{
    public interface ISharpCompressSerializerSettingsProvider
    {
        SharpCompressOptions GetReaderOptions();
    }
}
