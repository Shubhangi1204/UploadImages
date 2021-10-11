using System;
using System.Collections.Generic;

#nullable disable

namespace UploadImages.Models
{
    public partial class Comment
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public long? PostId { get; set; }
        public long? CreatorId { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual Account Creator { get; set; }
        public virtual Post Post { get; set; }
    }
}
