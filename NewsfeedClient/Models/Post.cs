﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Post
    {
        public int Id { get; set; }
        public DateTime TimePosted { get; set; }       
        public string Content { get; set; }
        public Object[] Attachments { get; set; }

        public int SourceId { get; set; }
        public Source Source { get; set; }
    }
}
