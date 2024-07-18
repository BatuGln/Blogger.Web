using Blogger.Web.Models.Domain;

namespace Blogger.Web.Models.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable <BlogPost> BlogPosts { get; set; }

        public IEnumerable<Tag> Tags { get; set; }


    }
}
