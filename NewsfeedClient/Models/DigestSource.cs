using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class DigestSource
    {
        public int DigestId { get; set; }
        public Digest Digest { get; set; }

        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
