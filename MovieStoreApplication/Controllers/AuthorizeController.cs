using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieStoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    [Authorize]
    public class AuthorizeController : Controller
    {
       
    }
}
