using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TEFlashCards.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost("createUser")]
        public void createUser()
        {
         
        }

        [HttpDelete("deleteUser")]
        public void deleteUser(int userId)
        {

        }

        [HttpPost("modifyRole")]
        public void modifyRole(string userRole)
        {

        }


    }

}