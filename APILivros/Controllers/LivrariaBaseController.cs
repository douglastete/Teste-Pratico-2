using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILivros.Controllers;
[Route("api/[controller]")]
[ApiController]
public abstract class LivrariaBaseController : ControllerBase
{
}
