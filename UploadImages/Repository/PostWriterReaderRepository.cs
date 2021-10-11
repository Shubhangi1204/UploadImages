using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Models;

namespace UploadImages.Repository
{
    public class PostWriterReaderRepository : IPostWriterReader
    {
        private readonly UploadImagesContext _db;
        private readonly IMapper _mapper;

        public PostWriterReaderRepository(UploadImagesContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApplicationPost> Create(ApplicationPost post)
        {
            var entity = _mapper.Map<Post>(post);

            _db.Posts.Add(entity);

            await _db.SaveChangesAsync();

            return _mapper.Map<ApplicationPost>(entity);
        }

        public Task<IEnumerable<ApplicationGetPostsResponse>> GetPosts(GetPostsCommand request)
        {
            var direction = request.Paginator.direction;
            List<ApplicationGetPostsResponse> result=new List<ApplicationGetPostsResponse>();
            if (direction == "next")
            {
                var data = (from posts in _db.Posts
                            let count = (from a in _db.Comments where a.PostId == posts.Id select a.Id).Count()
                            orderby count descending
                            join
     comments in _db.Comments on posts.Id equals comments.PostId
                            //orderby comments.Id descending
                            //select new { posts, comments } into intermediateResult
                            join account in _db.Accounts on posts.CreatorId equals account.Id
                            where posts.Id > request.Paginator._next
                            orderby posts.Id ascending
                            select posts
                           ).Take(request.Paginator.count).Distinct();
                
                foreach(var post in data)
                {
                    var comments = (from c in _db.Comments
                                    where c.PostId == post.Id
                                    orderby c.CreatedAt descending
                                    select c.Content).Take(2).Distinct().ToList<string>();

                    var object1 = new ApplicationGetPostsResponse { post=post, comments=comments };

                    result.Add(object1);
                }
            }
            else if (direction == "previous")
            {
                var data = (from posts in _db.Posts
                            let count = (from a in _db.Comments where a.PostId == posts.Id select a.Id).Count()
                            orderby count descending
                            join
     comments in _db.Comments on posts.Id equals comments.PostId
                            join account in _db.Accounts on posts.CreatorId equals account.Id
                            where posts.Id < request.Paginator._previous
                            orderby posts.Id descending
                            select posts
                           ).Take(request.Paginator.count).Distinct();

                foreach (var post in data)
                {
                    var comments = (from c in _db.Comments
                                    where c.PostId == post.Id
                                    orderby c.CreatedAt descending
                                    select c.Content).Take(2).Distinct().ToList<string>();

                    var object1 = new ApplicationGetPostsResponse { post = post, comments = comments };

                    result.Add(object1);
                }
            }

            return (Task<IEnumerable<ApplicationGetPostsResponse>>)_mapper.Map<IEnumerable<ApplicationGetPostsResponse>>(result);
        }
    }
}
