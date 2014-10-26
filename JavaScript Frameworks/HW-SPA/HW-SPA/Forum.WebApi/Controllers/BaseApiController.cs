namespace Forum.WebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class BaseApiController : ApiController
    {
        protected const string ValidSessionKeyChars =
           "qwertyuioplkjhgfdsazxcvbnmQWERTYUIOPLKJHGFDSAZXCVBNM";
        protected const int SessionKeyLength = 50;

        protected T PerformOperationAndHandleExceptions<T>(Func<T> operation)
        {
            try
            {
                return operation();
            }
            catch (Exception ex)
            {
                var errResponse = this.Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
                throw new HttpResponseException(errResponse);
            }
        }

        protected void ValidateSessionKey(string sessionKey)
        {
            if (sessionKey == null)
            {
                throw new ArgumentNullException("Session key cannot be null!");
            }
            else if (sessionKey.Length != SessionKeyLength)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Session key must be exactly {0} chars long!", SessionKeyLength));
            }
            else if (sessionKey.Any(x => !ValidSessionKeyChars.Contains(x) && !Char.IsDigit(x)))
            {
                throw new ArgumentOutOfRangeException("Session key must contain only latin letters and digits!");
            }
        }
    }
}
