using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturesController : ControllerBase
    {
        private readonly IBusinessData _data;
        private readonly SqlDbContext _dbContext;

        public FacturesController(IBusinessData data, SqlDbContext dbContext)        
        {            
            this._data = data;
            this._dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<FactureDTO> Get()
        {
            /*return _data.Factures;*/
            /*return _dbContext.Facture.ToList();*/
            return _data.FacturesDTO;
        }

/*        [HttpGet("{code}")]
        public ActionResult<IEnumerable<Facture>> Get(string code)
        {
            var facture = _data.Factures.Where(fac => fac.code == code).ToList();
            if (facture != null)
            {
                return facture;
            }
            else
                return NotFound("Facture non présente !");
        }*/

        [HttpPost]
        public ActionResult<FactureDTO> Post([FromBody]FactureDTO newFac)
        {
            if(ModelState.IsValid)
            {
                this._data.AddFac(newFac, this._dbContext);
                return Created($"factures/{newFac.code}", newFac);
            } else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
