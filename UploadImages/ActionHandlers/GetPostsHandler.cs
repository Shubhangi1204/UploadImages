using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Repository;

namespace UploadImages.ActionHandlers
{
    public class GetPostsHandler : IRequestHandler<GetPostsCommand, IEnumerable<ApplicationGetPostsResponse>>
    {
        private IPostWriterReader _writer;

        public GetPostsHandler(IPostWriterReader writer)
        {
            _writer = writer;
        }

        public async Task<IEnumerable<ApplicationGetPostsResponse>> Handle(GetPostsCommand request, CancellationToken cancellationToken)
        {
            var posts = await _writer.GetPosts(request);

            return posts;
        }
    }
}
