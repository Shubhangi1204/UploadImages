using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.Actions;
using UploadImages.ApplicationModels;
using UploadImages.Models;

namespace UploadImages.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationPost>> CreatePost([FromBody] CreatePostBodyDto post)
        {
            var imageDataStream = new MemoryStream(post.image);
            imageDataStream.Position = 0;

            var actionResult = await _mediator.Send(new CreatePostCommand(
                post.caption,
                post.image,
                post.creatorId,
                post.creatorName)
                );

            return Ok(actionResult);
        }

        [HttpGet]
        public async Task<ActionResult<ApplicationGetPostsResponse>> GetPosts([FromBody] GetPostsBodyDto requestBody)
        {
            var actionResult = await _mediator.Send(new GetPostsCommand(
                requestBody.creatorId,
                requestBody.paginationDetails
                ));

            return Ok(actionResult);
        }
    }
}
