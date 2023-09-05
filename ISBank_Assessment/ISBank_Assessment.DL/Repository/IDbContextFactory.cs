using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.DL
{
    public interface IDbContextFactory //: IDisposable  //NOTE: Since UnitOfWork is disposable I am not sure if context factory has to be also...
    {
        InteractiveSolutionsBankEntities DbContext { get; }

    }
}
