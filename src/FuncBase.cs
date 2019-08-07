using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace AzureFunctionsSample
{
    public class FuncBase
    {
        public virtual StatusCodeResult StatusCode(int statusCode)
        {
            return new StatusCodeResult(statusCode);
        }

        public virtual ObjectResult StatusCode(int statusCode, object value)
        {
            return new ObjectResult(value)
            {
                StatusCode = new int?(statusCode)
            };
        }

        public virtual NoContentResult NoContent()
        {
            return new NoContentResult();
        }

        public virtual OkResult Ok()
        {
            return new OkResult();
        }
        public virtual OkObjectResult Ok(object value)
        {
            return new OkObjectResult(value);
        }

        public virtual RedirectResult Redirect(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            return new RedirectResult(url);
        }

        public virtual FileStreamResult File(Stream fileStream, string contentType)
        {
            return File(fileStream, contentType, null);
        }

        public virtual FileStreamResult File(Stream fileStream, string contentType, string fileDownloadName)
        {
            return new FileStreamResult(fileStream, contentType)
            {
                FileDownloadName = fileDownloadName
            };
        }

        public virtual UnauthorizedResult Unauthorized()
        {
            return new UnauthorizedResult();
        }

        public virtual NotFoundResult NotFound()
        {
            return new NotFoundResult();
        }

        public virtual NotFoundObjectResult NotFound(object value)
        {
            return new NotFoundObjectResult(value);
        }

        public virtual BadRequestResult BadRequest()
        {
            return new BadRequestResult();
        }

        public virtual BadRequestObjectResult BadRequest(object error)
        {
            return new BadRequestObjectResult(error);
        }

        public virtual BadRequestObjectResult BadRequest(ModelStateDictionary modelState)
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            return new BadRequestObjectResult(modelState);
        }

        public virtual ForbidResult Forbid()
        {
            return new ForbidResult();
        }

        public virtual ForbidResult Forbid(params string[] authenticationSchemes)
        {
            return new ForbidResult(authenticationSchemes);
        }

        public virtual ModelStateDictionary Validate(object model, bool isRequired = true)
        {
            var modelState = new ModelStateDictionary();

            if (model is null)
            {
                if (isRequired)
                {
                    modelState.AddModelError("request", "Request content is not provided. Ensure that the body and query string are populated as required");
                }

                return modelState;
            }

            ICollection<ValidationResult> validatorResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, new ValidationContext(model, null, null), validatorResults, true);

            foreach(var result in validatorResults)
            {
                foreach(var member in result.MemberNames)
                {
                    modelState.AddModelError(member, result.ErrorMessage);
                }
            }

            return modelState;
        }
    }
}
