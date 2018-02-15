using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Digest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User Creator { get; set; }
        public Boolean IsPublic { get; set; }
        public ICollection<Source> Sources { get; set; }
    }
}
