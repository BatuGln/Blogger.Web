using Blogger.Web.Models.Domain;
using Blogger.Web.Models.ViewModel;
using Blogger.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Blogger.Web.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly ITagRepository tagRepository;
        private readonly IBlogPostRepository blogPostRepository;

        public AdminBlogPostsController(ITagRepository tagRepository,IBlogPostRepository blogPostRepository)
        {
            this.tagRepository = tagRepository;
            this.blogPostRepository = blogPostRepository;
        }

        [HttpGet]
       public async Task< IActionResult> Add() 
        {
            //get tags from repo
            var tags = await tagRepository.GetAllAsync();

            var model = new AddBlogPostRequest
            {
                Tags = tags.Select(x => new SelectListItem { Text = x.Displayname, Value = x.Id.ToString() })
            };

            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddBlogPostRequest addBlogPostRequest)
        {
            //mapping
            var blogpost = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                Pagetitle = addBlogPostRequest.Pagetitle,
                Content = addBlogPostRequest.Content,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible,

            };
            var selectedTags = new List<Tag>();
            //map tags from selected
            foreach (var selectedTagId in addBlogPostRequest.SelectedTag)
            {

                var selectedTagGuid = Guid.Parse(selectedTagId);
               var existingTag =  await tagRepository.GetAsync(selectedTagGuid);

                if (existingTag != null) 
                {
                selectedTags.Add(existingTag);
                }
            }
            blogpost.Tags = selectedTags;
            //mapping back to model
            await blogPostRepository.AddAsync(blogpost);
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            //call repo
           var blogPost = await blogPostRepository.GetAllAsync();

            return View(blogPost);  
         
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            // getting result from repo
           var blogPost = await blogPostRepository.GetAsync(id);
            var tagsDomainModel = await tagRepository.GetAllAsync();
            if(blogPost != null) 
            {
                //mapping 
                var model = new EditBlogPostRequest
                {

                    Id = blogPost.Id,
                    Heading = blogPost.Heading,
                    Pagetitle = blogPost.Pagetitle,
                    Content = blogPost.Content,
                    Author = blogPost.Author,
                    FeaturedImageUrl = blogPost.FeaturedImageUrl,
                    UrlHandle = blogPost.UrlHandle,
                    ShortDescription = blogPost.ShortDescription,
                    PublishedDate = blogPost.PublishedDate,
                    Visible = blogPost.Visible,
                    Tags = tagsDomainModel.Select(t => new SelectListItem { Text = t.Name, Value = t.Id.ToString() }),
                    SelectedTag = blogPost.Tags.Select(a => a.Id.ToString()).ToArray(),

                };
                return View(model);
            }
           

            //pass to view
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult>Edit(EditBlogPostRequest editBlogPostRequest)
        {
            //mapp vievmodel  back to domain model
            var blogPostDomainModel = new BlogPost
            {
                Id = editBlogPostRequest.Id,
                Heading = editBlogPostRequest.Heading,
                Pagetitle = editBlogPostRequest.Pagetitle,
                Content = editBlogPostRequest.Content,
                Author = editBlogPostRequest.Author,
                ShortDescription = editBlogPostRequest.ShortDescription,
                FeaturedImageUrl = editBlogPostRequest.FeaturedImageUrl,
                PublishedDate = editBlogPostRequest.PublishedDate,
                UrlHandle = editBlogPostRequest.UrlHandle,
                Visible = editBlogPostRequest.Visible,
            };

            var selectedTags = new List<Tag>();
            foreach(var selectedTag in editBlogPostRequest.SelectedTag)
            {

                if(Guid.TryParse(selectedTag, out var tag))
                {
                    var foundTag = await tagRepository.GetAsync(tag);

                    if (foundTag != null)
                    {
                        selectedTags.Add(foundTag);
                    }
                }
            }

            blogPostDomainModel.Tags = selectedTags;

            //submit information to repo
            var updatedBlog = await blogPostRepository.UpdateAsync(blogPostDomainModel);
            if (updatedBlog != null)
            {
                //success
                return RedirectToAction("Edit");
            }
            //not succesfull message
            return RedirectToAction("Edit");


        }


        public async Task<IActionResult>Delete(EditBlogPostRequest editBlogPostRequest) 
        {
            // repository communication
            var deletedBlogPost = await blogPostRepository.DeleteAsync(editBlogPostRequest.Id);
            if (deletedBlogPost != null)
            {
                return RedirectToAction("List");


            }
            return RedirectToAction("Edit",new {id = editBlogPostRequest.Id});



        //display
        
        }
    }
}
