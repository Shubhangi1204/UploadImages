using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Repository;

namespace UploadImages.ActionHandlers
{
    public class CreatePostHandler:IRequestHandler<CreatePostCommand, ApplicationPost>
    {
        private IPostWriterReader _writer;

        public CreatePostHandler(IPostWriterReader writer)
        {
            _writer = writer;
        }
        public Task<ApplicationPost> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            return _writer.Create(new ApplicationPost
            {
                caption=request.Caption,
                image=request.Image,
                creatorId=request.CreatorId,
                creatorName=request.CreatorName,
                createdAt= DateTime.Now
            });
        }
    }
}
