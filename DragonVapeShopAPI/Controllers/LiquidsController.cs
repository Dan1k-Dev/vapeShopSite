using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiquidsController : Controller
    {
        readonly ILogger<LiquidsController> _logger;
        ContextDatabase _contextDatabase;
        public ILiquidsRepository LiquidsItems { get; set; } //Интерфейс репозитория 

        public LiquidsController(ILogger<LiquidsController> logger, ContextDatabase context, ILiquidsRepository repLiquids)
        {
            _logger = logger;
            _contextDatabase = context;
            LiquidsItems = repLiquids;
        }

        /// <summary>
        /// Возврат таблицы "Liquids" в формате JSON таблицы по переданному id 
        /// </summary>
        /// <param name="idLiquid"></param>
        /// <returns></returns>
        [HttpGet("{idLiquid}")]
        public async Task<ActionResult> GetLiquids(int idLiquid)
        {
            Liquids liquids = await _contextDatabase.Liquidss.FirstOrDefaultAsync(x => x.LiquidId == idLiquid);
            if (liquids == null) return NotFound();
            return new ObjectResult(liquids);
        }


        /// <summary>
        /// Получение отправленных данных и добавление их в БД
        /// </summary>
        /// <param name="liquids"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Liquids>> PostLiquids(Liquids liquids)
        {
            if (liquids == null)
            {
                return BadRequest();
            }
            _contextDatabase.Liquidss.Add(liquids);
            await _contextDatabase.SaveChangesAsync();
            return Ok(liquids);
        }

        /// <summary>
        /// Put запрос на обновление данных и вывод новых (обновленных) данных в формате json
        /// </summary>
        /// <param name="liquids"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Liquids>> PutLiquids(Liquids liquids)
        {
            if (ModelState.IsValid)
            {
                _contextDatabase.Liquidss.Update(liquids);
                _contextDatabase.SaveChangesAsync();
                return Ok(liquids);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete запрос (удаление данных из БД и вывод удаленных данных в виде json пакета)
        /// </summary>
        /// <param name="idLiquid"></param>
        /// <returns></returns>
        [HttpDelete("{idLiquid}")]
        public async Task<ActionResult> DeleteLiquids(int idLiquid)
        {
            Liquids liquids = _contextDatabase.Liquidss.Find(idLiquid);
            if (liquids == null)
            {
                return NotFound();
            }
            _contextDatabase.Liquidss.Remove(liquids);
            _contextDatabase.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
