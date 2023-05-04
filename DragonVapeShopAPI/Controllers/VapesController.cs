using System.Runtime.CompilerServices;
using DragonVapeShopAPI.Database;
using DragonVapeShopAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VapeShop.ClassesDb;

namespace DragonVapeShopAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VapesController : ControllerBase
    {
        readonly ILogger<VapesController> _logger;
        ContextDatabase _contextDatabase;
        public IVapesRepository VapesItems { get; set; } //��������� ����������� 

        public VapesController(ILogger<VapesController> logger, ContextDatabase context, IVapesRepository repVapes)
        {
            _logger = logger;
            _contextDatabase = context;
            VapesItems = repVapes;
        }

        /// <summary>
        /// ������� ������� "Vapes" � ������� JSON ������� �� ����������� id 
        /// </summary>
        /// <param name="idVape"></param>
        /// <returns></returns>
        [HttpGet("{idVape}")]
        public async Task<ActionResult> GetVapes(int idVape)
        {
            Vapess vapes = await _contextDatabase.Vapess.FirstOrDefaultAsync(x => x.VapeId == idVape);
            if (vapes == null) return NotFound();
            return new ObjectResult(vapes);
        }


        /// <summary>
        /// ��������� ������������ ������ � ���������� �� � ��
        /// </summary>
        /// <param name="vapess"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Vapess>> PostVapes(Vapess vapess)
        {
            if (vapess == null)
            {
                return BadRequest();
            }
            _contextDatabase.Vapess.Add(vapess);
            await _contextDatabase.SaveChangesAsync();
            return Ok(vapess);
        }

        /// <summary>
        /// Put ������ �� ���������� ������ � ����� ����� (�����������) ������ � ������� json
        /// </summary>
        /// <param name="vapes"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Vapess>> PutVapes(Vapess vapes)
        {
            if (ModelState.IsValid)
            {
                _contextDatabase.Vapess.Update(vapes);
                _contextDatabase.SaveChangesAsync();
                return Ok(vapes);
            }
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Delete ������ (�������� ������ �� �� � ����� ��������� ������ � ���� json ������)
        /// </summary>
        /// <param name="idVapes"></param>
        /// <returns></returns>
        [HttpDelete("{idVapes}")]
        public async Task<ActionResult> DeleteVapes(int idVapes)
        {
            Vapess vapess = _contextDatabase.Vapess.Find(idVapes);
            if (vapess == null)
            {
                return NotFound();
            }
            _contextDatabase.Vapess.Remove(vapess);
            _contextDatabase.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}