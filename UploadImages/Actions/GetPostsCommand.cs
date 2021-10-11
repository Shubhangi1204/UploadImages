using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Utils;

namespace UploadImages.Actions
{
    public class GetPostsCommand : IRequest<IEnumerable<ApplicationGetPostsResponse>>
    {
        public int CreatorId { get; set; }
        public CustomPaginator Paginator { get; set; }

        public GetPostsCommand(int id, CustomPaginator paginationDetails)
        {
            CreatorId = id;
            Paginator.count = paginationDetails.count;
            Paginator._next = paginationDetails._next;
            Paginator._previous = paginationDetails._previous;
            Paginator.direction = paginationDetails.direction;
        }
    }
}
