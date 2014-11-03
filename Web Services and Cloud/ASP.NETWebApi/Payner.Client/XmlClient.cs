using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Payner.Client
{
    class XmlClient
    {
        private HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:36313/") };

    }
}
