using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STANWEBAPI.Filters.Validation;
using STANWEBAPI.Models.DTOs.Requests;
using STANWEBAPI.Models.DTOs.Responses;

namespace STANWEBAPI.Controllers.V1.Auth;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost]
    [Route("sign-up")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(BaseResponse<SignUpResponseDTO>), StatusCodes.Status201Created)]
    [ServiceFilter<SignUpRequestValidationFilter>]
    public async Task<ActionResult<BaseResponse<SignUpResponseDTO>>> UserSignUp(
        [FromBody] SignUpRequestDTO requestDTO
    )
    {
        //TODO: The SignUpRequestValidationFilter's Helper doesn't validate correctly.
        //If it's too much work to use System.ComponentModel.DataAnnotations; use Fluent Validation instead?
        var result = await Task.FromResult(new BaseResponse<SignUpResponseDTO>("", []));
        return Created("", result);
    }
}