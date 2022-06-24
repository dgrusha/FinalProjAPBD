using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using FinalApbd3.Server.Services;
using FinalApbd3.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FinalApbd3.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolygonController : ControllerBase
    {

        IPolygonService _polygonService;

        public PolygonController(IPolygonService polygonService) 
        {
            _polygonService = polygonService;
        }

        [Route("s2/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo(string ticker) 
        {
            return await _polygonService.getInfo(ticker);
        }

        [Route("s5/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo5(string ticker)
        {
            return await _polygonService.getInfo5(ticker);
        }

        [Route("s6/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo6(string ticker)
        {
            return await _polygonService.getInfo6(ticker);
        }

        [Route("s4/{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo4(string ticker)
        {
            return await _polygonService.getInfo4(ticker);
        }

        [Route("{ticker}")]
        [HttpGet]
        public async Task<string> GetInfo2(string ticker)
        {
            return await _polygonService.getInfo2(ticker);
        }

    }
}
