using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Source
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Service { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
