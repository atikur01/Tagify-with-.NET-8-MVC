using Microsoft.AspNetCore.Mvc;

namespace webapp1.Controllers
{
    public class TagsController : Controller
    {
        // Example in-memory storage of tags for demonstration purposes
        private static List<string> _tags = new List<string> { "example", "tag", "test" };

        // GET: Tags
        public IActionResult Index()
        {
            // Pass the current tags to the view
            ViewBag.Tags = _tags;
            return View();
        }

        // POST: Tags/UpdateTags
        [HttpPost]
        public IActionResult UpdateTags([FromBody] List<string> tags)
        {
            if (tags == null)
            {
                return BadRequest("Tags cannot be null");
            }

            // Update tags in the database or process them as needed
            _tags = tags;

            return Ok(new { message = "Tags updated successfully" });
        }

        // POST: Tags/DeleteTag
        [HttpPost]
        public IActionResult DeleteTag([FromBody] string tag)
        {
            if (string.IsNullOrEmpty(tag))
            {
                return BadRequest("Tag cannot be null or empty");
            }

            // Delete tag from the database or process it as needed
            _tags.Remove(tag);

            return Ok(new { message = "Tag deleted successfully" });
        }
    }
}
