using NewsfeedClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsfeedClient.ViewModels
{
    public class DigestViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public Boolean IsPublic { get; set; }

        public DigestViewModel(Digest digest)
        {
            Id = digest.Id;
            Name = digest.Name;

            Creator = digest.Creator!=null ? digest.Creator.Username : "Unknown author";
            IsPublic = digest.IsPublic;
        }
    }
}
