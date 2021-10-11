using System;
using System.Collections.Generic;

#nullable disable

namespace UploadImages.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public long Id { get; set; }
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public long? CreatorId { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Account Creator { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
