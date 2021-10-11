using MediatR;
using System;
using UploadImages.ApplicationModels;

namespace UploadImages.Actions
{
    public class CreatePostCommand : IRequest<ApplicationPost>
    {
        public string Caption { get; set; }
        public byte[] Image { get; set; }
        public int CreatorId { get; set; }
        public string CreatorName { get; set; }

        public CreatePostCommand(string caption,byte[] image,int createdById, string createdByName)
        {
            Caption = caption;
            Image = image;
            CreatorId = createdById;
            CreatorName = createdByName;
        }
    }
}
