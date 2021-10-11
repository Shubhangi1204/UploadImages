using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.ApplicationModels;
using UploadImages.Models;

namespace UploadImages.Repository
{
    public class CommentWriterRepository : ICommentWriter
    {
        private readonly UploadImagesContext _db;
        private readonly IMapper _mapper;

        public CommentWriterRepository(UploadImagesContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApplicationComment> Create(ApplicationComment comment)
        {
            var entity = _mapper.Map<Comment>(comment);

            _db.Comments.Add(entity);

            await _db.SaveChangesAsync();

            return _mapper.Map<ApplicationComment>(entity);
        }
    }
}
