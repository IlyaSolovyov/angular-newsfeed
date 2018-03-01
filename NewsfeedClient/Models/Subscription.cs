using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Subscription
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int DigestId { get; set; }
        public Digest Digest { get; set; }
    }
}
