using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ISBank_Assessment.Filters
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class CustomSwaggerOperationAttribute : Attribute
    {
        public CustomSwaggerOperationAttribute(string operationId)
        {
            this.OperationId = operationId;
        }

        public string OperationId { get; private set; }
    }
}