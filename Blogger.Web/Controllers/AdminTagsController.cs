using Blogger.Web.Models.Domain;
using Blogger.Web.Models.ViewModel;
using Blogger.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminTagsController : Controller
    {

        private readonly ITagRepository tagRepository;

        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            // Mapping the tag request to tag model 
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                Displayname = addTagRequest.DisplayName,

            };

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        public async Task<IActionResult> List()
        {
            var tags = await tagRepository.GetAllAsync();
            return View(tags);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var tag = await tagRepository.GetAsync(id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    Displayname = tag.Displayname
                };
                return View(editTagRequest);
            }


            return View(null);
        }
 
        [HttpPost]
        public async Task<IActionResult> Edit(EditTagRequest editTagRequest)
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                Displayname = editTagRequest.Displayname

            };
            var updatedTag = await tagRepository.UpdateAsync(tag);
            if (updatedTag != null)
            {
                // success message
            }
            else
            {

                // show failure message -java
            }

            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EditTagRequest editTagRequest)
        {
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);
            if (deletedTag != null)
            {
                //success
                return RedirectToAction("List");
            }

            // fail message
            return RedirectToAction("Edit", new { id = editTagRequest.Id });
        }

    }
}
