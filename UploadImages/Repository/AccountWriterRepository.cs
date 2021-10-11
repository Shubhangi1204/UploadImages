using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UploadImages.ApplicationModels;
using UploadImages.Models;

namespace UploadImages.Repository
{
    public class AccountWriterRepository : IAccountWriter
    {
        private readonly UploadImagesContext _db;
        private readonly IMapper _mapper;

        public AccountWriterRepository(UploadImagesContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ApplicationAccount> Create(ApplicationAccount savedSearch)
        {
            var entity = _mapper.Map<Account>(savedSearch);

            _db.Accounts.Add(entity);

            await _db.SaveChangesAsync();

            return _mapper.Map<ApplicationAccount>(entity);
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await _db.Accounts
                .FirstOrDefaultAsync(e => e.Id == id);
            

            if (entity != null)
            {
                _db.Accounts.Remove(entity);
                
                var listPostsEntities = _db.Posts.Where(x => x.CreatorId == id);
                if (listPostsEntities != null)
                {
                    _db.Posts.RemoveRange(listPostsEntities);
                }
                var listCommentsEntities = _db.Comments.Where(x=> x.CreatorId==id);
                if(listCommentsEntities != null)
                {
                    _db.Comments.RemoveRange(listCommentsEntities);
                }

                await _db.SaveChangesAsync();
            }

            return true;
        }

    }
}
