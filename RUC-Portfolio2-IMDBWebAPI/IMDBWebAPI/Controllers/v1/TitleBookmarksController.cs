using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IMDB.WebAPI.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class TitleBookmarksController : ControllerBase
    {
        // GET: api/<TitleBookmarksController>
        [HttpGet]
        public IEnumerable<string> GetTitleBookmarks()
        {
            return new string[] { "value1", "value2" };
        }

        // POST api/<TitleBookmarksController>
        [HttpPost]
        public void CreateTitleBookmark([FromBody] string value)
        {

        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{tconst}")]
        public void DeleteTitleBookmark(string tconst)
        {

        }
    }
}
