using Microsoft.AspNetCore.Mvc;
using BambooCard.Services;

namespace BambooCard.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BestStoriesController : Controller
    {        
        private readonly HackerNewsService _service;
        
        public BestStoriesController(HackerNewsService hackerNewsService)
        {           
            _service = hackerNewsService;
        }
               
        [HttpGet("GetData/{n}")]
        [ResponseCache(Duration = 30, VaryByQueryKeys = new[] { "n" })]        
        public async Task<IActionResult> GetData(int n)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response = await _service.GetBestStories(n);
            return Ok(response);            
            
        }       

    }
}
