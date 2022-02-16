using Microsoft.AspNetCore.Mvc;
using PhoneDirectory.Shared.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneDirectory.Shared.ControllerBase
{
    public class CustomBaseController:Controller
    {
        public IActionResult CreateActionResultInstance<T>(Response<T> response)
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
