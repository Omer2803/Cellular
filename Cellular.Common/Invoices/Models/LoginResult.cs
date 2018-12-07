using Cellular.Common.Models;

namespace Cellular.Common.Invoices.Models
{
    public class LoginResult
    {
        public object Result { get; set; }

        public LoginResultEnum ResultType { get; set; }

        //public LoginResult(LoginResultEnum resultType, object result = null)
        //{
        //    if((resultType == LoginResultEnum.Client && !(result is Client))
        //        || ResultType == LoginResultEnum.Employee && !(result is Employee))
        //        throw new 

        //    ResultType = resultType;
        //    Result = result;
        //}
    }
}
