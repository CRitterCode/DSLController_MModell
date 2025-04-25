using Microsoft.AspNetCore.Mvc;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DSLController_MModell
{

[Route("opentimes")]
[Authorize(Roles="AllowAnonymus")]
[ValidateAntiForgeryToken]
public class BackofficeController : ControllerBase{
    
        [HttpPost]
        [Route("opentimes")]
        public ActionResult<List<Int32>> SetOpenTimes(){
            
             if (ModelState.IsValid){
                return BadRequest(ModelState);
             }
            throw new NotImplementedException();
         }
        
        [HttpGet]
        [Produces("application/json")]
        [Route("opentimes/all")]
        public IActionResult GetOpenTimes(){
            
            throw new NotImplementedException();
         }
        
  }
}
