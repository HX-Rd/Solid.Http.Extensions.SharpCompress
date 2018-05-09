using Solid.Http.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using SharpCompress.Archives.Zip;
using HXRd.Solid.Http.Extensions.SharpCompress.Abstraction;
using SharpCompress.Readers;
using SharpCompress.Archives.Rar;
using SharpCompress.Archives.GZip;
using SharpCompress.Archives.SevenZip;
using SharpCompress.Archives.Tar;
using System.Linq;
using SharpCompress.Readers.Zip;

namespace HXRd.Solid.Http.Extensions.SharpCompress
{
    internal class SharpCompressResponseDeserializerFactory : IResponseDeserializerFactory
    {

        public SharpCompressResponseDeserializerFactory(ISharpCompressSerializerSettingsProvider provider)
        {
            GetReaderOptions = () => provider.GetReaderOptions();
        }

        internal SharpCompressResponseDeserializerFactory(SharpCompressOptions options)
        {
            GetReaderOptions = () => options;
        }

        private Func<SharpCompressOptions> GetReaderOptions { get; }

        public Func<HttpContent, Task<T>> CreateDeserializer<T>()
        {
            if (typeof(T) == typeof(ZipArchive))
            {
                return async (content) =>
                {
                    var ms = new MemoryStream();
                    await content.CopyToAsync(ms);
                    var arch = ZipArchive.Open(ms, GetReaderOptions().ReaderOptions);
                    return (T)((object)arch);
                };
            }
            if (typeof(T) == typeof(RarArchive))
            {
                return async (content) =>
                {
                    var ms = new MemoryStream();
                    await content.CopyToAsync(ms);
                    ms.Position = 0;
                    var arch = RarArchive.Open(ms, GetReaderOptions().ReaderOptions);
                    return (T)((object)arch);
                };
            }
            if (typeof(T) == typeof(GZipArchive))
            {
                return async (content) =>
                {
                    var ms = new MemoryStream();
                    await content.CopyToAsync(ms);
                    ms.Position = 0;
                    var arch = GZipArchive.Open(ms, GetReaderOptions().ReaderOptions);
                    return (T)((object)arch);
                };
            }
            if (typeof(T) == typeof(SevenZipArchive))
            {
                return async (content) =>
                {
                    var ms = new MemoryStream();
                    await content.CopyToAsync(ms);
                    ms.Position = 0;
                    var arch = SevenZipArchive.Open(ms, GetReaderOptions().ReaderOptions);
                    return (T)((object)arch);
                };
            }
            if (typeof(T) == typeof(TarArchive))
            {
                return async (content) =>
                {
                    if(GetReaderOptions().TarArchivesAreGziped)
                    {
                        var outerms = new MemoryStream();
                        await content.CopyToAsync(outerms);
                        outerms.Position = 0;
                        var gzarch = GZipArchive.Open(outerms, GetReaderOptions().ReaderOptions);
                        var entry = gzarch.Entries.FirstOrDefault();
                        using (var readGzStream = entry.OpenEntryStream())
                        {
                            var innerms = new MemoryStream();
                            readGzStream.CopyTo(innerms);
                            innerms.Position = 0;
                            var tararch = TarArchive.Open(innerms, GetReaderOptions().ReaderOptions);
                            return (T)((object)tararch);
                        }
                    }
                    else
                    {
                        var ms = new MemoryStream();
                        await content.CopyToAsync(ms);
                        ms.Position = 0;
                        var arch = TarArchive.Open(ms, GetReaderOptions().ReaderOptions);
                        return (T)((object)arch);
                    }
                };
            }
            else throw new NotSupportedException("Type not supported");
        }
    }
}
