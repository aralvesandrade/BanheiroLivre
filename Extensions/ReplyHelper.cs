using System.Net;
using Microsoft.AspNetCore.Mvc;

namespace banheiro_livre.Extensions
{
    public class ReplyHelper
    {
        public static IActionResult ErrorMessage(string msg)
        {
            return new ObjectResult(msg) { StatusCode = (int)HttpStatusCode.InternalServerError };
        }
    }
}