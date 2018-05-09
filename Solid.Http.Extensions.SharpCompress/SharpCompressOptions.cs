using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HXRd.Solid.Http.Extensions.SharpCompress
{
    public class SharpCompressOptions
    {
        public ReaderOptions ReaderOptions { get; set; }
        public List<string> MimeTypes { get; set; }

        public bool TarArchivesAreGziped { get; set; } = true;

        public SharpCompressOptions() : this(new ReaderOptions(), new List<string>()) { }
        public SharpCompressOptions(List<string> mimeTypes) : this(new ReaderOptions(), mimeTypes, true) { }
        public SharpCompressOptions(ReaderOptions options, bool useDefaultMimeTypes = true) : this(options, new List<string>(), useDefaultMimeTypes) { }
        public SharpCompressOptions(ReaderOptions options, List<string> mimeTypes, bool useDefaultMimeTypes = true)
        {
            var defaultMimeTypes = new List<string>
            {
                "application/zip",
                "application/x-rar-compressed",
                "application/x-tar",
                "application/x-7z-compressed"
            };
            if (useDefaultMimeTypes)
                mimeTypes.AddRange(defaultMimeTypes.Where(d => !mimeTypes.Any(m => m == d)));
            ReaderOptions = options;
            MimeTypes = mimeTypes;
        }
    }
}
