using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI;

namespace ISBank_Assessment.UI.Common
{
    public class ServiceFactory
    {
        public static readonly WebAPIClient Client;

        public static WebAPIClient GetClient(string view = null)
        {
            string userName;

            if (string.IsNullOrEmpty(view))
            {
                userName = SessionHelper.Get<string>("UserName");
            }
            else
            {
                userName = null;
            }

            return new WebAPIClient(null, new CustomHttpClientHandler(userName));
        }
    }
}