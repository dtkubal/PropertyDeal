using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PropertyDeal.Core.Exceptions
{
    public class BaseException : ApplicationException
    {
        public BaseException(string message, string errocode)
            : base(message)
        {
            ErrorCode = errocode;
        }

        public string ErrorCode { get; set; }
    }
}
