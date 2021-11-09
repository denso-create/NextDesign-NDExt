using System;
using System.Collections.Generic;
using System.Text;

namespace NDExt
{
    public class UserException : Exception
    {
        public UserException(string message) : base(message) { }

        public UserException(string message,Exception exception) : base(message,exception) { }
    }
}
