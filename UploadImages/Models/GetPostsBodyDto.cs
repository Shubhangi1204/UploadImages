using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Utils;

namespace UploadImages.Models
{
    public class GetPostsBodyDto
    {
        public int creatorId { get; set; }

        public CustomPaginator paginationDetails { get; set; }
    }
}
