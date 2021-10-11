using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImages.ApplicationModels
{
    public class ApplicationComment
    {
        public int id { get; set; }
        public string content { get; set; }
        public int postid { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }

        public DateTime createdAt { get; set; }
    }
}
