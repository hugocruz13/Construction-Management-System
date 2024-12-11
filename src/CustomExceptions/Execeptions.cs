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
    public class ConfigurationErrorException  : ApplicationException
    {

        public ConfigurationErrorException () : base("An error occurred in the application.")
        {

        }

        public ConfigurationErrorException (string error) : base(error) 
        {
        
        }

        public ConfigurationErrorException (string error, Exception exception) : base(error , exception)
        {

        }
    }
}
