using System;
using System.Collections.Generic;
using System.Data.Entity.Core.EntityClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ISBank_Assessment.DL
{
    public class DbContextFactory : IDbContextFactory
    {
        private HttpContext httpContext;

        public DbContextFactory(HttpContext Context)
        {
            this.httpContext = Context;
          


        }

        public InteractiveSolutionsBankEntities DbContext
        {
            get
            {
                return new InteractiveSolutionsBankEntities(this.ChangeDatabaseNameInConnectionString().ConnectionString);
            }

        }
        private EntityConnectionStringBuilder ChangeDatabaseNameInConnectionString()
        {
         
                var ConnectionBuilder = new EntityConnectionStringBuilder(System.Configuration.ConfigurationManager.ConnectionStrings["InteractiveSolutionsBankEntities"].ConnectionString);
                return ConnectionBuilder;

        }
 
    }
}
