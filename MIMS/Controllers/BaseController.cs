using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MIMS.Utilities;

namespace MIMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly AppSettings appSettings;
       // public WorkerUtil workerUtil;

        public BaseController(IOptions<AppSettings> _settings)
        {
            appSettings = _settings.Value;
            //workerUtil = new WorkerUtil(HttpContext, appSettings);
        }
    }
}