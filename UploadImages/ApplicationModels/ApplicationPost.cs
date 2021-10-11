using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UploadImages.ApplicationModels
{
    public class ApplicationPost
    {
        public int Id { get; set; }
        public string caption { get; set; }
        public byte[] image { get; set; }
        public int creatorId { get; set; }
        public string creatorName { get; set; }
        public DateTime createdAt { get; set; }
    }
}
