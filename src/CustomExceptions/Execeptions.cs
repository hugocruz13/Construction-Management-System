/*
*	<copyright file="CustomExceptions.cs" company="IPCA">
*		Copyright (c) 2024 All Rights Reserved
*	</copyright>
* 	<author>hugoc</author>
*   <date>12/3/2024 11:47:48 PM</date>
*	<description></description>
**/
using System;

namespace CustomExceptions
{
    /// <summary>
    /// Custom exception used for handling configuration-related errors in the application.
    /// </summary>
    public class ConfigurationErrorException  : ApplicationException
    {
        /// <summary>
        /// Initializes a new instance of the ConfigurationErrorException class with a default error message.
        /// </summary>
        public ConfigurationErrorException () : base("An error occurred in the application.")
        {

        }

        /// <summary>
        /// Initializes a new instance of theConfigurationErrorException class with a specified error message.
        /// </summary>
        /// <param name="error">The error message that explains the reason for the exception.</param>
        public ConfigurationErrorException (string error) : base(error) 
        {
        
        }

        /// <summary>
        /// Initializes a new instance of the ConfigurationErrorException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="error">The error message that explains the reason for the exception.</param>
        /// <param name="exception">The exception that is the cause of the current exception, or <c>null</c> if no inner exception is specified.</param>
        public ConfigurationErrorException (string error, Exception exception) : base(error , exception)
        {

        }
    }
}
