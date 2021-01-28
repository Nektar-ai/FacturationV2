using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

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
    }
}
