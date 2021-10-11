using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.ApplicationModels;

namespace UploadImages.Actions
{
    public class CreateCommentCommand : IRequest<ApplicationComment>
    {
        public string Content { get; set; }
        public int Postid { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }
        public DateTime CreatedAt { get; set; }

        public CreateCommentCommand(string content, int postId, int creatorId, string creatorName)
        {
            Content = content;
            Postid = postId;
            CreatorId = creatorId;
            CreatorName = creatorName;
            CreatedAt = DateTime.Now;
        }
    }
}
