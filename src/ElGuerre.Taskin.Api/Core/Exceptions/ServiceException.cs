// ---------------------------------------------------------------------------------
// <copyright file="ServiceException.cs" company="Inter-American Development Bank">
//     Copyright (c) WLMS-IDB. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace ElGuerre.OneRest.Taskin.Api
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
