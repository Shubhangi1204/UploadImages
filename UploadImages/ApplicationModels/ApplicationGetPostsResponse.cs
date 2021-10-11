using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Models;

namespace UploadImages.ApplicationModels
{
    public class ApplicationGetPostsResponse
    {
        public Post post { get; set; }
        public List<string> comments { get; set; }
    }
}
