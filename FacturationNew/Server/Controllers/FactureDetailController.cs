using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;

namespace FacturationNew.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FactureDetailController : ControllerBase
    {
        private readonly IBusinessData _data;
        private readonly SqlDbContext _dbContext;

        public FactureDetailController(IBusinessData data, SqlDbContext dbContext)
        {
            this._data = data;
            this._dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<FactureDTO> Post([FromBody] FactureDTO newFac)
        {
            if (ModelState.IsValid)
            {                
                this._data.deleteFac(newFac, this._dbContext);
                return Ok(newFac);
            }
            else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
