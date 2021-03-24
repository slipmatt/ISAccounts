using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Models
{
    [Serializable]
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; }
        public int Code { get; set; }
        public string UserInterfaceMessage { get; set; }
        public string TechnicalMessage { get; set; }
        public T ReturnObject { get; set; }
    }
}
