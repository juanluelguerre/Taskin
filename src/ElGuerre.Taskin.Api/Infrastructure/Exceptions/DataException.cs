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
    public class DataException : BaseException
    {
        public DataException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        public DataException(Exception exception) 
            : base(exception?.Message, exception)
        {
        }

        public DataException(string message) : base(message)
        {
        }

        // Make serializable. Without this constructor, deserialization fail.
        protected DataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
