using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Source
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Service { get; set; }

        public List<Post> Posts { get; set; }
        public List<DigestSource> DigestSources { get; set; }

        public Source()
        {
            Posts = new List<Post>();
            DigestSources = new List<DigestSource>();
        }
    }
}
