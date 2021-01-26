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
    public class DashboardController : ControllerBase
    {

        private readonly ILogger<FacturesController> _logger;
        private readonly IBusinessData _data;      
        /*private readonly IMapper _mapper;*/
        public DashboardController(ILogger<FacturesController> logger, IBusinessData data)
      
        {
            this._logger = logger;
            this._data = data;
            /*this._mapper = mapper;*/
        }

        [HttpGet]
        public double[] Get()
        {
            double[] BusiNbr = { 0, 0 };
            var factures = _data.FacturesDTO.ToList();
            var Cas = _data.CAs.ToList();

            var lastCa = Cas.LastOrDefault();
            BusiNbr[1] = lastCa.chiffreAffairesReel;

            foreach (var f in factures)
            {
                if (f.dateEmission.Year.ToString() == lastCa.year)
                {
                    var mDu = f.montantDu - f.montantRegle;
                    BusiNbr[0] += mDu;
                }
            }

            /*foreach (var c in Cas)
            {
                if (c.year == "2020")
                    BusiNbr[1] += c.chiffreAffairesR;
            }*/
            return BusiNbr;

        }
    }
}
