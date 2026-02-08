namespace IncuSmart.API.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult FromResult<T>(BaseResponse<T> response)
        {
            return response.StatusCode switch
            {
                API.StatusCode.SUCCESS => Ok(response),
                API.StatusCode.NOT_FOUND => NotFound(response),
                API.StatusCode.CONFLICT => Conflict(response),
                _ => BadRequest(response)
            };
        }
    }
}
