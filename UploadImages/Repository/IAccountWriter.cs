using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.ApplicationModels;

namespace UploadImages.Repository
{
    public interface IAccountWriter
    {
        Task<ApplicationAccount> Create(ApplicationAccount account);

        Task<bool> Delete(int Id);
    }
}
