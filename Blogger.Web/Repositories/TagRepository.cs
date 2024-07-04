using Blogger.Web.Data;
using Blogger.Web.Models.Domain;
using Blogger.Web.Models.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace Blogger.Web.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly BloggerDbContext bloggerDbContext;

        public TagRepository(BloggerDbContext bloggerDbContext)
        {
            this.bloggerDbContext = bloggerDbContext;
        }
        public async Task<Tag?> AddAsync(Tag tag)
        {

            await bloggerDbContext.Tags.AddAsync(tag);
            await bloggerDbContext.SaveChangesAsync();
            return tag;
        }

        public async Task<Tag?> DeleteAsync(Guid id)
        {
            var existingTag = await bloggerDbContext.Tags.FindAsync(id);
            if (existingTag != null)
            {
                bloggerDbContext.Tags.Remove(existingTag);
                await bloggerDbContext.SaveChangesAsync();
                return existingTag;
            }
            return null;
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await bloggerDbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetAsync(Guid id)
        {
            return await bloggerDbContext.Tags.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Tag?> UpdateAsync(Tag tag)
        {
           var existingTag = await bloggerDbContext.Tags.FindAsync(tag.Id);
            if(existingTag != null) 
            {
                 existingTag.Name = tag.Name;
                 existingTag.Displayname = tag.Displayname;

                await bloggerDbContext.SaveChangesAsync();

                return existingTag;


            }
            return null;
        }
    }
     
}
