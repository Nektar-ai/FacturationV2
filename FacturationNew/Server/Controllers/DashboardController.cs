using Facturation.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Facturation.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly IBusinessData _data;      

        public DashboardController(IBusinessData data)
        {
            this._data = data;
        }

        [HttpGet]
        public IEnumerable<ChiffreAffaire> Get()
        {
            return _data.CAs;
        }
    }
}
