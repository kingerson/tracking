using System;
using System.Collections.Generic;
using System.Text;

namespace Trackings.Domain.Exceptions
{
    public class TrackingsBaseException : Exception
    {
        public TrackingsBaseException()
        { }

        public TrackingsBaseException(string message)
            : base(message)
        { }

        public TrackingsBaseException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
