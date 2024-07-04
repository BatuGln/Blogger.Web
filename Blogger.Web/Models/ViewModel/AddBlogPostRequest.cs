using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogger.Web.Models.ViewModel
{
    public class AddBlogPostRequest
    {
        public string Heading { get; set; }

        public string Pagetitle { get; set; }

        public string Content { get; set; }

        public string ShortDescription { get; set; }

        public string FeaturedImageUrl { get; set; }

        public string UrlHandle { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Author { get; set; }

        public bool Visible { get; set; }

        //Displaying the Tags
        public  IEnumerable<SelectListItem> Tags{ get; set; }

        //Collecting The Tags from DB

        public string SelectedTag { get; set; }
    }
}
