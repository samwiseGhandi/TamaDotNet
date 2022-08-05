using Microsoft.AspNetCore.Mvc;
using TamaDotNet.Shared.DTO;

namespace TamaDotNet.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TamaController:Controller
    {
        readonly TamaDbContext _db;
        public TamaController(TamaDbContext db)
        {
            _db = db;
        }
        [HttpPost]
        public async Task CreateTama(CreateTama newTama)
        {
            TamaModel tama = new TamaModel()
            {
                Name = newTama.Name,
                UserId = newTama.UserId,
                ImgUrl = newTama.ImgURL,
                Hygiene = 50,
                Mood = 50,
                Hunger = 50,
                
            };

            await _db.AddAsync( tama);
            await _db.SaveChangesAsync();
        }
        [HttpGet("{userId}")]
        public async Task<TamaModel> GetTama(string userId)
        {
            var dbtama = _db.Tamas.FirstOrDefault(t => t.UserId == userId);

            return dbtama;
        }
    }
}
