using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OnceVapesController : Controller
    {
        readonly ILogger<OnceVapesController> _logger;
        ContextDatabase _contextDatabase;
        public IOnceVapesRepository OnceVapesItems { get; set; } //Интерфейс репозитория 

        public OnceVapesController(ILogger<OnceVapesController> logger, ContextDatabase context, IOnceVapesRepository repOnces)
        {
            _logger = logger;
            _contextDatabase = context;
            OnceVapesItems = repOnces;
        }

        /// <summary>
        /// Возврат таблицы "OnceVapes" в формате JSON таблицы по переданному id 
        /// </summary>
        /// <param name="idOnce"></param>
        /// <returns></returns>
        [HttpGet("{idOnce}")]
        public async Task<ActionResult> GetOncesVapes(int idOnce)
        {
            OnceVapes onces = await _contextDatabase.OnceVapess.FirstOrDefaultAsync(x => x.OnceVapeId == idOnce);
            if (onces == null) return NotFound();
            return new ObjectResult(onces);
        }


        /// <summary>
        /// Получение отправленных данных и добавление их в БД
        /// </summary>
        /// <param name="onces"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<OnceVapes>> PostOnces(OnceVapes onces)
        {
            if (onces == null)
            {
                return BadRequest();
            }
            _contextDatabase.OnceVapess.Add(onces);
            await _contextDatabase.SaveChangesAsync();
            return Ok(onces);
        }

        /// <summary>
        /// Put запрос на обновление данных и вывод новых (обновленных) данных в формате json
        /// </summary>
        /// <param name="onces"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<OnceVapes>> PutOnces(OnceVapes onces)
        {
            if (ModelState.IsValid)
            {
                _contextDatabase.OnceVapess.Update(onces);
                _contextDatabase.SaveChangesAsync();
                return Ok(onces);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete запрос (удаление данных из БД и вывод удаленных данных в виде json пакета)
        /// </summary>
        /// <param name="idOnce"></param>
        /// <returns></returns>
        [HttpDelete("{idOnce}")]
        public async Task<ActionResult> DeleteOnces(int idOnce)
        {
            OnceVapes onces = _contextDatabase.OnceVapess.Find(idOnce);
            if (onces == null)
            {
                return NotFound();
            }
            _contextDatabase.OnceVapess.Remove(onces);
            _contextDatabase.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
