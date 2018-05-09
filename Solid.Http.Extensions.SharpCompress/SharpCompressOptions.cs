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

        public SharpCompressOptions() : this(new ReaderOptions(), new List<string>(), true, true) { }
        public SharpCompressOptions(List<string> mimeTypes, bool useDefaultMimeTypes = true, bool tarArchivesAreGziped = true) : this(new ReaderOptions(), mimeTypes, useDefaultMimeTypes, tarArchivesAreGziped) { }
        public SharpCompressOptions(ReaderOptions options, bool useDefaultMimeTypes = true, bool tarArchivesAreGziped = true) : this(options, new List<string>(), useDefaultMimeTypes, tarArchivesAreGziped) { }
        public SharpCompressOptions(ReaderOptions options, List<string> mimeTypes, bool useDefaultMimeTypes = true, bool tarArchivesAreGziped = true)
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
            TarArchivesAreGziped = tarArchivesAreGziped;
            ReaderOptions = options;
            MimeTypes = mimeTypes;
        }
    }
}
