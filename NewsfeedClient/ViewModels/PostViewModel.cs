using NewsfeedClient.Models;
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

        public PostViewModel(Post post, Source source)
        {
            Id = post.Id;
            TimePosted = post.TimePosted;
            Source = source.Name;
            Content = post.Content;
            Attachments = post.Attachments;
        }
    }
}
