namespace ReactDemoWebApp.Models
{
    using Microsoft.AspNetCore.Mvc;

    public class JsonResponse
    {
        public IActionResult GenerateJsonResult(bool status, string message = null, object data = null)
        {
            return new JsonResult(new JsonResponseHelper()
            {
                Status = status,
                Data = data,
                Message = message
            });
        }
    }

    public class DatatableResponse
    {
        public int TotalElements { get; set; }
        public object Data { get; set; }
    }

    public class JsonResponseHelper
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
