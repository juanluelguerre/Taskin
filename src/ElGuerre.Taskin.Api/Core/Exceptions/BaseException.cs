// ---------------------------------------------------------------------------------
// <copyright file="BaseException.cs" Author="Juan Luis Guerrero Minero" www="elGuerre.com">
//     Copyright (c) elGuerre.com. All rights reserved.
// </copyright>
// ---------------------------------------------------------------------------------
using System;
using System.Runtime.Serialization;

namespace ElGuerre.OneRest.Taskin.Api
{
    [Serializable]
    public class BaseException : Exception, IBaseException
    {
        public string AppName { get; set; }

        public BaseException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public BaseException(Exception exception)
            : base(exception?.Message, exception)
        {
        }

        public BaseException(string message)
            : base(message)
        {
        }

        // Make serializable. Without this constructor, deserialization fail.
        protected BaseException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
