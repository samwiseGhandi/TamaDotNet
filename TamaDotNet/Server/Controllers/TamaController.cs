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
        public async Task<IEnumerable<TamaModel>> GetAllTamas()
        {
            List<TamaModel> dbTamas = await _db.Tamas.ToListAsync();
            return dbTamas;
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
        [HttpPost("user")]
        public async Task<TamaModel> GetTama(UserDataModel user)
        {
            var dbTamas = await GetAllTamas();
            //.FirstOrDefault(t => t.UserId == user.Id);

            return dbTamas.FirstOrDefault(t => t.UserId == user.Id);
            
        }
    }
}
