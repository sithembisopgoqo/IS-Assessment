using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ISBank_Assessment.UI.Common
{
    public class CustomHttpClientHandler : HttpClientHandler
    {
        protected string userName;
        public CustomHttpClientHandler(string userName = null)
        {
            this.userName = userName;
        }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                request.Headers.Add("x-ms-username", userName);
            }

            var response = await base.SendAsync(request, cancellationToken);

            if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.NoContent)
            {
                int test = (int)response.StatusCode;
                throw new HttpException((int)response.StatusCode, string.Format("{0}-{1}", (int)response.StatusCode, response.ReasonPhrase));
            }

            return response;
        }
    }
}