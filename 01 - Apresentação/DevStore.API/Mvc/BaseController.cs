using DevStore.API.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace DesafioBiblico.Core.Mvc;

public abstract class BaseController : Controller
{
    protected IActionResult HandleResult(IMediatorResult result)
    {

        if (result.Exception is not null)
        {            
            return BadRequest(500);         
        }

        return result.IsValid
            ? Ok(result)
            : BadRequest(new { result.IsValid, result.Errors });
    }
}