using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.ViewModels
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public DateTime TimePosted { get; set; }
        public string Source { get; set; }
        public string Content { get; set; }
        public Object[] Attachments { get; set; }
    }
}
