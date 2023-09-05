﻿// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace WebAPI.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;

    public partial class AccountEntity
    {
        /// <summary>
        /// Initializes a new instance of the AccountEntity class.
        /// </summary>
        public AccountEntity() { }

        /// <summary>
        /// Initializes a new instance of the AccountEntity class.
        /// </summary>
        public AccountEntity(int? code = default(int?), int? personCode = default(int?), string accountNumber = default(string), double? outstandingBalance = default(double?), int? statusId = default(int?))
        {
            Code = code;
            PersonCode = personCode;
            AccountNumber = accountNumber;
            OutstandingBalance = outstandingBalance;
            StatusId = statusId;
        }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "code")]
        public int? Code { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "person_code")]
        public int? PersonCode { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "outstanding_balance")]
        public double? OutstandingBalance { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "StatusId")]
        public int? StatusId { get; set; }

    }
}
