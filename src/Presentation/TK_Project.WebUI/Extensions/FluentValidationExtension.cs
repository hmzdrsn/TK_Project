using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace TK_Project.WebUI.Extensions
{
    public static class FluentValidationExtension
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            modelState.Clear();
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}
