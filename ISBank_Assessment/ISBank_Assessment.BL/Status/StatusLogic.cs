using AutoMapper;
using ISBank_Assessment.BE;
using ISBank_Assessment.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBank_Assessment.BL
{
    public class StatusLogic:IStatus
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private GenericRepository<Status> statusRepository;

        public StatusLogic(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            this.statusRepository = unitOfWork.GetRepository<Status>();
        }

        public StatusLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.statusRepository = unitOfWork.GetRepository<Status>();
            this.mapper = mapper;
        }

        #region Read

        /// <summary>
        /// Returns a single Status
        /// </summary>
        /// <returns>Single Status object</returns>
        /// <param name="StatusId"></param>
        public Status GetStatusById(int StatusId)
        {
            #region Validation

            #endregion Validation

            return statusRepository.Get(x => x.StatusId == StatusId).SingleOrDefault();


        }

        /// <summary>
        /// Returns a list of Status
        /// </summary>
        /// <returns>Single Status object</returns>

        public List<Status> GetAllStatus()
        {
            #region Validation

            #endregion Validation

            return statusRepository.GetAll().ToList();


        }
        #endregion Read

        #region Modify
        //TODO LookUp Table
        //TODO - Status need to be a lookup
        /// <summary>
        /// Returns the Lookup entity for a specified LookupCode and LookupGroup
        /// </summary>
        /// <param name="LookupCode"></param>
        /// <param name="LookupgroupId"></param>
        /// <returns>Single Lookup entity</returns>
        //internal Lookup GetLookupFromLookupCodeAndLookupGroup(string LookupCode, int LookupgroupId)
        //{
        //    Lookup lookup = lookupRepository.Get(a => a.LookupCode == LookupCode && a.LookupGroupId == LookupgroupId).FirstOrDefault();

        //    if (lookup == null)
        //    {
        //        string GroupName = (from g in GetAllLookupGroups()
        //                            where g.LookupGroupId == LookupgroupId
        //                            select g.LookupGroupName).Single();

        //        throw new ValidationException(string.Format(BE.Resources.ErrorValidation.Validation.LookupItemDoesNotExist, LookupCode, GroupName));
        //    }

        //    return lookup;

        //}


        /// <summary>
        /// Add a Status object
        /// </summary>
        /// <returns>Single Status object</returns>
        /// <param name="StatusObj"></param>
        //public Status AddStatus(Status StatusObj)
        //{

        //    Status status = statusRepository.Insert(StatusObj);
        //    unitOfWork.Save();

        //    return status;
        //}

        /// <summary>
        /// Modify a Status object
        /// </summary>
        /// <returns>Single Status object</returns>
        /// <param name="StatusObj"></param>
        //public Status ModifyStatus(Status StatusObj, int StatusId)
        //{

        //    Status status = statusRepository.Get(x => x.StatusId == StatusObj.StatusId).SingleOrDefault();

        //    status.StatusTypes = StatusObj.StatusTypes;

        //    statusRepository.Update(status);
        //    unitOfWork.Save();

        //    return status;
        //}

        #endregion Modify
    }
}
