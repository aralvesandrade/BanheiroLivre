using System.Collections.Generic;

namespace banheiro_livre.ViewModel
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {
        }

        public ErrorResponse(ErrorModel error)
        {
            Errors.Add(error);
        }
        
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}