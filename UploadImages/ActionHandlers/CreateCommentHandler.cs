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
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand,ApplicationComment>
    {
        private ICommentWriter _writer;

        public CreateCommentHandler(ICommentWriter writer)
        {
            _writer = writer;
        }
        public Task<ApplicationComment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            return _writer.Create(new ApplicationComment
            {
                content=request.Content,
                postid=request.Postid,
                creatorId=request.CreatorId,
                creatorName=request.CreatorName,
                createdAt=request.CreatedAt
            });
        }
    }
}
