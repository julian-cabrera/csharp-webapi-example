using csharp_webapi_example.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace csharp_webapi_example.ActionResults
{
    public class CustomActionResult : IActionResult
    {
        private readonly CustomActionResultVM _result;
        public CustomActionResult(CustomActionResultVM result)
        {
            _result = result;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var oResult = new ObjectResult(_result.Exception ?? _result.Publisher as object)
            {
                StatusCode = _result.Exception != null ? StatusCodes.Status500InternalServerError : StatusCodes.Status200OK
            };
            await oResult.ExecuteResultAsync(context);
        }
    }
}
