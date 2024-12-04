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
    public class Execeptions : ApplicationException
    {

        public Execeptions() : base("An error occurred in the application.")
        {

        }

        public Execeptions(string error) : base(error) 
        {
        
        }

        public Execeptions(string error, Exception exception) : base(error + exception)
        {

        }
    }
}
