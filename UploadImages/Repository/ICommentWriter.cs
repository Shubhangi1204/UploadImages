using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.ApplicationModels;

namespace UploadImages.Repository
{
    public interface ICommentWriter
    {
        Task<ApplicationComment> Create(ApplicationComment comment);
    }
}
