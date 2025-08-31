[ApiController]
[Route("api/[controller]")]
[Authorize] // This requires authentication
public class YourController : ControllerBase
{
    // Your API methods here
}