using System.Data.Entity;

namespace ISBank_Assessment.DL
{
    public partial class InteractiveSolutionsBankEntities : DbContext
    {

        public InteractiveSolutionsBankEntities(string connectionString) : base(connectionString)
        {
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
        }
    }
}
