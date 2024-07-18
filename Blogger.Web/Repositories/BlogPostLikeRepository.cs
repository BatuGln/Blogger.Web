
using Blogger.Web.Data;
using Blogger.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BloggerDbContext bloggerDbContext;

        public BlogPostLikeRepository(BloggerDbContext bloggerDbContext)
        {
            this.bloggerDbContext = bloggerDbContext;
        }

        public async Task<BlogPostLike> AddLikeForBlog(BlogPostLike blogPostLike)
        {
            await bloggerDbContext.BlogPostsLike.AddAsync(blogPostLike);
            await bloggerDbContext.SaveChangesAsync();
            return blogPostLike;
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
           return await bloggerDbContext.BlogPostsLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikes(Guid blogPostId)
        {
         return await bloggerDbContext.BlogPostsLike.CountAsync(x =>x.BlogPostId == blogPostId);       
        }
    }
}
