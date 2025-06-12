using Portfo.Services.Contracts;
using System;
using System.Threading.Tasks;
using Portfo.Repo.SqlDatabase.Contracts;

using DTO = Portfo.Repo.SqlDatabase.DTO;
using S = Portfo.Services.Model;

namespace Portfo.Services
{
    public class PostService(IPostRepository repo, IActivityRepository activityRepo, IUserRepository userRepo) : IPostService
    {
        readonly IPostRepository _repo = repo;
        readonly IActivityRepository _activityRepo = activityRepo;
        readonly IUserRepository _userRepo = userRepo;

        public async Task<S.Post> CreateAsync(S.Post post)
        {
            var dtoPost = new DTO.Post()
            {
                AuthorID = post.PostAuthor.AuthorID,
                CreationDate = DateTime.UtcNow,
                Description = post.PostDescription,
                ID = post.PostID,
                LastUpdateDate = DateTime.UtcNow,
                Title = post.PostTitle
            };

            var postNew = await _repo.CreateAsync(dtoPost);
            var user = _userRepo.GetAsync(post.PostAuthor.AuthorID.ToString());
            await _activityRepo.InsertAsync(new DTO.Activity()
            {
                OccuredAt = DateTime.UtcNow,
                ID = Guid.NewGuid(),
                AuthorID = post.PostAuthor.AuthorID,
                Operation = (byte)DTO.Activity.Type.CREATE,
                PostID = postNew.ID,
                AuthorFirstname = user.Firstname,
                AuthorLastname = user.Lastname
            });

            return new S.Post()
            {
                PostAuthor = new S.PostUser()
                {
                    AuthorID = postNew.AuthorID
                },
                CreationDate = postNew.CreationDate,
                PostDescription = postNew.Description,
                PostID = postNew.ID,
                LastUpdateDate = postNew.LastUpdateDate,
                PostTitle = postNew.Title
            };
        }

        public async Task<bool> UpdateAsync(S.Post user)
        {
            var userGet = _userRepo.GetAsync(user.PostAuthor.AuthorID.ToString());

            var activityNew = await _activityRepo.InsertAsync(new DTO.Activity()
            {
                OccuredAt = DateTime.UtcNow,
                ID = Guid.NewGuid(),
                AuthorID = user.PostAuthor.AuthorID,
                Operation = (byte)DTO.Activity.Type.UPDATE,
                PostID = user.PostID,
                AuthorFirstname = userGet.Firstname,
                AuthorLastname = userGet.Lastname
            });

            var postNew = await _repo.UpdateAsync(new DTO.Post
            {
                AuthorID = user.PostAuthor.AuthorID,
                CreationDate = user.CreationDate,
                Description = user.PostDescription,
                ID = user.PostID,
                LastUpdateDate = DateTime.UtcNow,
                Title = user.PostTitle
            });

            return activityNew != default(DTO.Activity) && activityNew.AuthorID == user.PostAuthor.AuthorID &&
                postNew != default(DTO.Post) && postNew.AuthorID == user.PostAuthor.AuthorID &&
                postNew.CreationDate == user.CreationDate && postNew.Description == user.PostDescription &&
                postNew.ID == user.PostID &&
                postNew.Title == user.PostTitle;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var postGet = await GetAsync(new Guid(id));
            var userGet = _userRepo.GetAsync(postGet.PostAuthor.AuthorID.ToString());
            await _activityRepo.InsertAsync(new DTO.Activity()
            {
                OccuredAt = DateTime.UtcNow,
                ID = Guid.NewGuid(),
                AuthorID = postGet.PostAuthor.AuthorID,
                Operation = (byte)DTO.Activity.Type.DELETE,
                PostID = new Guid(id),
                AuthorFirstname = userGet.Firstname,
                AuthorLastname = userGet.Lastname
            });

            return await _repo.DeleteAsync(id) > 0;
        }

        public async Task<S.Post> GetAsync(Guid id)
        {
            var postNew = _repo.GetAsync(id.ToString());

            if (postNew != default(DTO.Post))
            {
                return new S.Post()
                {
                    PostAuthor = new S.PostUser()
                    {
                        AuthorID = postNew.AuthorID
                    },
                    CreationDate = postNew.CreationDate,
                    PostDescription = postNew.Description,
                    PostID = postNew.ID,
                    LastUpdateDate = postNew.LastUpdateDate,
                    PostTitle = postNew.Title
                };
            }
            else
            {
                return default;
            }
        }
    }
}
