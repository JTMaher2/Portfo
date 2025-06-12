using Portfo.Services.Contracts;
using S = Portfo.Services.Model;
using System.Threading.Tasks;
using Portfo.Repo.SqlDatabase.Contracts;
using DTO = Portfo.Repo.SqlDatabase.DTO;
using System;

namespace Portfo.Services
{
    public class LikeService(ILikeRepository repo) : ILikeService
    {
        readonly ILikeRepository _repo = repo;

        public async Task<S.Like> CreateAsync(S.Like like)
        {
            DTO.Like likeNew = await _repo.CreateAsync(new DTO.Like()
            {
                ID = like.LikeID,
                CreationDate = DateTime.UtcNow,
                AuthorID = like.LikeAuthor.AuthorID,
                LastUpdateDate = DateTime.UtcNow,
                PostID = like.LikePost.PostID
            });

            return new S.Like()
            {
                CreationDate = likeNew.CreationDate,
                LikeID = likeNew.ID,
                LastUpdateDate = likeNew.LastUpdateDate,
                LikeAuthor = new S.PostUser()
                {
                    AuthorID = Guid.NewGuid()
                },
                LikePost = new S.LikePost()
                {
                    PostID = Guid.NewGuid()
                }
            };
        }

        public async Task<bool> DeleteAsync(string id)
        {
            return await _repo.DeleteAsync(id) > 0;
        }
    }
}
