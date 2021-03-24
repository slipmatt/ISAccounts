using ISAccounts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISAccounts.Repositories
{
    public class BaseRepository<T>
    {

        public ResponseModel<T> SuccessResponse(int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage
            };
        }

        public ResponseModel<T> SuccessResponseWithObject(T returnObject, int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<T>
            {
                IsSuccess = true,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage,
                ReturnObject = returnObject
            };
        }
        public ResponseModel<T> FailResponse(int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<T>
            {
                IsSuccess = false,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage
            };
        }
        public ResponseModel<T> FailResponseWithObject(T returnObject, int code = 0, string friendlyMessage = "", string technicalMessage = "")
        {
            return new ResponseModel<T>
            {
                IsSuccess = false,
                Code = code,
                UserInterfaceMessage = friendlyMessage,
                TechnicalMessage = technicalMessage,
                ReturnObject = returnObject
            };
        }
    }
}
