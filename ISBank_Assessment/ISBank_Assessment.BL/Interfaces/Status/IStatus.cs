using ISBank_Assessment.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public interface IStatus
    {
        #region Read
        Status GetStatusById(int StatusId);
        #endregion

        #region Modify
        //Status AddStatus(Status StatusObj);
        //Status ModifyStatus(Status StatusObj, int StatusId);
        #endregion

    }
}
