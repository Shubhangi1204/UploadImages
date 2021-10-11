using System.Collections.Generic;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;

namespace UploadImages.Repository
{
    public interface IPostWriterReader
    {
        Task<ApplicationPost> Create(ApplicationPost post);

        Task<IEnumerable<ApplicationGetPostsResponse>> GetPosts(GetPostsCommand request);
    }
}
