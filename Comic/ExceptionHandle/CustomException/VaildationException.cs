using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WinFormTest.ExceptionHandle.CustomException
{
    public class VaildationException : Exception
    {
        public VaildationException(string message) : base(message)
        {
        }
    }
}
