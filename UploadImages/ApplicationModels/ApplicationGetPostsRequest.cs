using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Utils;

namespace UploadImages.ApplicationModels
{
    public class ApplicationGetPostsRequest
    {
        public int CreatorId { get; set; }
        public CustomPaginator Paginator { get; set; }
    }
}
