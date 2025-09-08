using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using STANWEBAPI.Constants;
using STANWEBAPI.Exceptions;
using STANWEBAPI.Helpers;
using STANWEBAPI.Models.DTOs.Requests;

namespace STANWEBAPI.Filters.Validation
{
    public class SignUpRequestValidationFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var signUpRequestDTO = context.ActionArguments["requestDTO"] as SignUpRequestDTO
                ?? throw new ApplicationHttpException(
                   ApplicationErrorMessages.BadModel,
                   [ApplicationErrorMessages.BadModelErrorsContent(nameof(SignUpRequestDTO))],
                   (int)HttpStatusCode.BadRequest
            );

            var validationContext = new ValidationContext(signUpRequestDTO, null, null);
            if (!validationContext.IsValid<SignUpRequestDTO>(signUpRequestDTO, out var errorMessages))
            {
                throw new ApplicationHttpException(
                    ApplicationErrorMessages.BadModel,
                    errorMessages.ToArray() ?? [],
                    (int)HttpStatusCode.BadRequest
                );
            }

            if (
                string.IsNullOrEmpty(signUpRequestDTO.SouthAfricanIdentityNumber) &&
                string.IsNullOrEmpty(signUpRequestDTO.PassportNumber)
            )
            {
                throw new ApplicationHttpException(
                    ApplicationErrorMessages.BadModel,
                    [ ApplicationErrorMessages.SAIdOrPassportNotBoth ],
                    (int)HttpStatusCode.BadRequest
                );
            }

            if (
                !string.IsNullOrEmpty(signUpRequestDTO.SouthAfricanIdentityNumber) &&
                !string.IsNullOrEmpty(signUpRequestDTO.PassportNumber)
            )
            {
                throw new ApplicationHttpException(
                    ApplicationErrorMessages.BadModel,
                    [ ApplicationErrorMessages.SAIdOrPassportNotBoth ],
                    (int)HttpStatusCode.BadRequest
                );
            }
        }

        public void OnActionExecuted(ActionExecutedContext context) { }
    }
}