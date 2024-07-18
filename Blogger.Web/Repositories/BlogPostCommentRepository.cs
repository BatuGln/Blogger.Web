using Blogger.Web.Data;
using Blogger.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BloggerDbContext bloggerDbContext;

        public BlogPostCommentRepository(BloggerDbContext bloggerDbContext)
        {
            this.bloggerDbContext = bloggerDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await bloggerDbContext.BlogPostComment.AddAsync(blogPostComment);
            await bloggerDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetCommentslAsync(Guid blogPostId)
        {
            return await bloggerDbContext.BlogPostComment.Where(x =>x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
