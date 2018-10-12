// -------------------------------------------------------------------
// <copyright Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// -------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace ElGuerre.Taskin.Api
{
    [Serializable]
    public class ServiceException : BaseException
    {
        public ServiceException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public ServiceException(Exception exception) 
            : base(exception?.Message, exception)
        {
        }

        public ServiceException(string message) 
            : base(message)
        {
        }

        // Make serializable. Without this constructor, deserialization fail.
        protected ServiceException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
