using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime TimePosted { get; set; }       
        public string Content { get; set; }
        [NotMapped]
        public Object[] Attachments { get; set; }

        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
