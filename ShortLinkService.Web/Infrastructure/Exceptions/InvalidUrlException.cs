using System;
using System.Globalization;

namespace ShortLinkService.Web.Infrastructure.Exceptions
{
    public class InvalidUrlException : Exception
    {
        public InvalidUrlException() : base() { }

        public InvalidUrlException(string message) : base(message) { }

        public InvalidUrlException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
