using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MIMS.BL.Interfaces;
using MIMS.DAL.Models;
using MIMS.Utilities;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MIMS.API.Controllers
{
    [Route("api/[controller]")]
    public class TestCentreController : BaseController
    {
        private ITestCentreBL biz;
        private AppSettings appsettings;
        public TestCentreController(IOptions<AppSettings> settings, ITestCentreBL _objTestCentreBL) : base(settings)
        {
            biz = _objTestCentreBL;
            appsettings = settings.Value;
        }
        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var _objTestCentres = biz.GetTestCentres();
                return Ok(JToken.FromObject(_objTestCentres));
               // return new List<string>();
            }
            catch (Exception ex)
            {
               // Log.Error("Get", ex, appsettings);
                throw ex;
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var _objTestCentre = biz.GetTestCentreDtailsById(id);
                return Ok(JToken.FromObject(_objTestCentre));
            }
            catch (Exception ex)
            {
                // Log.Error("Get", ex, appsettings);
                throw ex;
            }
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]Testcenter objTestCenter)
        {
            string status = string.Empty;
            try
            {
                status = biz.SaveTestCenter(objTestCenter);
                return Ok(status);
            }
            catch (Exception ex)
            {
                status = "Failed";
                return BadRequest(status);
            }
            
        }

        // PUT api/<controller>/5
        [HttpPut]
        public IActionResult Put([FromBody]Testcenter objTestCenter)
        {
            string status = string.Empty;
            try
            {
                status = biz.UpdateTestCenter(objTestCenter);
                return Ok(status);
            }
            catch (Exception ex)
            {
                status = "Failed";
                return BadRequest(status);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            string status = string.Empty;
            try
            {
                status = biz.DeactivateTestCenterById(id);
                return Ok(status);
            }
            catch (Exception ex)
            {
                status = "Failed";
                return BadRequest(status);
            }
        }
    }
}
