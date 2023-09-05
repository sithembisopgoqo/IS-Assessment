using ISBank_Assessment.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity.WebApi;

namespace ISBank_Assessment.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityConfigurationLogic().GetUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}