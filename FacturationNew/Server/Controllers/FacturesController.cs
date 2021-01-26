using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturesController : ControllerBase
    {

        private readonly ILogger<FacturesController> _logger;
        private readonly IBusinessData _data;
        private readonly SqlDbContext _dbContext;
        /*private readonly BusinessData _bdata = new BusinessData();*/

        public FacturesController(ILogger<FacturesController> logger, IBusinessData data, SqlDbContext dbContext)        
        {
            this._logger = logger;
            this._data = data;
            /*this._bdata = bdata;*/
            this._dbContext = dbContext;
        }

/*        [HttpGet]
        public IEnumerable<Facture> Get()
        {
            return _data.Factures;
        }*/

        [HttpGet]
        public IEnumerable<Facture> Get()
        {
            
            /*return _data.Factures;*/
            return _dbContext.Facture.ToList();
        }

        /* [HttpGet]        
         public async Task<List<Facture>> Get()
         {
             return await _dbContext.Factures.ToListAsync();
         }*/

        [HttpGet("{code}")]
        public ActionResult<FactureDTO> Get(string code)
        {
            var facture = _data.FacturesDTO.Where(fac => fac.code == code).FirstOrDefault();
            if (facture != null)
            {
                return facture;
            }
            else
                return NotFound("Facture non présente !");
        }

        [HttpPost]
        public ActionResult<FactureDTO> Post([FromBody]FactureDTO newFac)
        {
            if(ModelState.IsValid)
            {
                /*Console.WriteLine("(FAC CONTROLLER) FACTURE RECUE !!");
                Console.WriteLine("(FAC CONTROLLER) NOM TITULAIRE FACTURE : "+newFac.client);*/
                /*this._data.addAllFac(_bdata.GetListFac(), this._dbContext);*/
                /*this._data.addAllCas(_bdata.GetListCas(), this._dbContext);*/
                this._data.AddFac(newFac, this._dbContext);
                return Created($"factures/{newFac.code}", newFac);
            } else
            {
                return BadRequest(ModelState.Values);
            }
        }
    }
}
