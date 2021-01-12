using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Error
{
    public class ApiResponse
    {
        public int Statuscode { get; set; }
        public string Message { get; set; }

        public ApiResponse(int statuscode, string message=null)
        {
            Statuscode = statuscode;
            Message = message ?? GetDefaultMessageForStatusCode(statuscode);
        }

        private string GetDefaultMessageForStatusCode(int statuscode)
        {
            if (statuscode == 400)
            {
                return "A Bad request";
            }
            else if (statuscode == 401)
            {
                return "Not Authorised";

            }
            else if (statuscode == 404)
            {
                return "Not Found";

            }
            else
                return null;

        }


    }
}
