/*using AutoMapper;*/
using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CasController : ControllerBase
    {        
        private readonly IBusinessData _data;
        
        public CasController(ILogger<FacturesController> logger, IBusinessData data)
        {            
            _data = data;            
        }

        [HttpGet]
        public IEnumerable<ChiffreAffaire> Get()
        {
            return _data.CAs;
        }

/*        [HttpGet("{year}")]
        public ActionResult<IEnumerable<FactureDTO>> Get(string year)
        {
            var facList = _data.FacturesDTO.Where(fac => fac.dateEmission.Year.ToString() == year).ToList();
            if (facList != null)
            {
                return facList;
            }
            else
                return NotFound();
        }*/

    }
}
