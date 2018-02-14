using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class User
    {
        public int Id;
        public string Username;
        public string Password;
        public ICollection<Digest> Digests;
    }
}
