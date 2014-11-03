using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http.ValueProviders;

namespace Giftable.API.AuthenticationHeaders
{
    public class HeaderValueProvider<T> : IValueProvider where T : class
    {
        private const string HeaderPrefix = "X-";
        private readonly HttpRequestHeaders _headers;

        public HeaderValueProvider(HttpRequestHeaders headers)
        {
            this._headers = headers;
        }

        public bool ContainsPrefix(string prefix)
        {
            var contains = this._headers.Any(h => h.Key.Contains(HeaderPrefix + prefix));
            return contains;
        }

        public ValueProviderResult GetValue(string key)
        {
            var contains = this._headers.Any(h => h.Key.Contains(HeaderPrefix + key));
            if (!contains)
                return null;

            var value = this._headers.GetValues(HeaderPrefix + key).First();
            return new ValueProviderResult(value, value, CultureInfo.InvariantCulture);
        }
    }
}