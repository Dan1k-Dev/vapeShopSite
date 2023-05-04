using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using VapeShop.ClassesDb;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DragonVapeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumableController : Controller
    {
        readonly ILogger<ConsumableController> _logger;
        ContextDatabase _contextDatabase;
        public IConsumableRepository ConsumableItems { get; set; } //Интерфейс репозитория 

        public ConsumableController(ILogger<ConsumableController> logger, ContextDatabase context, IConsumableRepository repCons)
        {
            _logger = logger;
            _contextDatabase = context;
            ConsumableItems = repCons;
        }

        /// <summary>
        /// Возврат таблицы "Consumables" в формате JSON таблицы по переданному id
        /// </summary>
        /// <param name = "idConsumable" ></ param >
        /// < returns ></ returns >
        [HttpGet("{idConsumable}")]
        public async Task<ActionResult<Consumables>> GetConsumables(int idConsumable)
        {
            Consumables consumables = await _contextDatabase.Consumables.FirstOrDefaultAsync(x => x.ConsumableId == idConsumable);
            if (consumables == null) return NotFound();
            return new ObjectResult(consumables);
        }

        /// <summary>
        /// Получение отправленных данных и добавление их в БД
        /// </summary>
        /// <param name="consumables"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Consumables>> PostConsumables(Consumables consumables)
        {
            if (consumables == null)
            {
                return BadRequest();
            }
            _contextDatabase.Consumables.Add(consumables);
            await _contextDatabase.SaveChangesAsync();
            return Ok(consumables);
        }

        /// <summary>
        /// Put запрос на обновление данных и вывод новых (обновленных) данных в формате json
        /// </summary>
        /// <param name="consumables"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Consumables>> PutConsumables(Consumables consumables)
        {
            if (ModelState.IsValid)
            {
                _contextDatabase.Consumables.Update(consumables);
                _contextDatabase.SaveChangesAsync();
                return Ok(consumables);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete запрос (удаление данных из БД и вывод удаленных данных в виде json пакета)
        /// </summary>
        /// <param name="idConsumable"></param>
        /// <returns></returns>
        [HttpDelete("{idConsumable}")]
        public async Task<ActionResult> DeleteConsumables(int idConsumable)
        {
            Consumables consumables = _contextDatabase.Consumables.Find(idConsumable);
            if (consumables == null)
            {
                return NotFound();
            }
            _contextDatabase.Consumables.Remove(consumables);
            _contextDatabase.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
