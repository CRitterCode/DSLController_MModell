using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLController_MModell
{

[Authorize]
[Route("api/[controller]")]
public class UserController : ControllerBase{
    
        [HttpGet]
        [Authorize(Roles="User,Admin")]
        public IActionResult Get(Route Int32 id){
            
            throw new NotImplementedException();
         }
        
  }
}
