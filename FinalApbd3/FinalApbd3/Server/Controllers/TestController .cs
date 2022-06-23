using System.Security.Claims;
using System.Threading.Tasks;
using FinalApbd3.Server.Data;
using FinalApbd3.Server.Models;
using FinalApbd3.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using FinalApbd3.Server.DTO;
using FinalApbd3.Shared.DTO;
using System.Collections.Generic;
using System;

namespace FinalApbd3.Server.Controllers
{
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private MyLocalContext _localContext;
        public TestController(MyLocalContext localContext) 
        {
            _localContext = localContext;
        }

        [HttpGet("news")]
        public List<NewsDTO> Dada3()
        {
            var res = _localContext.newsDTOs.ToList();
            return res;
        }

        [HttpGet("dbt")]
        public List<DataByTickerDto> Dada5()
        {
            var res = _localContext.dataByTickerDtos.ToList();
            return res;
        }

        [HttpGet("cont")]
        public List<DataDTO> Dada4()
        {
            var res = _localContext.dataDTOs.ToList();
            return res;
        }

        [HttpGet]
        public DataDTO Dada() 
        {
            var res = _localContext.dataDTOs.FirstOrDefault();
            return res;
        }

        [HttpGet("s")]
        public DataByTickerDto Dada2()
        {
            var res = _localContext.dataByTickerDtos.FirstOrDefault();
            return res;
        }

    }
}
