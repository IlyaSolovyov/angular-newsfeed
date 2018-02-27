using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Friendship
    {
        public int Friend1Id { get; set; }
        public User Friend1 { get; set; }

        public int Friend2Id { get; set; }
        public User Friend2 { get; set; }
    }
}
