using System;
using Microsoft.AspNetCore.Mvc;

namespace API.QUAKEKIT.Helpers
{
    public static class ExtensionMethods
    {
        public static string GetLanguage(this ControllerBase controller)
        {
            return controller.Request.Headers["Accept-Language"];
        }
    }
}