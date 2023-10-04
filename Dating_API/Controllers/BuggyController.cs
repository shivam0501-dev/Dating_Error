using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using API.Controllers;
using Dating_API.Data;
using Dating_API.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dating_API.Controllers
{
   
    public class BuggyController : BaseApiController
    {
        private readonly ILogger<BuggyController> _logger;
        private readonly DataContext _db;
        public BuggyController(ILogger<BuggyController> logger,DataContext db)
        {
            _logger = logger;
            _db=db;
        }

        [HttpGet("auth")]
        public ActionResult<string> Getserect()
        {
            return Unauthorized();
        }

        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var nf=_db.Users.Find(-1);
            if(nf==null){
                return NotFound();
            }
            return nf;
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var nf=_db.Users.Find(-1);
            var nfRToreturn=nf.ToString();
            return nfRToreturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return BadRequest("This was not a good request");
        }
    }
}