using Blogger.Web.Models.Domain;
using Blogger.Web.Models.ViewModel;
using Blogger.Web.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogPostRepository blogPostRepository;
        private readonly IBlogPostLikeRepository blogPostLikeRepository;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBlogPostCommentRepository blogPostCommentRepository;

        public BlogsController(IBlogPostRepository blogPostRepository,
            IBlogPostLikeRepository blogPostLikeRepository,
            SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> userManager,
            IBlogPostCommentRepository blogPostCommentRepository)
        {
            this.blogPostRepository = blogPostRepository;
            this.blogPostLikeRepository = blogPostLikeRepository;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.blogPostCommentRepository = blogPostCommentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index(string urlHandle)
        {
           var like = false;
           var blogPost = await blogPostRepository.GetByUrlhandleAsync(urlHandle);
            var blogPostLikeViewModel = new BlogDetailsViewModel();




            if (blogPost != null) 
            {
              var totalLikes = await  blogPostLikeRepository.GetTotalLikes(blogPost.Id);

                if (signInManager.IsSignedIn(User))
                {
                    var likesForBlog = await blogPostLikeRepository.GetLikesForBlog(blogPost.Id);

                    var userId = userManager.GetUserId(User);

                    if (userId != null) 
                    {
                      var likeFromUser =likesForBlog.FirstOrDefault(x =>x.UserId == Guid.Parse(userId));
                        like = likeFromUser != null;
                    }

                }
                var blogCommentsDomainmodel = await blogPostCommentRepository.GetCommentslAsync(blogPost.Id);

                var blogCommentForView = new List<BlogComment>();
                
                   foreach(var blogComment in blogCommentsDomainmodel)
                {
                        blogCommentForView.Add(new BlogComment
                        {
                            Description = blogComment.Description,
                            DateAdded = blogComment.DateAdd,
                            Username = (await userManager.FindByIdAsync(blogComment.UserId.ToString())).UserName
                        });
                }
                

                blogPostLikeViewModel = new BlogDetailsViewModel
                {
                    Id = blogPost.Id,
                    Content = blogPost.Content,
                    Pagetitle = blogPost.Pagetitle,
                    Author = blogPost.Author,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    Heading = blogPost.Heading,
                    PublishedDate = blogPost.PublishedDate,
                    ShortDescription = blogPost.ShortDescription,
                    UrlHandle = blogPost.UrlHandle,
                    Visible = blogPost.Visible,
                    Tags = blogPost.Tags,
                    TotalLikes = totalLikes,
                    Like = like,
                    Comments = blogCommentForView
                };
            }
            return View(blogPostLikeViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Index(BlogDetailsViewModel blogDetailsViewModel)
        {
            if (signInManager.IsSignedIn(User))
            {
                var domainModel = new BlogPostComment
                {
                    BlogPostId = blogDetailsViewModel.Id,
                    Description = blogDetailsViewModel.CommentDescription,
                    UserId = Guid.Parse(userManager.GetUserId(User)),
                    DateAdd = DateTime.Now
                };

               await blogPostCommentRepository.AddAsync(domainModel);

                return RedirectToAction("Index", "Blogs", new {urlHandle = blogDetailsViewModel.UrlHandle});

            }
            return View();

        }
    }
}
