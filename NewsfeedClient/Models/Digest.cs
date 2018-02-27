using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.Models
{
    public class Digest
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public Boolean IsPublic { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public List<Subscription> Subscribers { get; set; }
        public List<DigestSource> DigestSources { get; set; }

        public Digest()
        {
            Subscribers = new List<Subscription>();
            DigestSources = new List<DigestSource>();
        }
    }
}
