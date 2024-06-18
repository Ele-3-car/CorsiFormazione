using CorsiFormazione.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CorsiFormazione.Web.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
        {
            List<String> errors = new List<string>();
            foreach (var key in context.ModelState)
            {
                var errorsNumber = key.Value.Errors;
                for (int i = 0; i < errorsNumber.Count(); i++)
                {
                    errors.Add(errorsNumber[0].ErrorMessage);
                }
            }

            var response = (BadResponse)Value;
            response.Errors = errors;
        }
    }
}
