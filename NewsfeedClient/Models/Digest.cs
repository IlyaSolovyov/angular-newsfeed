using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Digest
    {
        public int Id;
        public string Name;
        public User Creator;
        public Boolean Public;
        public ICollection<Source> Sources;
    }
}
