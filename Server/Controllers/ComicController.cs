using Microsoft.AspNetCore.Mvc;

namespace BlazorfullStack.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComicController : ControllerBase
    {
        private readonly DataContext _context;

        public ComicController(DataContext context)
        {

            _context = context;
        }
 
        [HttpGet]
        public async Task<ActionResult<List<Comic>>> GetComics()
        {
            var comics = await _context.Comics.ToListAsync();
            return Ok(comics);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Comic>> GetComic(int id)
        {
            var comc = await _context.Comics
                .FirstOrDefaultAsync(c => c.Id == id);
            if (comc == null)
            {
                return NotFound("Sorry,no Comic here. :/");
            }
            return Ok(comc);
        }
        [HttpPost]
        public async Task<ActionResult<List<Comic>>> CreateComic(Comic comc)
        {
            _context.Comics.Add(comc);
            await _context.SaveChangesAsync();

            return Ok(await GetDbComices());
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Comic>>> UpdateComic(Comic comc, int id)
        {
            var dbComc = await _context.Comics
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbComc == null)
                return NotFound("Sorry, but no Comic for you. :/");

            dbComc.Name = comc.Name;
         

            await _context.SaveChangesAsync();
            return Ok(await GetDbComices());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Comic>>> DeteleComic(int id)
        {
            var dbComc = await _context.Comics
                .FirstOrDefaultAsync(sh => sh.Id == id);
            if (dbComc == null)
                return NotFound("Sorry, but no hero for you. :/");

            _context.Comics.Remove(dbComc);

            await _context.SaveChangesAsync();
            return Ok(await GetDbComices());
        }
        private async Task<List<Comic>> GetDbComices()
        {
            return await _context.Comics.ToListAsync();
        }
    } 
       
}
